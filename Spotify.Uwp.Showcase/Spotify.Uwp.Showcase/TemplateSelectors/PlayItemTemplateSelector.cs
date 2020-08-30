using Spotify.NetStandard.Sdk;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Play Item Template Selector
    /// </summary>
    public class PlayItemTemplateSelector : DataTemplateSelector
    {
        #region Public Properties
        /// <summary>
        /// Track Template 
        /// </summary>
        public DataTemplate PlayItemTrackTemplate { get; set; }

        /// <summary>
        /// Episode Template
        /// </summary>
        public DataTemplate PlayItemEpisodeTemplate { get; set; }
        #endregion Public Properties

        #region Protected Methods
        /// <summary>
        /// Select Template
        /// </summary>
        /// <param name="item">Object</param>
        /// <param name="container">Dependency Object</param>
        /// <returns></returns>
        protected override DataTemplate SelectTemplateCore(
            object item, DependencyObject container)
        {
            if (item is CurrentlyPlayingResponse response)
            {
                switch (response?.Current?.PlayItemType)
                {
                    case PlayItemType.Track:
                        return PlayItemTrackTemplate;
                    case PlayItemType.Episode:
                        return PlayItemEpisodeTemplate;
                }
            }
            return base.SelectTemplateCore(item, container);
        }
        #endregion Protected Methods
    }
}
