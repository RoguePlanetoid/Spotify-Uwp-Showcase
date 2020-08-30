using Spotify.NetStandard.Sdk;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Currently Playing Page View Model
    /// </summary>
    public class CurrentlyPlayingPageViewModel : BaseItemViewModel<CurrentlyPlayingResponse>
    {
        #region Private Members
        private DispatcherTimer _timer = null;
        #endregion Private Members

        #region Private Methods
        /// <summary>
        /// Get Currently Playing
        /// </summary>
        private void GetCurrentlyPlaying()
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                _timer.Tick += (object sender, object e) => Refresh();
                _timer.Start();
            }
        }

        /// <summary>
        /// User Playback Forward Handler
        /// </summary>
        /// <param name="response">Currently Playing Response</param>
        private async void UserPlaybackForwardHandler(CurrentlyPlayingResponse response)
        {
            int seek = (int)response.ProgressTimeSpan.Add(TimeSpan.FromSeconds(30)).TotalMilliseconds;
            await Client.SetUserPlaybackAsync(PlaybackType.Seek, option: seek);
        }

        /// <summary>
        /// User Playback Back Handler
        /// </summary>
        /// <param name="response">Currently Playing Response</param>
        private async void UserPlaybackBackHandler(CurrentlyPlayingResponse response)
        {
            int seek = (int)response.ProgressTimeSpan.Add(-TimeSpan.FromSeconds(10)).TotalMilliseconds;
            await Client.SetUserPlaybackAsync(PlaybackType.Seek, option: seek);
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Devices
        /// </summary>
        public ListDeviceViewModel Devices { get; private set; }

        /// <summary>
        /// User Playback Forward Command
        /// </summary>
        public ICommand UserPlaybackForwardCommand { get; private set; }

        /// <summary>
        /// User Playback Back Command
        /// </summary>
        public ICommand UserPlaybackBackCommand { get; private set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>Constructor</summary>
        /// <param name="client">Spotify Sdk Client</param>
        public CurrentlyPlayingPageViewModel(ISpotifySdkClient client) :
            base(client)
        {
            // Values
            Devices = new ListDeviceViewModel(client);
            // Events
            GetCurrentlyPlaying();
            // User Playback Forward
            UserPlaybackForwardCommand = 
                new GenericCommand<CurrentlyPlayingResponse>(UserPlaybackForwardHandler);
            // User Playback Back Forward
            UserPlaybackBackCommand =
                new GenericCommand<CurrentlyPlayingResponse>(UserPlaybackBackHandler);
        }
        #endregion Constructor
    }
}
