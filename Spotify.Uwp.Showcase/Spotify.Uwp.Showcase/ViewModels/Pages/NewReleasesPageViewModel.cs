using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// New Releases Page View Model
    /// </summary>
    public class NewReleasesPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// New Releases
        /// </summary>
        public ListAlbumViewModel NewReleases { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public NewReleasesPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            NewReleases = new ListAlbumViewModel(client, AlbumType.NewReleases);
            // Command Actions
            client.CommandActions.Album = (item) => NavigatePage(item);
            client.CommandActions.Artist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}