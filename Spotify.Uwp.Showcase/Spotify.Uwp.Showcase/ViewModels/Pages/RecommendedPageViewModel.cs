using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Recommended Page View Model
    /// </summary>
    public class RecommendedPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Genres
        /// </summary>
        public ListRecommendationGenreViewModel Genres { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public RecommendedPageViewModel(ISpotifySdkClient client) 
            : base(client)
        {
            // Tracks
            Genres = new ListRecommendationGenreViewModel(client);
            // Command Actions
            client.CommandActions.RecommendationGenre = (item) => NavigatePage(item);
            client.CommandActions.Track = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}