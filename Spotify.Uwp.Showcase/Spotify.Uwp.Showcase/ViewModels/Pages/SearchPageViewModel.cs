using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Search Page View Model
    /// </summary>
    public class SearchPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Albums
        /// </summary>
        public ListAlbumViewModel Albums { get; private set; }

        /// <summary>
        /// Tracks
        /// </summary>
        public ListTrackViewModel Tracks { get; private set; }

        /// <summary>
        /// Artists
        /// </summary>
        public ListArtistViewModel Artists { get; private set; }

        /// <summary>
        /// Playlists
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }

        /// <summary>
        /// Shows
        /// </summary>
        public ListShowViewModel Shows { get; private set; }

        /// <summary>
        /// Episodes
        /// </summary>
        public ListEpisodeViewModel Episodes { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="value">Search Term</param>
        public SearchPageViewModel(ISpotifySdkClient client, string value) : base(client)
        {
            // Albums
            Albums = new ListAlbumViewModel(client, AlbumType.Search, value);
            // Tracks
            Tracks = new ListTrackViewModel(client, TrackType.Search, value);
            // Artists
            Artists = new ListArtistViewModel(client, ArtistType.Search, value);
            // Playlists
            Playlists = new ListPlaylistViewModel(client, PlaylistType.Search, value);
            // Shows
            Shows = new ListShowViewModel(client, ShowType.Search, value);
            // Episodes
            Episodes = new ListEpisodeViewModel(client, EpisodeType.Search, value);
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
            client.CommandActions.Track = (item) => NavigatePage(item);
            client.CommandActions.Playlist = (item) => NavigatePage(item);
            client.CommandActions.Show = (item) => NavigatePage(item);
            client.CommandActions.Episode = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
