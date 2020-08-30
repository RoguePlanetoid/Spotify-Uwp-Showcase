using Spotify.NetStandard.Sdk;
using System.Threading.Tasks;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Base Item Dialog View Model
    /// </summary>
    public abstract class BaseItemDialogViewModel<TResponse, TResult> : BaseDialogViewModel<TResult>
        where TResponse : class
        where TResult : class
    {
        #region Private Members
        private readonly string _id = null;
        private TResponse _item = default;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Get Item Async
        /// </summary>
        /// <param name="id">Id (Optional)</param>
        /// <returns>Response</returns>
        private Task<TResponse> GetItemAsync(string id = null) =>
            Client.GetAsync<TResponse>(id);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">Id (Optional)</param>
        private async void Get(string id = null)
        {
            Loading = true;
            Item = await GetItemAsync(id);
            Loading = false;
        }
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="id">Spotify Item Id</param>
        public BaseItemDialogViewModel(
            ISpotifySdkClient client,
            string id = null) :
            base(client)
        {
            _id = id;
            Get(_id);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        public BaseItemDialogViewModel(
            ISpotifySdkClient client,
            TResponse response) :
            base(client) =>
            Item = response;
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Refresh
        /// </summary>
        public void Refresh()
        {
            if (Item != null)
                Get(_id);
        }
        #endregion Public Methods

        #region Public Properties
        /// <summary>
        /// Item Response
        /// </summary>
        public TResponse Item
        {
            get => _item;
            set { _item = value; NotifyPropertyChanged(); }
        }
        #endregion Public Properties
    }
}
