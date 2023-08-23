using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Common
{
    /// <summary>
    /// 获取appsettings.json文件,引用包
    /// Microsoft.Extensions.Configuration.FileExtensions
    /// Microsoft.Extensions.Configuration
    /// Microsoft.Extensions.Configuration.Binder
    /// Microsoft.Extensions.Configuration.Json
    /// Microsoft.Extensions.ConfigurationManager
    /// Program.cs添加
    /// IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    /// builder.Services.AddSingleton(new Common.ConfigHelper(configuration));
    /// </summary>
    [Serializable]
    public class ConfigHelper
    {
        private static IConfiguration _config;

        public ConfigHelper(IConfiguration configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// 读取单个json字段信息
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static string Get(params string[] session)
        {
            string value = "";
            try
            {
                if (session.Any())
                {
                    value = Tools.GetString(_config[string.Join(":", session)]);
                }
            }
            catch (Exception ex)
            {
                value = "";
            }
            return value;
        }

        /// <summary>
        /// 读取json对象信息并转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <returns></returns>
        public static T Get<T>(string session)
        {
            try
            {
                var data = _config.GetSection(session).Get<T>();
                return data;
            }
            catch (Exception)
            {
                return new List<T>()[0];
            }
        }
    }
}
