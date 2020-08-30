using Spotify.NetStandard.Sdk;
using System;
using System.IO;
using Windows.Storage.Pickers;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Set Playlist Image Dialog View Model
    /// </summary>
    public class SetPlaylistImageDialogViewModel : BaseItemDialogViewModel<PlaylistImageResponse, StatusResponse>
    {
        #region Private Methods
        /// <summary>
        /// Set Playlist Image
        /// </summary>
        /// <param name="response">Playlist Image Response</param>
        private async void SetPlaylistImage(PlaylistImageResponse response)
        {
            try
            {
                var picker = new FileOpenPicker
                {
                    SuggestedStartLocation = PickerLocationId.PicturesLibrary
                };
                picker.FileTypeFilter.Add(".jpg");
                var file = await picker.PickSingleFileAsync();
                if (file != null)
                {
                    var stream = await file.OpenStreamForReadAsync();
                    var bytes = new byte[(int)stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    Result = await Client.SetPlaylistImageAsync(response.Id, bytes);
                    if(Result.IsSuccess)
                        Refresh();
                }
            }
            catch
            {

            }
        }
        #endregion Private Methods

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        /// <param name="response">Playlist Response</param>
        public SetPlaylistImageDialogViewModel(ISpotifySdkClient client, PlaylistResponse response) :
            base(client, response?.Id)
        {
            // Commands
            client.CommandActions.GetPlaylistImage = (item) => SetPlaylistImage(item); 
        }
        #endregion Constructor
    }
}
