using Spotify.NetStandard.Sdk;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Base Page View Model
    /// </summary>
    public abstract class BasePageViewModel : BaseNotifyPropertyChanged, IDisposable
    {
        #region Private Members
        private bool _loading;
        private readonly MainPage _mainPage = (MainPage)((Frame)Window.Current.Content).Content;
        #endregion Private Members

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public BasePageViewModel(
            ISpotifySdkClient client) =>
            Client = client;
        #endregion Constructor

        #region Protected Methods
        /// <summary>
        /// Spotify Sdk Client
        /// </summary>
        public ISpotifySdkClient Client { get; protected set; }
        #endregion Protected Methods

        #region Public Properties
        /// <summary>
        /// Loading Indicator
        /// </summary>
        public bool Loading
        {
            get => _loading;
            set { _loading = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Public Methods
        /// <summary>
        /// Navigate Page
        /// </summary>
        /// <param name="tag">Navigate Tag</param>
        /// <param name="param">Navigate Parameter</param>
        /// <param name="related">Is Related?</param>
        public void NavigatePage(string tag, object param, bool related = false)
        {
            if (related)
                _mainPage.Item.NavigateRelated(tag, param);
            else
                _mainPage.Item.Navigate(tag, param);
        }

        /// <summary>
        /// Category Page Album
        /// </summary>
        /// <param name="response">Category Response</param>
        public void NavigatePage(CategoryResponse response) =>
            NavigatePage("category", response.Id);

        /// <summary>
        /// Navigate Page Album
        /// </summary>
        /// <param name="response">Album Response</param>
        public void NavigatePage(AlbumResponse response) =>
            NavigatePage("album", response.Id);

        /// <summary>
        /// Navigate Page Artist
        /// </summary>
        /// <param name="response">Artist Response</param>
        /// <param name="related">Is Related?</param>
        public void NavigatePage(ArtistResponse response, bool related = false) =>
            NavigatePage("artist", response.Id, related);

        /// <summary>
        /// Navigate Page Track
        /// </summary>
        /// <param name="response">Track Response</param>
        public void NavigatePage(TrackResponse response) =>
            NavigatePage("track", response.Id);

        /// <summary>
        /// Navigate Page Playlist
        /// </summary>
        /// <param name="response">Playlist Response</param>
        public void NavigatePage(PlaylistResponse response) =>
            NavigatePage("playlist", response.Id);

        /// <summary>
        /// Navigate Page Show
        /// </summary>
        /// <param name="response">Show Response</param>
        public void NavigatePage(ShowResponse response) =>
            NavigatePage("show", response.Id);

        /// <summary>
        /// Navigate Page Episode
        /// </summary>
        /// <param name="response">Episode Response</param>
        public void NavigatePage(EpisodeResponse response) =>
            NavigatePage("episode", response.Id);

        /// <summary>
        /// Navigate Page User
        /// </summary>
        /// <param name="response">User Response</param>
        public void NavigatePage(UserResponse response) =>
            NavigatePage("user", response.Id);

        /// <summary>
        /// Navigate Page Current User
        /// </summary>
        /// <param name="response">Current User Response</param>
        public void NavigatePage(CurrentUserResponse response) =>
            NavigatePage("currentuser", response.Id);

        /// <summary>
        /// Navigate Page Recommendation
        /// </summary>
        /// <param name="response">Recommendation Genre Response</param>
        public void NavigatePage(RecommendationGenreResponse response) =>
            NavigatePage("recommendation", response.Id);

        /// <summary>Dispose</summary>
        public void Dispose() =>
            Client = null;
        #endregion Public Methods
    }
}
