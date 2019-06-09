using Microsoft.Extensions.Configuration;
using Spotify.Uwp.Showcase.Classes;
using System;

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
        public ISpotifySdkClient SpotifySdkClient { get; private set; }
        #endregion Public Properties

        #region Singleton
        private object _lock = new object();

        private static volatile SpotifySdk instance;
        private static object syncRoot = new object();

        /// <summary>
        /// Init
        /// </summary>
        private async void Init()
        {
            _config = await Configuration.GetConfig();
            SpotifySdkClient = SpotifySdkClientFactory.CreateSpotifySdkClient(
                clientId: _config["client_id"], 
                loginRedirectUri: new Uri(_config["redirect_uri"]),
                loginState: _config["state"]);
        } 

        /// <summary>Constructor</summary>
        private SpotifySdk()
        {
            Init();
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
