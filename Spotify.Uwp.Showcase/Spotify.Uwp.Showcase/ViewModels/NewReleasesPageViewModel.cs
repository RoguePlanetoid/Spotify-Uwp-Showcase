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
    /// New Releases Page View Model
    /// </summary>
    public class NewReleasesPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<AlbumViewModel> _collection = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Public Events

        #region Private Methods
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
            _main.Item.Navigate("artist", item.Id, item.Name);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        private void Get()
        {
            Collection = new ListAlbumViewModel(
                SpotifySdk.Instance.SpotifySdkClient,
                AlbumType.NewReleases, null);
            Collection.CollectionChanged += CollectionChanged;
            Loading = true;
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <param name="property"></param>
        private void NotifyPropertyChanged([CallerMemberName] string property = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        #endregion Private Methods

        #region Public Properties
        public ObservableCollection<AlbumViewModel> Collection
        {
            get => _collection;
            set { _collection = value; NotifyPropertyChanged(); }
        }

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
            foreach (AlbumViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(AlbumCommand);
                    if (item.Artists?.Items != null)
                    {
                        foreach (ArtistViewModel subitem in item.Artists.Items)
                        {
                            subitem.Command = new RelayCommand(ArtistCommand);
                        }
                    }
                }
            }
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public NewReleasesPageViewModel(
            ISpotifySdkClient client)
        {
            _client = client;
            Get();
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>Dispose</summary>
        public void Dispose() =>
            _client = null;
        #endregion Public Methods
    }
}