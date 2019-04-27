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
    public class RecommendationPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<TrackViewModel> _collection = null;
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
        /// Get
        /// </summary>
        /// <param name="id"></param>
        private void Get(string id)
        {
            Collection = new ListTrackViewModel(
                SpotifySdk.Instance.SpotifySdkClient,
                TrackType.Recommended, id);
            Collection.CollectionChanged += GetCollectionChanged;
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
        #endregion Public Properties

        #region Event Handlers
        /// <summary>
        /// Collection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            foreach (TrackViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                {
                    item.Command = new RelayCommand(TrackCommand);
                }
            }
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public RecommendationPageViewModel(
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