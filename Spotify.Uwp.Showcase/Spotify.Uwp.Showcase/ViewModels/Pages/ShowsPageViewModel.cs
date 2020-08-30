using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Shows Page View Model
    /// </summary>
    public class ShowsPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Saved
        /// </summary>
        public ListShowViewModel Saved { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public ShowsPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Saved = new ListShowViewModel(client, ShowType.UserSaved);
            // Command Actions
            client.CommandActions.Show = (item) => NavigatePage(item);
            client.CommandActions.Episode = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}
