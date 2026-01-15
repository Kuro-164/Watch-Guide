using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1.Helpers
{
    public static class PlatformLogoResolver
    {
        private static readonly Dictionary<string, string> PlatformLogos =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Netflix", "netflix.png" },
                { "Prime Video", "primevideo.png" },
                { "Amazon Prime Video", "primevideo.png" },
                { "Hotstar", "hotstar.png" },
                { "Disney+ Hotstar", "hotstar.png" },
                { "Sony LIV", "sonyliv.png" },
                { "Zee5", "zee5.png" },
                { "Apple TV+", "apple_tv.png" },
                { "YouTube", "youtube.png" }
            };

        public static string GetLogoPath(string platformName)
        {
            if (string.IsNullOrWhiteSpace(platformName))
                return GetDefault();

            if (PlatformLogos.TryGetValue(platformName, out var file))
                return GetFullPath(file);

            return GetDefault();
        }

        private static string GetFullPath(string fileName)
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets",
                "Platforms",
                fileName
            );
        }

        private static string GetDefault()
        {
            return GetFullPath("default.png");
        }
    }
}
