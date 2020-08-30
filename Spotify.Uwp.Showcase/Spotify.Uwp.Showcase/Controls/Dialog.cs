using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Dialog
    /// </summary>
    public class Dialog
    {
        #region Private Members
        private IAsyncOperation<IUICommand> _dialogCommand;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Show
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="title">Title</param>
        /// <returns>True When Closed, False if Cancelled</returns>
        public async Task<bool> ShowAsync(string content, string title)
        {

            try
            {
                if (_dialogCommand != null)
                {
                    _dialogCommand.Cancel();
                    _dialogCommand = null;
                }
                _dialogCommand = new MessageDialog(content, title).ShowAsync();
                await _dialogCommand;
                return true;
            }
            catch (TaskCanceledException)
            {
                return false;
            }
        }
        #endregion Public Properties
    }
}