using System.IO;
using System.Linq;
using TestYourKnowledge.Models;

namespace TestYourKnowledge.Extensions
{
    internal static class ResourceExtensions
    {
        private static readonly string[] _supportedSoundExtensions = new[] { ".m4a", ".mp3", ".wav" };
        private static readonly string[] _supportedImageExtensions = new[] { ".png", ".jpeg", ".jpg", ".gif" };

        internal static bool IsSound(this Resource resource)
        {
            var extension = Path.GetExtension(resource.Path);
            return _supportedSoundExtensions.Contains(extension);
        }

        internal static bool IsImage(this Resource resource)
        {
            var extension = Path.GetExtension(resource.Path);
            return _supportedImageExtensions.Contains(extension);
        }
    }
}
