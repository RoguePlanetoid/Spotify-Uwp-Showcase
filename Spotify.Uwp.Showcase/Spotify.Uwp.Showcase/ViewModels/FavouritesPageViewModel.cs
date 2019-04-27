using Spotify.Uwp;
using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// Favourites Page View Model
    /// </summary>
    public class FavouritesPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loadingTracks;
        private bool _loadingAlbums;
        private bool _loadingArtists;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<TrackViewModel> _tracks = null;
        private ObservableCollection<AlbumViewModel> _albums = null;
        private ObservableCollection<ArtistViewModel> _artists = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Public Events

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
        private void GetTracks()
        {
            if (_client.Favourites.Any(FavouriteType.Track))
            {
                Tracks = new ListTrackViewModel(
                    _client, TrackType.Favourites, null);
                Tracks.CollectionChanged += TracksCollectionChanged;
                LoadingTracks = true;
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        private void GetArtists()
        {
            if (_client.Favourites.Any(FavouriteType.Artist))
            {
                Artists = new ListArtistViewModel(
                _client, ArtistType.Favourites, null);
                Artists.CollectionChanged += ArtistsCollectionChanged;
                LoadingArtists = true;
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        private void GetAlbums()
        {
            if (_client.Favourites.Any(FavouriteType.Album))
            {
                Albums = new ListAlbumViewModel(
                _client, AlbumType.Favourites, null);
                Albums.CollectionChanged += AlbumsCollectionChanged;
                LoadingAlbums = true;
            }
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <param name="property"></param>
        private void NotifyPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        #endregion Private Methods

        #region Public Properties
        public ObservableCollection<TrackViewModel> Tracks
        {
            get => _tracks;
            set { _tracks = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<ArtistViewModel> Artists
        {
            get => _artists;
            set { _artists = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<AlbumViewModel> Albums
        {
            get => _albums;
            set { _albums = value; NotifyPropertyChanged(); }
        }

        public bool LoadingTracks
        {
            get => _loadingTracks;
            set { _loadingTracks = value; NotifyPropertyChanged(); }
        }

        public bool LoadingArtists
        {
            get => _loadingArtists;
            set { _loadingArtists = value; NotifyPropertyChanged(); }
        }

        public bool LoadingAlbums
        {
            get => _loadingAlbums;
            set { _loadingAlbums = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Event Handlers
        /// <summary>
        /// Collection Changed
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
        /// Collection Changed
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
        /// Collection Changed
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
        public FavouritesPageViewModel(
            ISpotifySdkClient client)
        {
            _client = client;
            GetTracks();
            GetArtists();
            GetAlbums();
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}
