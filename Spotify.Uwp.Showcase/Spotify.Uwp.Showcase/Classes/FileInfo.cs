using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;

namespace Spotify.Uwp.Showcase.Classes
{
    public class FileInfo : IFileInfo
    {
        private readonly byte[] _content;

        public FileInfo(string name, string content, DateTimeOffset? timestamp = null) : 
            this(name, Encoding.UTF8.GetBytes(content), timestamp) { }

        public FileInfo(string name, byte[] content, DateTimeOffset? timestamp = null)
        {
            Name = name;
            _content = content;
            LastModified = timestamp ?? DateTimeOffset.Now;
        }

        public bool Exists => true;
        public long Length => _content.LongLength;
        public string PhysicalPath => null;
        public string Name { get; }
        public DateTimeOffset LastModified { get; }
        public bool IsDirectory => false;
        public Stream CreateReadStream() => new MemoryStream(_content);
    }
}
