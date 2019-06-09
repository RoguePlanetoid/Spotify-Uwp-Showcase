using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// Artist Page View Model
    /// </summary>
    public class ArtistPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loadingTracks;
        private bool _loadingAlbums;
        private bool _loadingArtists;
        private ISpotifySdkClient _client = null;
        private ArtistViewModel _item = null;
        private ObservableCollection<TrackViewModel> _tracks = null;
        private ObservableCollection<AlbumViewModel> _albums = null;
        private ObservableCollection<ArtistViewModel> _artists = null;
        private ToggleFavouriteViewModel _toggleFavourite = null;
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
        /// Album Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void AlbumCommand(object parameter)
        {
            var item = (AlbumViewModel)parameter;
            _main.Item.Navigate("album", item.Id, item.Name);
        }

        /// <summary>
        /// Artist Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void ArtistCommand(object parameter)
        {
            var item = (ArtistViewModel)parameter;
            _main.Item.NavigateRelated("artist", item.Id, item.Name);
        }

        /// <summary>
        /// Toggle Favourite Command
        /// </summary>
        /// <param name="parameter"></param>
        private void ToggleFavouriteCommand(object parameter)
        {
            var item = (ToggleFavouriteViewModel)parameter;
            ToggleFavourite.Value =
                _client.Favourites.Toggle(FavouriteType.Album, item.Id, item.Value);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="id">Id</param>
        private void Set(string id)
        {
            ToggleFavourite = new ToggleFavouriteViewModel()
            {
                Id = id,
                Value = _client.Favourites.Contains(FavouriteType.Artist, id),
                Command = new RelayCommand(ToggleFavouriteCommand)
            };
        }

        /// <summary>
        /// Get Artist
        /// </summary>
        /// <param name="id">Id</param>
        private async void Get(string id)
        {
            Set(id);
            Item = await _client.GetArtistAsync(id);
        }

        /// <summary>
        /// Get Tracks
        /// </summary>
        /// <param name="id">Id</param>
        private void GetTracks(string id)
        {
            Tracks = new ListTrackViewModel(
                _client, TrackType.Artist,
                id: id);
            Tracks.CollectionChanged += TracksCollectionChanged;
            LoadingTracks = true;
        }

        /// <summary>
        /// Get Albums
        /// </summary>
        /// <param name="id">Id</param>
        private void GetAlbums(string id)
        {
            Albums = new ListAlbumViewModel(
                _client, AlbumType.Artist,
                id: id);
            Albums.CollectionChanged += AlbumsCollectionChanged;
            LoadingAlbums = true;
        }

        /// <summary>
        /// Get Artists
        /// </summary>
        /// <param name="id">Id</param>
        private void GetArtists(string id)
        {
            Artists = new ListArtistViewModel(
                _client, ArtistType.Related,
                id: id);
            Artists.CollectionChanged += ArtistsCollectionChanged;
            LoadingArtists = true;
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Artist View Model
        /// </summary>
        public ArtistViewModel Item
        {
            get => _item;
            set { _item = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Track View Model
        /// </summary>
        public ObservableCollection<TrackViewModel> Tracks
        {
            get => _tracks;
            set { _tracks = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Artist View Model
        /// </summary>
        public ObservableCollection<ArtistViewModel> Artists
        {
            get => _artists;
            set { _artists = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Album View Model
        /// </summary>
        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set { _albums = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Tracks Indicator
        /// </summary>
        public bool LoadingTracks
        {
            get => _loadingTracks;
            set { _loadingTracks = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Artists Indicator
        /// </summary>
        public bool LoadingArtists
        {
            get => _loadingArtists;
            set { _loadingArtists = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Loading Albums Indicator
        /// </summary>
        public bool LoadingAlbums
        {
            get => _loadingAlbums;
            set { _loadingAlbums = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Toggle Favourite View Model
        /// </summary>
        public ToggleFavouriteViewModel ToggleFavourite
        {
            get => _toggleFavourite;
            set { _toggleFavourite = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Event Handlers
        /// <summary>
        /// Tracks Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TracksCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (TrackViewModel item in e.NewItems)
            {
                if (item?.Command == null)
                    item.Command = new RelayCommand(TrackCommand);
            }
            LoadingTracks = false;
        }

        /// <summary>
        /// Albums Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlbumsCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (AlbumViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(AlbumCommand);
                    foreach (ArtistViewModel subitem in item?.Artists?.Items)
                    {
                        subitem.Command = new RelayCommand(ArtistCommand);
                    }
                }
            }
            LoadingAlbums = false;
        }

        /// <summary>
        /// Artists Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArtistsCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (ArtistViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                    item.Command = new RelayCommand(ArtistCommand);
            }
            LoadingArtists = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        /// <param name="id">Id</param>
        public ArtistPageViewModel(
            ISpotifySdkClient client,
            string id)
        {
            _client = client;
            Get(id);
            GetTracks(id);
            GetAlbums(id);
            GetArtists(id);
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}