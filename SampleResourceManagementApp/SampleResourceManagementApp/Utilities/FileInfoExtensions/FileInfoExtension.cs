using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using SampleResourceManagementApp.Utilities.Assertions;
using SampleResourceManagementApp.VirtualFileSystem;
using SampleResourceManagementApp.VirtualFileSystem.Embeded;

namespace SampleResourceManagementApp.Utilities.FileInfoExtensions
{
    public static class FileInfoExtension
    {
        public static string GetVirtualOrPhysicalPathOrNull([NotNull] this IFileInfo fileInfo)
        {
            LocalizationAssertion.NotNull(fileInfo, nameof(fileInfo));

            if (fileInfo is EmbeddedResourceFileInfo embeddedFileInfo)
                return embeddedFileInfo.VirtualPath;

            if (fileInfo is InMemoryFileInfo inMemoryFileInfo)
                return inMemoryFileInfo.DynamicPath;

            return fileInfo.PhysicalPath;
        }
    }
}
