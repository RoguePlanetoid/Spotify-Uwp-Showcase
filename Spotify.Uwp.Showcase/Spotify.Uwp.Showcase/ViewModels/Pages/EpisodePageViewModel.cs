using Spotify.NetStandard.Sdk;
using Spotify.Uwp.Showcase.Dialogs;
using System;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Episode Page View Model
    /// </summary>
    public class EpisodePageViewModel : BaseItemViewModel<EpisodeResponse>
    {
        #region Private Methods
        /// <summary>
        /// Add Playlist Item
        /// </summary>
        /// <param name="response">Episode</param>
        private async void AddPlaylistItem(IPlayItemResponse response)
        {
            var dialog = new AddPlaylistItemDialog(response);
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary &&
                dialog.AddPlaylistItem.Result.IsSuccess)
                NavigatePage(dialog.AddPlaylistItem.Playlist);
        }
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="episodeId">Spotify Episode Id</param>
        public EpisodePageViewModel(ISpotifySdkClient client, string episodeId) :
            base(client, episodeId) => 
            client.CommandActions.AddPlaylistItem = (item) => AddPlaylistItem(item);
        #endregion Constructor
    }
}