using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// User Playlist Page View Model
    /// </summary>
    public class UserPlaylistPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private PlaylistViewModel _item = null;
        private ObservableCollection<TrackViewModel> _collection = null;
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
        /// Get
        /// </summary>
        /// <param name="id">Id</param>
        private async void Get(string id)
        {
            Item = await _client.GetPlaylistAsync(id);
            Collection = new ListTrackViewModel(
                _client, TrackType.Playlist, 
                id: Item.Id);
            Collection.CollectionChanged += CollectionChanged;
            Loading = true;
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Playlist View Model
        /// </summary>
        public PlaylistViewModel Item
        {
            get => _item;
            set { _item = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Track View Model
        /// </summary>
        public ObservableCollection<TrackViewModel> Collection
        {
            get => _collection;
            set { _collection = value; NotifyPropertyChanged(); }
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

        #region Event Handlers
        /// <summary>
        /// Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (TrackViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(TrackCommand);
                    foreach (ArtistViewModel subitem in item?.Artists?.Items)
                    {
                        subitem.Command = new RelayCommand(ArtistCommand);
                    }
                    if (item.Album != null)
                        item.Album.Command = new RelayCommand(AlbumCommand);
                }
            }
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        /// <param name="id">Id</param>
        public UserPlaylistPageViewModel(
            ISpotifySdkClient client,
            string id)
        {
            _client = client;
            Get(id);
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}