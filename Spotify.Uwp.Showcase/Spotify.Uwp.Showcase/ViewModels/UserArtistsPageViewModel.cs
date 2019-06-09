using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// User Artists Page View Model
    /// </summary>
    public class UserArtistsPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loadingFollowed;
        private bool _loadingTop;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<ArtistViewModel> _followed = null;
        private ObservableCollection<ArtistViewModel> _top = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Artist Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void ArtistCommand(object parameter)
        {
            var item = (ArtistViewModel)parameter;
            _main.Item.Navigate("artist", item.Id, item.Name);
        }

        /// <summary>
        /// Get Followed
        /// </summary>
        private void GetFollowed()
        {
            Followed = new ListArtistViewModel(
                _client, ArtistType.UserFollowed);
            Followed.CollectionChanged += CollectionChanged;
            LoadingFollowed = true;
        }

        /// <summary>
        /// Get Top
        /// </summary>
        private void GetTop()
        {
            Top = new ListArtistViewModel(
                _client, ArtistType.UserTop);
            Top.CollectionChanged += CollectionChanged;
            LoadingTop = true;
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Observable Collection of Artist View Model
        /// </summary>
        public ObservableCollection<ArtistViewModel> Followed
        {
            get => _followed;
            set { _followed = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Artist View Model
        /// </summary>
        public ObservableCollection<ArtistViewModel> Top
        {
            get => _top;
            set { _top = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Followed Artists Indicator
        /// </summary>
        public bool LoadingFollowed
        {
            get => _loadingFollowed;
            set { _loadingFollowed = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Top Artists Indicator
        /// </summary>
        public bool LoadingTop
        {
            get => _loadingTop;
            set { _loadingTop = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Event Handlers
        /// <summary>
        /// Collection Changed
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void CollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (ArtistViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(ArtistCommand);
                }
            }
            LoadingFollowed = false;
            LoadingTop = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public UserArtistsPageViewModel(
            ISpotifySdkClient client)
        {
            _client = client;
            GetFollowed();
            GetTop();
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}
