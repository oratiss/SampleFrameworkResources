using System.IO;

namespace SampleResourceManagementApp.Utilities.StreamExtensions
{
    public static class StreamExtension
    {
        public static byte[] GetAllBytes(this Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
