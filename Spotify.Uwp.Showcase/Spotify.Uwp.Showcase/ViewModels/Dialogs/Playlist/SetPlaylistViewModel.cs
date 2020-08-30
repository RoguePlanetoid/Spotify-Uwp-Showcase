using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Set Playlist View Model
    /// </summary>
    public class SetPlaylistViewModel : BaseNotifyPropertyChanged
    {
        #region Private Members
        private string _playlistId;
        private string _name;
        private string _description;
        private bool _isCollaborative;
        private bool _isPublic;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Playlist Id
        /// </summary>
        public string PlaylistId
        {
            get => _playlistId;
            set { _playlistId = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get => _name;
            set { _name = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get => _description;
            set { _description = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Is Collaborative
        /// </summary>
        public bool IsCollaborative
        {
            get => _isCollaborative;
            set { _isCollaborative = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Is Public
        /// </summary>
        public bool IsPublic
        {
            get => _isPublic;
            set { _isPublic = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Playlist Details View Model
        /// </summary>
        /// <param name="playlist">Playlist Response</param>
        public SetPlaylistViewModel(PlaylistResponse playlist)
        {
            PlaylistId = playlist.Id;
            Name = playlist.Name;
            Description = playlist.Description;
            IsCollaborative = playlist.Collaborative;
            IsPublic = playlist.Public ?? false;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// To Set Playlist Request
        /// </summary>
        /// <returns></returns>
        public SetPlaylistRequest ToSetPlaylistRequest() =>
            new SetPlaylistRequest()
            {
                PlaylistId = PlaylistId,
                Name = string.IsNullOrEmpty(Name) ? null : Name,
                Description = string.IsNullOrEmpty(Description) ? null : Description,
                IsCollaborative = IsCollaborative,
                IsPublic = IsPublic
            };
        #endregion Public Methods
    }
}
