using Microsoft.Extensions.FileProviders;

namespace SampleResourceManagementApp.VirtualFileSystem
{
    public interface IDynamicFileProvider : IFileProvider
    {
        void AddOrUpdate(IFileInfo fileInfo);
        bool Delete(string filePath);
    }
}
