using Spotify.NetStandard.Sdk;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Playlist Item Template Selector 
    /// </summary>
    public class PlaylistItemTemplateSelector : DataTemplateSelector
    {
        #region Public Properties
        /// <summary>
        /// Track Template 
        /// </summary>
        public DataTemplate PlaylistItemTrackTemplate { get; set; }

        /// <summary>
        /// Episode Template
        /// </summary>
        public DataTemplate PlaylistItemEpisodeTemplate { get; set; }
        #endregion Public Properties

        #region Protected Methods
        /// <summary>
        /// Select Template
        /// </summary>
        /// <param name="item">Object</param>
        /// <param name="container">Dependency Object</param>
        /// <returns>Data Template</returns>
        protected override DataTemplate SelectTemplateCore(
            object item, DependencyObject container)
        {
            var response = item as IPlaylistItemResponse;
            switch(response.PlayItemType)
            {
                case PlayItemType.Track:
                    return PlaylistItemTrackTemplate;
                case PlayItemType.Episode:
                    return PlaylistItemEpisodeTemplate;
            }
            return base.SelectTemplateCore(item, container);
        }
        #endregion Protected Methods
    }
}
