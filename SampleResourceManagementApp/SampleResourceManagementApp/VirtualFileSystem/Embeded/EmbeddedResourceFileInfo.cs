using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Reflection;

namespace SampleResourceManagementApp.VirtualFileSystem.Embeded
{
    public class EmbeddedResourceFileInfo : IFileInfo
    {
        private readonly Assembly _assembly;
        private readonly string _resourcePath;
        public bool Exists => true;

        private long? _length;
        public long Length
        {
            get
            {
                if (!_length.HasValue)
                {
                    using var stream = _assembly.GetManifestResourceStream(_resourcePath);
                    if (stream != null)
                        _length = stream.Length;
                }

                return _length.Value;
            }

        }
        public string PhysicalPath => null;
        public string VirtualPath { get; }
        public string Name { get; }
        /// <summary>
        /// The time, in UTC.
        /// </summary>
        public DateTimeOffset LastModified { get; }
        public bool IsDirectory => false;

        public EmbeddedResourceFileInfo(
            Assembly assembly,
            string resourcePath,
            string virtualPath,
            string name,
            DateTimeOffset lastModified)
        {
            _assembly = assembly;
            _resourcePath = resourcePath;

            VirtualPath = virtualPath;
            Name = name;
            LastModified = lastModified;
        }
        public Stream CreateReadStream()
        {
            var stream = _assembly.GetManifestResourceStream(_resourcePath);

            if (!_length.HasValue && stream != null)
            {
                _length = stream.Length;
            }

            return stream;
        }

        public override string ToString()
        {
            return $"[EmbeddedResourceFileInfo] {Name} ({this.VirtualPath})";
        }
    }
}
