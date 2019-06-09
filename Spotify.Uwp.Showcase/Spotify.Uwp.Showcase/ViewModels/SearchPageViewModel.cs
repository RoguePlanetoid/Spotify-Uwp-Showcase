using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// Search Page View Model
    /// </summary>
    public class SearchPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loadingTracks;
        private bool _loadingAlbums;
        private bool _loadingArtists;
        private bool _loadingPlaylists;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<TrackViewModel> _tracks = null;
        private ObservableCollection<AlbumViewModel> _albums = null;
        private ObservableCollection<ArtistViewModel> _artists = null;
        private ObservableCollection<PlaylistViewModel> _playlists = null;
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
        /// Playlist Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void PlaylistCommand(object parameter)
        {
            var item = (PlaylistViewModel)parameter;
            _main.Item.Navigate("album", item.Id, item.Name);
        }

        /// <summary>
        /// Get Tracks
        /// </summary>
        /// <param name="query">Query</param>
        private void GetTracks(string query)
        {
            Tracks = new ListTrackViewModel(
                _client, TrackType.Search, query);
            Tracks.CollectionChanged += TracksCollectionChanged;
            LoadingTracks = true;
        }

        /// <summary>
        /// Get Artists
        /// </summary>
        /// <param name="query">Query</param>
        private void GetArtists(string query)
        {
            Artists = new ListArtistViewModel(
                _client, ArtistType.Search, query);
            Artists.CollectionChanged += ArtistsCollectionChanged;
            LoadingArtists = true;
        }

        /// <summary>
        /// Get Albums
        /// </summary>
        /// <param name="query"></param>
        private void GetAlbums(string query)
        {
            Albums = new ListAlbumViewModel(
                _client, AlbumType.Search, query);
            Albums.CollectionChanged += AlbumsCollectionChanged;
            LoadingAlbums = true;
        }

        /// <summary>
        /// Get Playlists
        /// </summary>
        /// <param name="query">Query</param>
        private void GetPlaylists(string query)
        {
            Playlists = new ListPlaylistViewModel(
                _client, PlaylistType.Search, query);
            Playlists.CollectionChanged += PlaylistsCollectionChanged;
            LoadingPlaylists = true;
        }
        #endregion Private Methods

        #region Public Properties
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
        /// Observable Collection of Playlist View Model
        /// </summary>
        public ObservableCollection<PlaylistViewModel> Playlists
        {
            get => _playlists;
            set { _playlists = value; NotifyPropertyChanged(); }
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
        /// Loading Playlists Indicator
        /// </summary>
        public bool LoadingPlaylists
        {
            get => _loadingPlaylists;
            set { _loadingPlaylists = value; NotifyPropertyChanged(); }
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

        /// <summary>
        /// Playlists Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaylistsCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (PlaylistViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                    item.Command = new RelayCommand(PlaylistCommand);
            }
            LoadingArtists = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        /// <param name="query">Query</param>
        public SearchPageViewModel(
            ISpotifySdkClient client,
            string query)
        {
            _client = client;
            GetTracks(query);
            GetArtists(query);
            GetAlbums(query);
            GetPlaylists(query);
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}
