using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Add Playlist Item Dialog View Model
    /// </summary>
    public class AddPlaylistItemDialogViewModel : BaseDialogViewModel<SnapshotResponse>
    {
        #region Private Methods
        /// <summary>
        /// Add Playlist Item
        /// </summary>
        /// <param name="playItem">Track or Episode</param>
        private async void AddPlaylistItem(IPlayItemResponse playItem) =>
            Result = await Client.AddPlaylistItemAsync(Playlist.Id, playItem.PlayItemType, playItem.Id);
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="playItem">Spotify Track or Episode</param>
        public AddPlaylistItemDialogViewModel(ISpotifySdkClient client, 
            IPlayItemResponse playItem) :
            base(client)
        {
            PlayItem = playItem;
            Playlists = new ListPlaylistViewModel(client, PlaylistType.CurrentUserAddable);
            // Commands
            PrimaryCommand = new GenericCommand<IPlayItemResponse>(AddPlaylistItem);
        }
        #endregion Constructor

        #region Public Properties
        /// <summary>
        /// Play Item
        /// </summary>
        public IPlayItemResponse PlayItem { get; private set; }

        /// <summary>
        /// Playlists
        /// </summary>
        public ListPlaylistViewModel Playlists { get; private set; }

        /// <summary>
        /// Playlist
        /// </summary>
        public PlaylistResponse Playlist { get; set; }
        #endregion Public Properties
    }
}
