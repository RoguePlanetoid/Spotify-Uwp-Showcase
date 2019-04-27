﻿using Spotify.Uwp.ViewModels;
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
    /// Album Page View Model
    /// </summary>
    public class AlbumPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private AlbumViewModel _item = null;
        private ObservableCollection<TrackViewModel> _collection = null;
        private ToggleFavouriteViewModel _toggleFavourite = null;
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
        /// Get
        /// </summary>
        /// <param name="id"></param>
        private async void Get(string id)
        {
            Set(id);
            Item = await _client.GetAlbum(id);
            if(Item?.Artist != null)
                Item.Artist.Command = new RelayCommand(ArtistCommand);
            Collection = new ListTrackViewModel(
                _client, TrackType.Album,
                id: id);
            Collection.CollectionChanged += CollectionChanged;
            Loading = true;
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="id"></param>
        private void Set(string id)
        {
            ToggleFavourite = new ToggleFavouriteViewModel()
            {
                Id = id,
                Value = _client.Favourites.Contains(FavouriteType.Album, id),
                Command = new RelayCommand(ToggleFavouriteCommand)
            };
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <param name="property"></param>
        private void NotifyPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        #endregion Private Methods

        #region Public Properties
        public AlbumViewModel Item
        {
            get => _item;
            set { _item = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<TrackViewModel> Collection
        {
            get => _collection;
            set { _collection = value; NotifyPropertyChanged(); }
        }

        public bool Loading
        {
            get => _loading;
            set { _loading = value; NotifyPropertyChanged(); }
        }

        public ToggleFavouriteViewModel ToggleFavourite
        {
            get => _toggleFavourite;
            set { _toggleFavourite = value; NotifyPropertyChanged(); }
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
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public AlbumPageViewModel(
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