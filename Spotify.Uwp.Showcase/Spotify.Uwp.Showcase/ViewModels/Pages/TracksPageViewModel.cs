using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Tracks Page View Model
    /// </summary>
    public class TracksPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Saved Tracks
        /// </summary>
        public ListTrackViewModel Saved { get; private set; }

        /// <summary>
        /// Top Tracks
        /// </summary>
        public ListTrackViewModel Top { get; private set; }

        /// <summary>
        /// Recent Tracks
        /// </summary>
        public ListTrackViewModel Recent { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public TracksPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Saved = new ListTrackViewModel(client, TrackType.UserSaved);
            Top = new ListTrackViewModel(client, TrackType.UserTop);
            Recent = new ListTrackViewModel(client, TrackType.UserRecentlyPlayed);
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
            client.CommandActions.Track = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
