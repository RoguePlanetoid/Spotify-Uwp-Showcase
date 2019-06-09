using Spotify.Uwp.Exceptions;
using Spotify.Uwp.Showcase.Classes;
using Spotify.Uwp.Showcase.Pages;
using Spotify.Uwp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// Main Page View Model
    /// </summary>
    public class MainPageViewModel : BasePageViewModel
    {
        #region Private Constants
        private const string from_token = "from_token";
        private const string app_name = "Spotify Showcase";
        private readonly LoginType login_type = LoginType.ImplicitGrant;
        #endregion Private Constants

        #region Private Members
        private bool _loading;
        private Frame _contentFrame;
        private NavigationView _navigation;
        private WebView _webView;
        private ISpotifySdkClient _client = null;
        private CurrentUserViewModel _currentUser = null;
        private Dialog _dialog = new Dialog();

        private readonly NavigationTransitionInfo 
            _transition = new EntranceNavigationTransitionInfo();

        private readonly List<(string Tag, Type Page)> _pages
            = new List<(string Tag, Type Page)>
        {
            ("favourites", typeof(FavouritesPage)),
            ("search", typeof(SearchPage)),
            ("categories", typeof(CategoriesPage)),
            ("category", typeof(CategoryPage)),
            ("newreleases", typeof(NewReleasesPage)),
            ("featured", typeof(FeaturedPage)),
            ("recommended", typeof(RecommendedPage)),
            ("playlist", typeof(PlaylistPage)),
            ("album", typeof(AlbumPage)),
            ("artist", typeof(ArtistPage)),
            ("track", typeof(TrackPage)),
            ("recommendation", typeof(RecommendationPage)),
            ("usertracks", typeof(UserTracksPage)),
            ("useralbums", typeof(UserAlbumsPage)),
            ("userartists", typeof(UserArtistsPage)),
            ("userplaylists", typeof(UserPlaylistsPage)),
            ("userplaylist", typeof(UserPlaylistPage)),
        };
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Tuple of Success and Error Message (if any)</returns>
        private async Task<(bool success, string error)> Login()
        {
            var uri = await WebViewUri();
            if (uri.Host == _client.LoginRedirectUri.Host)
            {
                _webView.Visibility = Visibility.Collapsed;
                try
                {
                    _client.Token = await _client.GetLoginTokenAsync(login_type, uri);
                    _client.Country = _client.Country ?? from_token;
                    return (_client.IsUserLoggedIn, null);
                }
                catch (AuthException ex)
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
            if (navigateTag == "settings")
            {
                //_page = typeof(SettingsPage);
            }
            else
            {
                var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
                _page = page.Page;
            }
            // Get the page type before navigation so you can prevent duplicate entries in backstack
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Equals(preNavPageType, _page))
            {
                _contentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <returns></returns>
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
        /// Get
        /// </summary>
        private async void Get()
        {
            CurrentUser = await _client.GetCurrentUserAsync();
        }

        /// <summary>
        /// Web View Uri
        /// </summary>
        /// <returns></returns>
        private async Task<Uri> WebViewUri() => 
            new Uri(await _webView.InvokeScriptAsync("eval", 
                new string[] { "document.location.href;" }));
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Current User
        /// </summary>
        public CurrentUserViewModel CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Indicator
        /// </summary>
        public bool Loading
        {
            get => _loading;
            set { _loading = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Public Events
        /// <summary>
        /// Loaded
        /// </summary>
        public void Loaded() => 
            Get();

        /// <summary>
        /// Token Required Event
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Token Required Arguments</param>
        public void TokenRequiredEvent(
            object sender,
            TokenRequiredArgs e) => 
            ShowWebViewLogin();

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void BackRequested(
            NavigationView sender,
            NavigationViewBackRequestedEventArgs args) => 
            BackRequested();

        /// <summary>
        /// Back Invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                _contentFrame.SourcePageType == typeof(UserPlaylistPage)) 
            {
                // Do Nothing
            }
            else if (_contentFrame.SourcePageType == typeof(SearchPage))
            {
                _navigation.SelectedItem = null;
            }
            else
            //if (ContentFrame.SourcePageType == typeof(SettingsPage))
            //{
            //    // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
            //    NavView.SelectedItem = (muxc.NavigationViewItem)NavView.SettingsItem;
            //    NavView.Header = "Settings";
            //}
            //else 
            if (_contentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);
                _navigation.SelectedItem = _navigation.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));
                _navigation.Header =
                    ((NavigationViewItem)_navigation.SelectedItem)?.Content?.ToString();
            }
        }

        /// <summary>
        /// Item Invoked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ItemInvoked(
            NavigationView sender,
            NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                //NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navigationTag = args.InvokedItemContainer.Tag.ToString();
                Navigate(navigationTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        /// <summary>
        /// Search Query Submitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args) => 
            NavigateRelated("search", args.QueryText, 
                $"Results for \"{args.QueryText}\"");

        /// <summary>
        /// Navigation Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="args">Navigation Completed Arguments</param>
        public void WebViewNavigationStarting(WebView webView,
            WebViewNavigationStartingEventArgs args)
        {
            Loading = true;
        }

        /// <summary>
        /// Web View Navigation Completed
        /// </summary>
        /// <param name="webView">Web View</param>
        /// <param name="args">Navigation Completed Arguments</param>
        public async void WebViewNavigationCompleted(WebView webView,
            WebViewNavigationCompletedEventArgs args)
        {
            Loading = false;
            var (success, error) = await Login();
            if (success)
            {
                _navigation.Visibility = Visibility.Visible;
                CurrentUser = await _client.GetCurrentUserAsync();
            }
            else
            {
                if (!string.IsNullOrEmpty(error))
                {
                    ShowWebViewLogin();
                    await _dialog.ShowAsync(error, app_name);
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
        /// <param name="name">Name</param>
        public void Navigate(
            string navigateTag, 
            object parameter, 
            string name)
        {
            Type _page = null;
            var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
            _page = page.Page;
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            if (!(_page is null) && !Equals(preNavPageType, _page))
            {
                _contentFrame.Navigate(_page, parameter, _transition);
                _navigation.Header = name;
            }
        }

        /// <summary>
        /// NavigateRelated
        /// </summary>
        /// <param name="navigateTag">Navigate Tag</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="name">Name</param>
        /// <param name="transition">Transition</param>
        public void NavigateRelated(
            string navigateTag, 
            object parameter, 
            string name)
        {
            Type _page = null;
            var page = _pages.FirstOrDefault(p => p.Tag.Equals(navigateTag));
            _page = page.Page;
            var preNavPageType = _contentFrame.CurrentSourcePageType;
            _contentFrame.Navigate(_page, parameter, _transition);
            _navigation.Header = name;
            if (preNavPageType == _page)
                _contentFrame.BackStack.Remove(_contentFrame.BackStack.LastOrDefault());
        }

        /// <summary>
        /// Show WebView Login
        /// </summary>
        public void ShowWebViewLogin()
        {
            _navigation.Visibility = Visibility.Collapsed;
            _webView.Visibility = Visibility.Visible;
            var uri = _client.GetLoginUri(login_type, ScopeViewModel.AllPermissions, true);
            _webView.Navigate(uri);
        }
        #endregion Public Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public MainPageViewModel(
            ISpotifySdkClient client,
            NavigationView navigation,
            Frame content,
            WebView webView)
        {
            _client = client;
            _navigation = navigation;
            _contentFrame = content;
            _webView = webView;
            _client.TokenRequiredEvent += TokenRequiredEvent;
        }
        #endregion Constructor
    }
}
