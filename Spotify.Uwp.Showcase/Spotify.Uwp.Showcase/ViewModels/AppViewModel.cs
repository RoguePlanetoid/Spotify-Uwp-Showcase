using Spotify.Uwp.ViewModels;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Spotify.Uwp.Showcase.ViewModels
{
    public class AppViewModel
    {
        #region Private Constants
        private const string filename_token = "token.json";
        private const string filename_favourites = "favourite.json";
        #endregion Private Constants

        #region Private Members
        private ISpotifySdkClient _client = null;
        private readonly StorageFolder _folder = ApplicationData.Current.LocalFolder;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Export
        /// </summary>
        /// <returns>JSON</returns>
        private string Export<TViewModel>(TViewModel source)
            where TViewModel : class
        {
            var result = string.Empty;
            using (var stream = new MemoryStream())
            {
                var serialiser = new DataContractJsonSerializer(typeof(TViewModel));
                serialiser.WriteObject(stream, source);
                result = Encoding.UTF8.GetString(stream.ToArray());
            }
            return result;
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="source">JSON</param>
        public TViewModel Import<TViewModel>(string source) 
            where TViewModel : class
        {
            TViewModel result = default;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(source)))
            {
                var serialiser = new DataContractJsonSerializer(typeof(TViewModel));
                result = serialiser.ReadObject(stream) as TViewModel;
            }
            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel Type</typeparam>
        /// <param name="source">Source ViewModel</param>
        /// <param name="filename">Filename</param>
        /// <returns>True on Success, False if Not</returns>
        private async Task<bool> Save<TViewModel>(TViewModel source, string filename) 
            where TViewModel : class
        {
            try
            {
                var contents = Export(source);
                var file = await _folder.CreateFileAsync(filename,
                    CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(file, contents);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel Type</typeparam>
        /// <param name="filename">Filename</param>
        /// <returns>Result ViewModel</returns>
        private async Task<TViewModel> Load<TViewModel>(string filename)
            where TViewModel : class
        {
            try
            {
                var file = await _folder.GetFileAsync(filename);
                var contents = await FileIO.ReadTextAsync(file);
                return Import<TViewModel>(contents);
            }
            catch(Exception)
            {
                return null;
            }
        }
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Music Client</param>
        public AppViewModel(
            ISpotifySdkClient client) => 
            _client = client;
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Start Application
        /// </summary>
        public async void Start()
        {
            _client.Token = 
                await Load<TokenViewModel>(filename_token) ?? null;
            _client.Favourites =
                await Load<ListFavouriteViewModel>(filename_favourites) ?? null;
            _client.Favourites = _client.Favourites ?? new ListFavouriteViewModel();
        }

        /// <summary>
        /// Finish Application
        /// </summary>
        public async void Finish()
        {
            await Save(_client.Token, filename_token);
            await Save(_client.Favourites, filename_favourites);
        }
        #endregion Public Methods
    }
}
