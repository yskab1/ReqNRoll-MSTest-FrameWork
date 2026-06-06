using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace FrameWork.Core.Configuration
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot _config;
        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static string BrowserType => _config["BrowserType"] ?? "Chrome";
        public static string TargetURL => _config["TargetURL"] ?? "https://www.google.com";
        public static string TimeoutSeconds => _config["TimeoutSeconds"] ?? "10";

    }
}
