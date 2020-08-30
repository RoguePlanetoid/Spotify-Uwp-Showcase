using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Add Playlist View Model
    /// </summary>
    public class AddPlaylistViewModel : BaseNotifyPropertyChanged
    {
        #region Private Members
        private string _userId;
        private string _name;
        private string _description;
        private bool _isCollaborative;
        private bool _isPublic;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// User Id
        /// </summary>
        public string UserId
        {
            get => _userId;
            set { _userId = value; NotifyPropertyChanged(); }
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
        /// <param name="user">Playlist Response</param>
        public AddPlaylistViewModel(CurrentUserResponse user) => 
            UserId = user.Id;
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// To Set Playlist Request
        /// </summary>
        /// <returns></returns>
        public AddPlaylistRequest ToAddPlaylistRequest() =>
            new AddPlaylistRequest()
            {
                UserId = UserId,
                Name = string.IsNullOrEmpty(Name) ? null : Name,
                Description = string.IsNullOrEmpty(Description) ? null : Description,
                IsCollaborative = IsCollaborative,
                IsPublic = IsPublic
            };
        #endregion Public Methods
    }
}
