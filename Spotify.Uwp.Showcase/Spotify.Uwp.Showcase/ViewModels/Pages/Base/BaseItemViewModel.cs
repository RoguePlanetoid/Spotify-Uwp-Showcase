using Spotify.NetStandard.Sdk;
using System.Threading.Tasks;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Base Item Page View Model
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class BaseItemViewModel<TResponse> : BasePageViewModel
        where TResponse : class
    {
        #region Private Members
        private readonly string _id = null;
        private TResponse _item = default;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Get Item Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Task<TResponse> GetItemAsync(string id = null) => 
            Client.GetAsync<TResponse>(id);

        /// <summary>
        /// Get
        /// </summary>
        private async void Get(string id = null)
        {
            Loading = true;
            Item = await GetItemAsync(id);
            Loading = false;
        }
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify SDK Client</param>
        /// <param name="id">Spotify Item Id</param>
        public BaseItemViewModel(
            ISpotifySdkClient client,
            string id = null) :
            base(client)
        {
            _id = id;
            Get(_id);
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Refresh
        /// </summary>
        public void Refresh()
        {
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