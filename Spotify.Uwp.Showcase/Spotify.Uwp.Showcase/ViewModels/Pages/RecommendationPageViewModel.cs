using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Recommendation Page View Model
    /// </summary>
    public class RecommendationPageViewModel : BasePageViewModel
    {
        #region Private Constants
        private const int max_recommendations = 100;
        #endregion Private Constants

        #region Public Properties
        /// <summary>
        /// Genre
        /// </summary>
        public string Item { get; private set; }

        /// <summary>
        /// Recommended Tracks
        /// </summary>
        public ListTrackViewModel Recommended { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="genre">Genre</param>
        public RecommendationPageViewModel(ISpotifySdkClient client, string genre) :
            base(client)
        {
            Item = genre;
            Recommended = new ListTrackViewModel(client, TrackType.Recommended, 
                recommendation: new RecommendationRequest()
                {
                    SeedGenre = genre,
                    TargetTotal = max_recommendations
                });
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
            client.CommandActions.Track = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
