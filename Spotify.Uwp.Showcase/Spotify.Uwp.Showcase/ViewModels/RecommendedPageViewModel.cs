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
    public class RecommendedPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loading;
        private ISpotifySdkClient _client = null;
        private ObservableCollection<RecommendationViewModel> _collection = null;
        private readonly MainPage _main = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Public Events

        #region Private Methods
        /// <summary>
        /// Command
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private void Command(object parameter)
        {
            var item = (RecommendationViewModel)parameter;
            _main.Item.Navigate("recommendation", item.Id, item.Name);
        }

        /// <summary>
        /// Get
        /// </summary>
        private void Get()
        {
            Collection = new ListRecommendationViewModel(_client);
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
        public ObservableCollection<RecommendationViewModel> Collection
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
            foreach (RecommendationViewModel item in e.NewItems)
            {
                if (item != null && item.Command == null)
                    item.Command = new RelayCommand(Command);
            }
            Loading = false;
        }
        #endregion Event Handlers

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public RecommendedPageViewModel(
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