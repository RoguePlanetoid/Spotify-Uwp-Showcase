using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Main Page
    /// </summary>
    public sealed partial class MainPage : Page, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage() =>
            InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>
        /// Page Loaded
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Routed Event Args</param>
        private void Page_Loaded(object sender, RoutedEventArgs e) =>
            Item.Loaded();

        /// <summary>OnNavigatedTo</summary>
        /// <param name="e">Navigation Event Args</param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
            DataContext = Item = new MainPageViewModel(
                SpotifySdk.Instance.Client,
                Navigation,
                ContentFrame, 
                WebView);

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="args">Navigation View Back Requested Event Args</param>
        private void Navigation_BackRequested(
            NavigationView sender,
            NavigationViewBackRequestedEventArgs args) =>
            Item.BackRequested(sender, args);

        /// <summary>
        /// Web View Navigated Completed
        /// </summary>
        /// <param name="sender">WebView</param>
        /// <param name="args">WebView Navigation Completed Event Args</param>
        private void WebView_NavigationCompleted(WebView sender,
            WebViewNavigationCompletedEventArgs args) =>
            Item.WebViewNavigationCompleted(sender, args);

        /// <summary>
        /// Web View Navigation Starting
        /// </summary>
        /// <param name="sender">WebView</param>
        /// <param name="args">WebView Navigation Starting Event Args</param>
        private void WebView_NavigationStarting(WebView sender,
            WebViewNavigationStartingEventArgs args) =>
            Item.WebViewNavigationStarting(sender, args);
        #endregion Event Handlers

        #region Public Properties
        /// <summary>
        /// Main Page View Model
        /// </summary>
        public MainPageViewModel Item { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() => 
            DataContext = null;
        #endregion Public Methods
    }
}