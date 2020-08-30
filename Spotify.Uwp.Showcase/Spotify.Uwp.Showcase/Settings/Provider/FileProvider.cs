using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.Uwp.Showcase
{
    /// <summary>
    /// File Provider
    /// </summary>
    public class FileProvider : IFileProvider
    {
        private class DirectoryContents : IDirectoryContents
        {
            private IEnumerable<IFileInfo> _files;
            private IEnumerable<IFileInfo> _filesInFolder;

            public DirectoryContents(string subPath, IEnumerable<IFileInfo> files)
            {
                _files = files;
                _filesInFolder = _files.Where(f => f.Name.StartsWith(subPath, StringComparison.Ordinal));
            }

            public bool Exists => true;

            public IEnumerator<IFileInfo> GetEnumerator() => _filesInFolder.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => _files.GetEnumerator();
        }

        private IEnumerable<IFileInfo> _files;
        private Dictionary<string, IChangeToken> _changeTokens;

        /// <summary>
        /// Constructor
        /// </summary>
        public FileProvider() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="files">File Info Array</param>
        public FileProvider(params IFileInfo[] files) =>
            _files = files;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="changeTokens">Change Tokens</param>
        public FileProvider(params KeyValuePair<string, IChangeToken>[] changeTokens) =>
            _changeTokens = changeTokens.ToDictionary(
                changeToken => changeToken.Key,
                changeToken => changeToken.Value,
                StringComparer.Ordinal);

        /// <summary>
        /// Get Directory Contents
        /// </summary>
        /// <param name="subPath">Sub Path</param>
        /// <returns>Directory Contents</returns>
        public IDirectoryContents GetDirectoryContents(string subPath) =>
            new DirectoryContents(subPath, _files);

        /// <summary>
        /// Get File Information
        /// </summary>
        /// <param name="subPath">Sub Path</param>
        /// <returns>File Info</returns>
        public IFileInfo GetFileInfo(string subPath) =>
            _files.FirstOrDefault(f => f.Name == subPath) ?? new NotFoundFileInfo(subPath);

        /// <summary>
        /// Watch
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Change Token</returns>
        public IChangeToken Watch(string filter) =>
            _changeTokens != null && _changeTokens.ContainsKey(filter) ?
            _changeTokens[filter] : NullChangeToken.Singleton;
    }
}
