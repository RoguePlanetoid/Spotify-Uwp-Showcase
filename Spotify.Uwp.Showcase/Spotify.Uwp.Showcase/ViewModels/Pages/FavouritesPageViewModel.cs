using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Favourites Page View Model
    /// </summary>
    public class FavouritesPageViewModel : BasePageViewModel
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
        public FavouritesPageViewModel(ISpotifySdkClient client) : base(client)
        {
            // Albums
            Albums = new ListAlbumViewModel(client, AlbumType.Favourite);
            // Tracks
            Tracks = new ListTrackViewModel(client, TrackType.Favourite);
            // Artists
            Artists = new ListArtistViewModel(client, ArtistType.Favourite);
            // Shows
            Shows = new ListShowViewModel(client, ShowType.Favourite);
            // Episodes
            Episodes = new ListEpisodeViewModel(client, EpisodeType.Favourite); 
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
            client.CommandActions.Playlist = (item) => NavigatePage(item);
            client.CommandActions.Show = (item) => NavigatePage(item);
            client.CommandActions.Episode = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}