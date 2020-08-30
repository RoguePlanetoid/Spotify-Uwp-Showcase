using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Show Page View Model
    /// </summary>
    public class ShowPageViewModel : BaseItemViewModel<ShowResponse>
    {
        #region Public Properties
        /// <summary>
        /// Episodes
        /// </summary>
        public ListEpisodeViewModel Episodes { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="showId">Spotify Show Id</param>
        public ShowPageViewModel(ISpotifySdkClient client, string showId) :
            base(client, showId)
        {
            // Tracks
            Episodes = new ListEpisodeViewModel(client, EpisodeType.Show, showId);
            // Command Actions
            client.CommandActions.Episode = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}