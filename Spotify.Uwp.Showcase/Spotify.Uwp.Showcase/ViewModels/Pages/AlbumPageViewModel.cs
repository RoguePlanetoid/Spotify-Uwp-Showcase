using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Album Page View Model
    /// </summary>
    public class AlbumPageViewModel : BaseItemViewModel<AlbumResponse>
    {
        #region Public Properties
        /// <summary>
        /// Tracks
        /// </summary>
        public ListTrackViewModel Tracks { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="albumId">Spotify Album Id</param>
        public AlbumPageViewModel(ISpotifySdkClient client, string albumId) : 
            base(client, albumId) 
        {
            // Tracks
            Tracks = new ListTrackViewModel(client, TrackType.Album, albumId);
            // Commands
            client.CommandActions.Track = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}