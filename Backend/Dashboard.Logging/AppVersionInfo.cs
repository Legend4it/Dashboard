using Dashboard.Logging;
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace Dashboard.Logger
{
    public static class AppVersionInfo
    {
        private const string _buildFileName = "buildinfo.json";
        private static CultureInfo _provider = CultureInfo.CurrentCulture;

        private static BuildInfo _fileBuildInfo = new(
            BranchName: "",
            BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
            BuildId: "xxxxxx",
            CommitHash: $"Not yet initialised - call {nameof(InitialiseBuildInfoGivenPath)}"
        );

        public static void InitialiseBuildInfoGivenPath(string path)
        {
            var buildFilePath = Path.Combine(path, _buildFileName);
            if (File.Exists(buildFilePath))
            {
                try
                {
                    var buildInfoJson = File.ReadAllText(buildFilePath);
                    var buildInfo = JsonSerializer.Deserialize<BuildInfo>(buildInfoJson, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    if (buildInfo == null)
                        throw new AppVersionInfoException($"Failed to deserialise '{_buildFileName}'");

                    if (string.IsNullOrEmpty(buildInfo.CommitHash))
                        throw new AppVersionInfoException($"Failed to deserialise '{_buildFileName}'");

                    _fileBuildInfo = buildInfo;
                }
                catch (Exception ex) when (ex is JsonException || ex is ArgumentNullException || ex is NotSupportedException)
                {
                    SetErrorBuildInfo();
                }
                catch (AppVersionInfoException ex)
                {
                    _fileBuildInfo = new BuildInfo(
                      BranchName: "",
                      BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
                      BuildId: "xxxxxx",
                      CommitHash: ex.Message
                  );
                }
            }
            else
            {
                SetErrorBuildInfo();
            }
        }

        private static void SetErrorBuildInfo()
        {
            _fileBuildInfo = new BuildInfo(
                BranchName: "",
                BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
                BuildId: "xxxxxx",
                CommitHash: "Failed to load build info from 'buildinfo.json'"
            );
        }

        public static BuildInfo GetBuildInfo => _fileBuildInfo;

        internal static void Clear()
        {
            _fileBuildInfo = new(
            BranchName: "",
            BuildNumber: DateTime.UtcNow.ToString("yyyyMMdd", _provider) + ".0",
            BuildId: "xxxxxx",
            CommitHash: $"Not yet initialised - call {nameof(InitialiseBuildInfoGivenPath)}"
        );
        }
    }
}
