using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// File Information
    /// </summary>
    public class FileInfo : IFileInfo
    {
        private readonly byte[] _content;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">File Name</param>
        /// <param name="content">String Content</param>
        /// <param name="timestamp">Time Stamp</param>
        public FileInfo(string name, string content, DateTimeOffset? timestamp = null) :
            this(name, Encoding.UTF8.GetBytes(content), timestamp)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">File Name</param>
        /// <param name="content">Byte Content</param>
        /// <param name="timestamp">Time Stamp</param>
        public FileInfo(string name, byte[] content, DateTimeOffset? timestamp = null)
        {
            Name = name;
            _content = content;
            LastModified = timestamp ?? DateTimeOffset.Now;
        }

        /// <summary>
        /// Exists
        /// </summary>
        public bool Exists => true;

        /// <summary>
        /// Content Length
        /// </summary>
        public long Length => _content.LongLength;

        /// <summary>
        /// Physical Path
        /// </summary>
        public string PhysicalPath => null;

        /// <summary>
        /// File Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Last Modified Date
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Is Directory?
        /// </summary>
        public bool IsDirectory => false;

        /// <summary>
        /// Create Read Stream
        /// </summary>
        /// <returns>Stream</returns>
        public Stream CreateReadStream() => 
            new MemoryStream(_content);
    }
}
