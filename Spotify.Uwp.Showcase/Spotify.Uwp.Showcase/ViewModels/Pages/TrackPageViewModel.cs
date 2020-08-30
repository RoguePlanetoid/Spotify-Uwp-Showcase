using System;
using Spotify.NetStandard.Sdk;
using Spotify.Uwp.Showcase.Dialogs;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Track Page View Model
    /// </summary>
    public class TrackPageViewModel : BaseItemViewModel<TrackResponse>
    {
        #region Private Methods
        /// <summary>
        /// Add Playlist Item
        /// </summary>
        /// <param name="response">Track or Episode</param>
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
        /// <param name="trackId">Spotify Track Id</param>
        public TrackPageViewModel(ISpotifySdkClient client, string trackId) :
            base(client, trackId) => 
            client.CommandActions.AddPlaylistItem = (item) => AddPlaylistItem(item);
        #endregion Constructor
    }
}