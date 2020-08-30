using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Category Page View Model
    /// </summary>
    public class CategoryPageViewModel : BaseItemViewModel<CategoryResponse>
    {
        #region Public Properties
        /// <summary>
        /// Category
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="categoryId">Spotify Category Id</param>
        /// <param name="client">Spotify Sdk Client</param>
        public CategoryPageViewModel(ISpotifySdkClient client, string categoryId) :
            base(client, categoryId)
        {
            Playlists = new ListPlaylistViewModel(client, PlaylistType.Category, categoryId);
            // Commands
            client.CommandActions.Playlist = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}