using JetBrains.Annotations;
using Microsoft.Extensions.FileProviders;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.VirtualFileSystem
{
    public class VirtualFileSetInfo
    {
        public IFileProvider FileProvider { get; }

        public VirtualFileSetInfo([NotNull] IFileProvider fileProvider)
        {
            FileProvider = LocalizationAssertion.NotNull(fileProvider, nameof(fileProvider));
        }
    }
}