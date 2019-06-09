using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// User Tracks Page View Model
    /// </summary>
    public class UserTracksPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loadingRecent;
        private bool _loadingSaved;
        private bool _loadingTop;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<TrackViewModel> _recent = null;
        private ObservableCollection<TrackViewModel> _saved = null;
        private ObservableCollection<TrackViewModel> _top = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Track Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void TrackCommand(object parameter)
        {
            var item = (TrackViewModel)parameter;
            _main.Item.Navigate("track", item.Id, item.Name);
        }

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
        /// Album Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void AlbumCommand(object parameter)
        {
            var item = (AlbumViewModel)parameter;
            _main.Item.Navigate("album", item.Id, item.Name);
        }

        /// <summary>
        /// Get Recent
        /// </summary>
        private void GetRecent()
        {
            Recent = new ListTrackViewModel(
                _client, TrackType.UserRecentlyPlayed);
            Recent.CollectionChanged += CollectionChanged;
            LoadingRecent = true;
        }

        /// <summary>
        /// Get Saved
        /// </summary>
        private void GetSaved()
        {
            Saved = new ListTrackViewModel(
                _client, TrackType.UserSaved);
            Saved.CollectionChanged += CollectionChanged;
            LoadingSaved = true;
        }

        /// <summary>
        /// Get Top
        /// </summary>
        private void GetTop()
        {
            Top = new ListTrackViewModel(
                _client, TrackType.UserTop);
            Top.CollectionChanged += CollectionChanged;
            LoadingTop = true;
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Observable Collection of Track View Model
        /// </summary>
        public ObservableCollection<TrackViewModel> Recent
        {
            get => _recent;
            set { _recent = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Track View Model
        /// </summary>
        public ObservableCollection<TrackViewModel> Saved
        {
            get => _saved;
            set { _saved = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Track View Model
        /// </summary>
        public ObservableCollection<TrackViewModel> Top
        {
            get => _top;
            set { _top = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Recent Tracks Indicator
        /// </summary>
        public bool LoadingRecent
        {
            get => _loadingRecent;
            set { _loadingRecent = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Saved Tracks Indicator
        /// </summary>
        public bool LoadingSaved
        {
            get => _loadingSaved;
            set { _loadingSaved = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Top Tracks Indicator
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
            foreach (TrackViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(TrackCommand);
                    if (item.Artists?.Items != null)
                    {
                        foreach (ArtistViewModel subitem in item.Artists.Items)
                        {
                            subitem.Command = new RelayCommand(ArtistCommand);
                        }
                    }
                    if (item.Album != null)
                        item.Album.Command = new RelayCommand(AlbumCommand);
                }
            }
            LoadingRecent = false;
            LoadingSaved = false;
            LoadingTop = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public UserTracksPageViewModel(
            ISpotifySdkClient client)
        {
            _client = client;
            GetRecent();
            GetSaved();
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
