using Spotify.NetStandard.Sdk;
using Spotify.Uwp.Showcase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Main Page View Model
    /// </summary>
    public class MainPageViewModel : BasePageViewModel
    {
        #region Private Constants
        private const int check_playing_interval = 10;
        private const string from_token = "from_token";
        private const string app_name = "Spotify Showcase";
        #endregion Private Constants

        #region Private Readonly
        private readonly Dialog _dialog;
        private readonly WebView _webView;
        private readonly Frame _contentFrame;
        private readonly NavigationView _navigation;
        private readonly NavigationTransitionInfo _transition;
        private readonly AuthenticationFlowType _authenticationFlowType;
        private readonly List<(string Tag, Type Page)> _pages = 
            new List<(string Tag, Type Page)>
        {
            ("favourites", typeof(FavouritesPage)),
            ("search", typeof(SearchPage)),
            ("category", typeof(CategoryPage)),
            ("categories", typeof(CategoriesPage)),
            ("newreleases", typeof(NewReleasesPage)),
            ("featured", typeof(FeaturedPage)),
            ("recommended", typeof(RecommendedPage)),
            ("recommendation", typeof(RecommendationPage)),
            ("playlist", typeof(PlaylistPage)),
            ("playlists", typeof(PlaylistsPage)),
            ("album", typeof(AlbumPage)),
            ("albums", typeof(AlbumsPage)),
            ("artist", typeof(ArtistPage)),
            ("artists", typeof(ArtistsPage)),
            ("track", typeof(TrackPage)),
            ("tracks", typeof(TracksPage)),
            ("shows", typeof(ShowsPage)),
            ("show", typeof(ShowPage)),
            ("user", typeof(UserPage)),
            ("playing", typeof(CurrentlyPlayingPage)),
            ("episode", typeof(EpisodePage)),
            ("currentuser", typeof(CurrentUserPage))
        };
        #endregion Private Readonly

        #region Private Members
        private DispatcherTimer _timer = null;
        private CurrentUserResponse _currentUser;
        private CurrentlyPlayingItemResponse _currentlyPlayingItem;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Is Redirect Host
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <returns>True if is, False if Not</returns>
        private bool IsRedirectHost(Uri uri) =>
            uri.Host == Client.AuthenticationRedirectUri.Host;

        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Tuple of Success and Error Message (if any)</returns>
        private async Task<(bool success, string error)> Login()
        {
            var uri = await WebViewUri();
            if (IsRedirectHost(uri))
            {
                _webView.Visibility = Visibility.Collapsed;
                try
                {
                    Client.AuthenticationToken = await Client.GetAuthenticationTokenAsync(_authenticationFlowType, uri);
                    Client.Country = Client.Country ?? from_token;
                    return (Client.IsUserLoggedIn, null);
                }
                catch (BaseAuthenticationException ex)
                {
                    return (false, $"There was a problem with Login. Details: {ex.Message}");
                }
            }
            return (false, null);
        }

        /// <summary>
        /// Navigate
        /// </summary>
        /// <param name="navigateTag">Navigate Tag</param>
        /// <param name="transitionInfo">Transition Info</param>
        private void Navigate(string navigateTag,
            NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
            _page = page.Page;
            // Get the page type before navigation so you can prevent duplicate entries in backstack
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Equals(preNavPageType, _page))
                _contentFrame.Navigate(_page, null, transitionInfo);
        }

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <returns>True if is, False if Not</returns>
        private bool BackRequested()
        {
            if (!_contentFrame.CanGoBack)
                return false;
            if (_navigation.IsPaneOpen &&
                (_navigation.DisplayMode == NavigationViewDisplayMode.Compact ||
                 _navigation.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;
            _contentFrame.GoBack();
            return true;
        }

        /// <summary>
        /// Set Current User
        /// </summary>
        private async void SetCurrentUser() => 
            CurrentUser = await Client.GetCurrentUserAsync();

        /// <summary>
        /// Set Currently Playing Item
        /// </summary>
        private async void SetCurrentlyPlayingItem()
        {
            if (Client.IsUserLoggedIn)
                CurrentlyPlayingItem = await Client.GetUserCurrentlyPlayingItemAsync();
        }

        /// <summary>
        /// Get Currently Playing
        /// </summary>
        private void GetCurrentlyPlayingItem()
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(check_playing_interval)
                };
                _timer.Tick += (object sender, object e) => SetCurrentlyPlayingItem();
                _timer.Start();
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        private void Get()
        {
            // Set Current User
            SetCurrentUser();
            // Set Currently Playing Item
            SetCurrentlyPlayingItem();
            // Get Currently Playing Item
            GetCurrentlyPlayingItem();
            // Commands
            Client.CommandActions.CurrentUser = (item) => NavigatePage(item);
        }

        /// <summary>
        /// Web View Uri
        /// </summary>
        /// <returns>Uri</returns>
        private async Task<Uri> WebViewUri() =>
            new Uri(await _webView.InvokeScriptAsync("eval",
                new string[] { "document.location.href;" }));

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>True if Dialog Shown, False if Not</returns>
        private async Task<bool> ShowDialog(string message) => 
            await _dialog.ShowAsync(message, app_name);

        /// <summary>
        /// Current User Logout Handler
        /// </summary>
        public void CurrentUserLogoutHandler(CurrentUserResponse response)
        {
            Client.Logout();
            // Show WebView Login with Dialog
            ShowWebViewLogin(true);
        }
        #endregion Private Methods

        #region Event Handlers
        /// <summary>
        /// Token Required Event Handler
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Token Required Arguments</param>
        public void AuthenticationTokenRequiredEventHandler(
            object sender,
            AuthenticationTokenRequiredArgs e) =>
            ShowWebViewLogin();

        /// <summary>
        /// Client Exception Handler
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Client Exception Arguments</param>
        public async void ClientExceptionHandler(object sender, ClientExceptionArgs e) =>
            await ShowDialog(e.Exception.Message);

        /// <summary>
        /// Response Error Handler
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Response Error Arguments</param>
        private async void ResponseErrorHandler(object sender, ResponseErrorArgs e) =>
            await ShowDialog(e.Error.Message);
        #endregion Event Handlers

        #region Public Properties
        /// <summary>
        /// Current User
        /// </summary>
        public CurrentUserResponse CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Currently Playing
        /// </summary>
        public CurrentlyPlayingItemResponse CurrentlyPlayingItem
        {
            get => _currentlyPlayingItem;
            set { _currentlyPlayingItem = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Current User Logout Command
        /// </summary>
        public ICommand CurrentUserLogoutCommand { get; private set; }
        #endregion Public Properties

        #region Public Events
        /// <summary>
        /// Loaded
        /// </summary>
        public void Loaded() =>
            Get();

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="args">Navigation View Back Requested Event Args</param>
        public void BackRequested(
            NavigationView sender,
            NavigationViewBackRequestedEventArgs args) =>
            BackRequested();

        /// <summary>
        /// Back Invoked
        /// </summary>
        /// <param name="sender">Keyboard Accelerator</param>
        /// <param name="args">Keyboard Accelerator Invoked Event Args</param>
        public void BackInvoked(
            KeyboardAccelerator sender,
            KeyboardAcceleratorInvokedEventArgs args)
        {
            BackRequested();
            args.Handled = true;
        }

        /// <summary>
        /// Content Frame Navigated
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Navigation Event Args</param>
        public void Navigated(
            object sender,
            NavigationEventArgs e)
        {
            _navigation.IsBackEnabled = _contentFrame.CanGoBack;
            if (_contentFrame.SourcePageType == typeof(CategoryPage))
            {
                _navigation.SelectedItem = _navigation.MenuItems
                .OfType<NavigationViewItem>()
                .First(n => n.Tag.Equals("categories"));
            }
            else if (
                _contentFrame.SourcePageType == typeof(PlaylistPage) || 
                _contentFrame.SourcePageType == typeof(AlbumPage) ||
                _contentFrame.SourcePageType == typeof(ArtistPage) ||
                _contentFrame.SourcePageType == typeof(TrackPage) ||
                _contentFrame.SourcePageType == typeof(RecommendationPage) ||
                _contentFrame.SourcePageType == typeof(ShowPage) ||
                _contentFrame.SourcePageType == typeof(UserPage) ||
                _contentFrame.SourcePageType == typeof(EpisodePage) ||
                _contentFrame.SourcePageType == typeof(CurrentUserPage)
                )
            {
                // Do Nothing
            }
            else if (_contentFrame.SourcePageType == typeof(SearchPage))
            {
                _navigation.SelectedItem = null;
            }
            else if (_contentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                _navigation.SelectedItem = _navigation.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));
            }
        }

        /// <summary>
        /// Item Invoked
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="args">Navigation View Item Invoked Event Args</param>
        public void ItemInvoked(
            NavigationView sender,
            NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                var navigationTag = args.InvokedItemContainer.Tag.ToString();
                Navigate(navigationTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        /// <summary>
        /// Search Query Submitted
        /// </summary>
        /// <param name="sender">Auto Suggest Box</param>
        /// <param name="args">Auto Suggest Box Query Submitted Event Args</param>
        public void QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args) =>
            NavigateRelated("search", args.QueryText);

        /// <summary>
        /// Navigation Loaded
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Routed Event Args</param>
        public void NavigationLoaded(object sender, RoutedEventArgs e)
        {
            Navigate("favourites", new EntranceNavigationTransitionInfo());
            // GO-BACK
            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            _navigation.KeyboardAccelerators.Add(goBack);
            // ALT-LEFT
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            _navigation.KeyboardAccelerators.Add(altLeft);
        }

        /// <summary>
        /// Web View Navigation Starting
        /// </summary>
        /// <param name="webView">Web View</param>
        /// <param name="args">Web View Navigation Starting Event Args</param>
        public void WebViewNavigationStarting(WebView webView,
            WebViewNavigationStartingEventArgs args)
        {
            if (IsRedirectHost(args.Uri))
                _webView.Visibility = Visibility.Collapsed;
            else
                Loading = true;
        }

        /// <summary>
        /// Web View Navigation Completed
        /// </summary>
        /// <param name="webView">Web View</param>
        /// <param name="args">Web View Navigation Completed Args</param>
        public async void WebViewNavigationCompleted(WebView webView,
            WebViewNavigationCompletedEventArgs args)
        {
            var (success, error) = await Login();
            if (success)
            {
                _navigation.Visibility = Visibility.Visible;
                Get();
                Loading = false;
            }
            else
            {
                webView.Visibility = Visibility.Visible;
                Loading = false;
                if (!string.IsNullOrEmpty(error))
                {
                    ShowWebViewLogin();
                    await ShowDialog(error);
                }
            }
        }
        #endregion Public Events

        #region Public Methods
        /// <summary>
        /// Navigate
        /// </summary>
        /// <param name="navigateTag">Navigate Tag</param>
        /// <param name="parameter">Parameter</param>
        public void Navigate(
            string navigateTag,
            object parameter)
        {
            Type _page = null;
            var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
            _page = page.Page;
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            if (!(_page is null) && !Equals(preNavPageType, _page))
                _contentFrame.Navigate(_page, parameter, _transition);
        }

        /// <summary>
        /// NavigateRelated
        /// </summary>
        /// <param name="navigateTag">Navigate Tag</param>
        /// <param name="parameter">Parameter</param>
        public void NavigateRelated(
            string navigateTag,
            object parameter)
        {
            Type _page = null;
            var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
            _page = page.Page;
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            _contentFrame.Navigate(_page, parameter, _transition);
            if (preNavPageType == _page)
                _contentFrame.BackStack.Remove(_contentFrame.BackStack.LastOrDefault());
        }

        /// <summary>
        /// Show WebView Login
        /// </summary>
        /// <param name="showDialog">Show Dialog</param>
        public void ShowWebViewLogin(bool showDialog = false)
        {
            _navigation.Visibility = Visibility.Collapsed;
            var uri = Client.GetAuthenticationUri(
                authenticationFlowType: _authenticationFlowType,
                authenticationScope: AuthenticationScopeRequest.AllPermissions,
                showAuthenticationDialog: showDialog);
            _webView.Navigate(uri);
        }
        #endregion Public Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="navigation">Navigation View</param>
        /// <param name="content">Content Frame</param>
        /// <param name="webView">Web View</param>
        public MainPageViewModel(
            ISpotifySdkClient client,
            NavigationView navigation,
            Frame content,
            WebView webView) : base(client)
        {
            _webView = webView;
            _dialog = new Dialog();
            _contentFrame = content;
            _navigation = navigation;
            Client.ResponseError += ResponseErrorHandler;
            Client.ClientException += ClientExceptionHandler;
            _transition = new EntranceNavigationTransitionInfo();
            _authenticationFlowType = AuthenticationFlowType.ImplicitGrant;
            Client.AuthenticationTokenRequired += AuthenticationTokenRequiredEventHandler;
            CurrentUserLogoutCommand = new GenericCommand<CurrentUserResponse>(CurrentUserLogoutHandler);
        }
        #endregion Constructor
    }
}
