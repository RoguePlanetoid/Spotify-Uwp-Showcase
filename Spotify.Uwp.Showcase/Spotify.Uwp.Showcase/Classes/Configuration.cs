using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Spotify.Uwp.Showcase.Classes
{
    public static class Configuration
    {
        private const string app_settings = "appsettings.json";

        public static async Task<string> GetAppxJson(string filename)
        {
            var settingsFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(filename);
            var settingsJson = await FileIO.ReadTextAsync(settingsFile);
            return settingsJson;
        }

        public static IConfigurationBuilder AddJson(this IConfigurationBuilder configurationBuilder, string filename, string settingsJson) => 
            configurationBuilder.AddJsonFile(new FileProvider(
                new FileInfo(filename, Encoding.UTF8.GetBytes(settingsJson), DateTimeOffset.Now)),
                filename, optional: false, reloadOnChange: false);

        public static async Task<IConfiguration> GetConfig() => new ConfigurationBuilder()
            .AddJson(app_settings, await GetAppxJson(app_settings)).Build();
    }
}
