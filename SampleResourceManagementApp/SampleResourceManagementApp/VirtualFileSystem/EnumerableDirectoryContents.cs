using JetBrains.Annotations;
using Microsoft.Extensions.FileProviders;
using SampleResourceManagementApp.Utilities.Assertions;
using System.Collections;
using System.Collections.Generic;

namespace SampleResourceManagementApp.VirtualFileSystem
{
    internal class EnumerableDirectoryContents : IDirectoryContents
    {
        private readonly IEnumerable<IFileInfo> _entries;

        public EnumerableDirectoryContents([NotNull] IEnumerable<IFileInfo> entries)
        {
            LocalizationAssertion.NotNull(entries, nameof(entries));

            _entries = entries;
        }

        public bool Exists => true;

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entries.GetEnumerator();
        }
    }
}
