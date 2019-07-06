using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Tools
{
    /// <summary>
    /// 读取appsettings.json文件内容
    /// </summary>
    public class Appsettings
    {
        static IConfiguration _configuration;
        static Appsettings()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }
        /// <summary>
        /// 获取Appsetting
        /// </summary>
        public static string Get(string key)
        {
            return _configuration[$"AppSetting:{key}"];
        }
    }
}
