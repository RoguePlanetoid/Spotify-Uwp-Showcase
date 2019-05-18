using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Spotify.Uwp.Showcase.Classes
{
    public class FileProvider : IFileProvider
    {
        private class DirectoryContents : IDirectoryContents
        {
            IEnumerable<IFileInfo> _files;
            IEnumerable<IFileInfo> _filesInFolder;

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

        public FileProvider() { }

        public FileProvider(params IFileInfo[] files) =>
            _files = files;

        public FileProvider(params KeyValuePair<string, IChangeToken>[] changeTokens) =>
            _changeTokens = changeTokens.ToDictionary(
                changeToken => changeToken.Key,
                changeToken => changeToken.Value,
                StringComparer.Ordinal);

        public IDirectoryContents GetDirectoryContents(string subPath) => 
            new DirectoryContents(subPath, _files);

        public IFileInfo GetFileInfo(string subPath) =>
            _files.FirstOrDefault(f => f.Name == subPath) ?? new NotFoundFileInfo(subPath);

        public IChangeToken Watch(string filter) => 
            _changeTokens != null && _changeTokens.ContainsKey(filter) ? 
            _changeTokens[filter] : NullChangeToken.Singleton;
    }
}
