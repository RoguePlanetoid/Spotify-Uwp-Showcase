using Spotify.Uwp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase.ViewModels
{
    /// <summary>
    /// Category Page View Model
    /// </summary>
    public class CategoryPageViewModel : BasePageViewModel, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private CategoryViewModel _item = null;
        private ObservableCollection<PlaylistViewModel> _collection = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Playlist Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void PlaylistCommand(object parameter)
        {
            var item = (PlaylistViewModel)parameter;
            _main.Item.Navigate("playlist", item.Id, item.Name);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">Id</param>
        private async void Get(string id)
        {
            Item = await _client.GetCategoryAsync(id);
            Collection = new ListPlaylistViewModel(
                _client, PlaylistType.CategoriesPlaylists, 
                id: Item.Id);
            Collection.CollectionChanged += CollectionChanged;
            Loading = true;
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Category View Model
        /// </summary>
        public CategoryViewModel Item
        {
            get => _item;
            set { _item = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Observable Collection of Playlist View Model
        /// </summary>
        public ObservableCollection<PlaylistViewModel> Collection
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
            foreach (PlaylistViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                    item.Command = new RelayCommand(PlaylistCommand);
            }
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public CategoryPageViewModel(
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