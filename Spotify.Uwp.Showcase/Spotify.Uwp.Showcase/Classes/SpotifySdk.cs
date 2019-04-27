using Microsoft.Extensions.Configuration;
using Spotify.Uwp.Showcase.Classes;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Spotify
    /// </summary>
    public class SpotifySdk
    {
        #region Private Members
        private IConfiguration _config;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Spotify SDK Client
        /// </summary>
        public ISpotifySdkClient SpotifySdkClient { get; }
        #endregion Public Properties

        #region Singleton
        private object _lock = new object();

        private static volatile SpotifySdk instance;
        private static object syncRoot = new object();

        private async void Init() => 
            _config = await Configuration.GetConfig();

        /// <summary>Constructor</summary>
        private SpotifySdk()
        {
            Init();
            SpotifySdkClient = SpotifySdkClientFactory.CreateSpotifySdkClient(
                _config["client_id"], _config["client_secret"]);
        }

        public static SpotifySdk Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SpotifySdk();
                    }
                }
                return instance;
            }
        }
        #endregion Singleton
    }
}
