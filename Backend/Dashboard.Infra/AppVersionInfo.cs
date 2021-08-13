using System;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace Dashboard.Infra
{
    public static class AppVersionInfo
    {
        private const string _buildFileName = "buildinfo.json";
        private static CultureInfo _provider = CultureInfo.CurrentCulture;

        private static BuildInfo _fileBuildInfo = new(
            BranchName: "",
            BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
            BuildId: "xxxxxx",
            CommitHash: $"xxxxxxxxxxxxx"
        );


        public static BuildInfo GetBuildInfo => _fileBuildInfo;

        internal static void Clear()
        {
            _fileBuildInfo = new(
            BranchName: "",
            BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
            BuildId: "xxxxxx",
            CommitHash: $"xxxxxxxxxxxxx"
        );
        }
    }
}
