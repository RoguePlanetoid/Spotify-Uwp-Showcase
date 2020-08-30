using Microsoft.Extensions.Configuration;
using Spotify.NetStandard.Sdk;
using System;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Spotify Sdk Singleton
    /// </summary>
    public class SpotifySdk
    {
        #region Private Members
        private IConfiguration _config;
        private static volatile SpotifySdk _instance;
        private static object _syncRoot = new object();
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Spotify Sdk Client
        /// </summary>
        public ISpotifySdkClient Client { get; private set; }
        #endregion Public Properties

        #region Singleton
        /// <summary>
        /// Init
        /// </summary>
        private async void Init()
        {
            _config = await Settings.GetAppSettings();
            Client = SpotifySdkClientFactory.CreateSpotifySdkClient(
                clientId: _config["client_id"],
                authorisationRedirectUri: new Uri(_config["redirect_uri"]),
                authorisationState: _config["state"]);
            Client.Config.AttachAll();
        }

        /// <summary>Constructor</summary>
        private SpotifySdk() => 
            Init();

        /// <summary>
        /// Spotify Sdk Client Instance
        /// </summary>
        public static SpotifySdk Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SpotifySdk();
                    }
                }
                return _instance;
            }
        }
        #endregion Singleton
    }
}