using Spotify.NetStandard.Sdk;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// Favourites
    /// </summary>
    [DataContract(Name = "favourites")]
    public class Favourites : IFavourites
    {
        #region Public Properties
        /// <summary>
        /// Album Spotify Ids
        /// </summary>
        [DataMember(Name = "albums")]
        public List<string> AlbumIds { get; set; }

        /// <summary>
        /// Artist Spotify Ids
        /// </summary>
        [DataMember(Name = "artists")]
        public List<string> ArtistIds { get; set; }

        /// <summary>
        /// Track Spotify Ids
        /// </summary>
        [DataMember(Name = "tracks")]
        public List<string> TrackIds { get; set; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        [DataMember(Name = "shows")]
        public List<string> ShowIds { get; set; }

        /// <summary>
        /// Show Spotify Ids
        /// </summary>
        [DataMember(Name = "episodes")]
        public List<string> EpisodeIds { get; set; }
        #endregion Public Properties
    }
}
