

using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Tools.Config.JsonSetting
{
    public class FileServerInfo
    {
        public static string DefaultPassword => AppConfiguration
                                              .GetConfigurationRoot()
                                              .GetSection(FileServerInfoConsts.FileServerInfo)
                                              .GetSection(FileServerInfoConsts.FilePath)
                                              .Value;
    }
}
