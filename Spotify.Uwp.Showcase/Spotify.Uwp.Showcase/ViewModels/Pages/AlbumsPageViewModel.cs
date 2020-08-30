using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Albums Page View Model
    /// </summary>
    public class AlbumsPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Saved
        /// </summary>
        public ListAlbumViewModel Saved { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public AlbumsPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Saved = new ListAlbumViewModel(client, AlbumType.UserSaved);
            // Commands
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
