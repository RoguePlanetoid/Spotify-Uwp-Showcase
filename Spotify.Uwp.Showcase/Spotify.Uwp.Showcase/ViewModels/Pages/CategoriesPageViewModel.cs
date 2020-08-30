using Spotify.NetStandard.Sdk;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Categories Page View Model
    /// </summary>
    public class CategoriesPageViewModel : BasePageViewModel
    {
        #region Public Properties
        /// <summary>
        /// Saved
        /// </summary>
        public ListCategoryViewModel Categories { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public CategoriesPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            Categories = new ListCategoryViewModel(client);
            // Commands
            client.CommandActions.Category = (item) => NavigatePage(item);
        }
        #endregion Constructor
    }
}