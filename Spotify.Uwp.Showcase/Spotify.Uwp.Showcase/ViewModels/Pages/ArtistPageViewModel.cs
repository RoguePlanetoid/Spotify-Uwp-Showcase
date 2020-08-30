using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Artist Page View Model
    /// </summary>
    public class ArtistPageViewModel : BaseItemViewModel<ArtistResponse>
    {
        #region Public Properties
        /// <summary>
        /// Albums
        /// </summary>
        public ListAlbumViewModel Albums { get; private set; }

        /// <summary>
        /// Top Tracks
        /// </summary>
        public ListTrackViewModel Tracks { get; private set; }

        /// <summary>
        /// Related Artists
        /// </summary>
        public ListArtistViewModel Artists { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="artistId">Spotify Artist Id</param>
        public ArtistPageViewModel(
            ISpotifySdkClient client,
            string artistId) : base(client, artistId) 
        {
            // Albums
            Albums = new ListAlbumViewModel(client, AlbumType.Artist, artistId);
            // Tracks
            Tracks = new ListTrackViewModel(client, TrackType.Artist, artistId);
            // Artists
            Artists = new ListArtistViewModel(client, ArtistType.Related, artistId);
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Track = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item, true);
        }
        #endregion Constructor
    }
}
