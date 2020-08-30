using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Settings
    /// </summary>
    public static class Settings
    {
        #region Private Constants
        private const string app_settings = "appsettings.json";
        #endregion Private Constants

        #region Public Methods
        /// <summary>
        /// Get Appx Json
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Settings JSON</returns>
        public static async Task<string> GetAppxJson(string filename)
        {
            var settingsFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(filename);
            var settingsJson = await FileIO.ReadTextAsync(settingsFile);
            return settingsJson;
        }

        /// <summary>
        /// Add Json
        /// </summary>
        /// <param name="configurationBuilder">Configuration Builder</param>
        /// <param name="filename">Filename</param>
        /// <param name="settingsJson">Settings JSON</param>
        /// <returns>Configuration Builder</returns>
        public static IConfigurationBuilder AddJson(this IConfigurationBuilder configurationBuilder, string filename, string settingsJson) =>
            configurationBuilder.AddJsonFile(new FileProvider(
                new FileInfo(filename, Encoding.UTF8.GetBytes(settingsJson), DateTimeOffset.Now)),
                filename, optional: false, reloadOnChange: false);

        /// <summary>
        /// Get App Settings
        /// </summary>
        /// <returns>IConfiguration</returns>
        public static async Task<IConfiguration> GetAppSettings() => new ConfigurationBuilder()
            .AddJson(app_settings, await GetAppxJson(app_settings)).Build();
        #endregion Public Methods
    }
}
