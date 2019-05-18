﻿using Spotify.Uwp.Showcase.ViewModels;
using System;
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
            this.InitializeComponent();
        #endregion Constructor

        #region Event Handlers
        /// <summary>OnNavigatedTo</summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(
            NavigationEventArgs e) =>
            this.DataContext = Item
                = new MainPageViewModel(
                SpotifySdk.Instance.SpotifySdkClient,
                Navigation, ContentFrame);

        /// <summary>
        /// Back Requested
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Navigation_BackRequested(
            NavigationView sender,
            NavigationViewBackRequestedEventArgs args) =>
            Item.BackRequested(sender, args);
        #endregion Event Handlers

        #region Public Properties
        public MainPageViewModel Item { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose()
        {
            Item = null;
            this.DataContext = null;
        }
        #endregion Public Methods
    }
}
