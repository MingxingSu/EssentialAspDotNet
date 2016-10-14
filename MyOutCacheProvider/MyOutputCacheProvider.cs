using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Caching;
using System.Xml.Serialization;

namespace MyOutCacheProvider
{
    //1.自定义OutputCacheProvider需要实现System.Web.Cacheing. OutputCacheProvider抽象类/
   
    //在设置的缓存时间小于指定阀值时，缓存到HttpRuntime.Cache中，否则缓存到文件中
    public class MyOutputCacheProvider:OutputCacheProvider

    {
         private const string KEY_PREFIX = "__outputCache_";
 
        /// <summary>
        /// 初始化SmartOutputCacheProvider，读取配置文件中配置的MemoryCacheLimit和FileCacheRoot的值
        /// </summary>
        /// <param name="name">provider名字</param>
        /// <param name="config">配置</param>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            string memoryLimit = config["memoryCacheLimit"];
            if (memoryLimit == null)
            {
                MemoryCacheLimit = new TimeSpan(0, 30, 0);
            }
            else
            {
                MemoryCacheLimit = TimeSpan.Parse(memoryLimit);
            }
 
            string fileCacheRoot = config["fileCachRoot"];
            if (string.IsNullOrEmpty(fileCacheRoot))
            {
                fileCacheRoot = AppDomain.CurrentDomain.BaseDirectory + "cache\\";
            }
            this.FileCacheRoot = fileCacheRoot;
            base.Initialize(name, config);
        }
 
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存的键，key的值是有asp.net内部生成的</param>
        /// <param name="entry">缓存的对象</param>
        /// <param name="utcExpiry">过期时间</param>
        /// <returns>返回缓存值</returns>
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            Set(key, entry, utcExpiry);
            return entry;
        }

        /// <summary>
        /// 获得缓存值，如果在HttpRuntime.Cache中有则直接读取内存中的值，否则从文件读取
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public override object Get(string key)
        {
            string processedKey = ProcessKey(key);

            CacheDataWithExpiryTimeUtc result = HttpRuntime.Cache[processedKey] as CacheDataWithExpiryTimeUtc;
            if (result == null)
            {
                string path = GetFilePath(processedKey);
                if (!File.Exists(path))
                    return null;

                using (FileStream file = File.OpenRead(path))
                {
                    var formatter = new BinaryFormatter();
                    result = (CacheDataWithExpiryTimeUtc)formatter.Deserialize(file);
                }
            }

            if (result == null || result.ExpiryTimeUtc <= DateTime.UtcNow)
            {
                Remove(key);
                return null;
            }
            return result.Data;
        }

        /// <summary>
        /// 根据键移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public override void Remove(string key)
        {
            string processedKey = ProcessKey(key);
            HttpRuntime.Cache.Remove(processedKey);
            string path = GetFilePath(processedKey);
            if (!File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="entry">缓存内容</param>
        /// <param name="utcExpiry">过期时间</param>
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            TimeSpan ts = utcExpiry - DateTime.UtcNow;
            string processedKey = ProcessKey(key);

            CacheDataWithExpiryTimeUtc cacheItem = new CacheDataWithExpiryTimeUtc
            {
                Data = entry,
                ExpiryTimeUtc = utcExpiry
            };

            if (ts <= MemoryCacheLimit)
            {
                HttpRuntime.Cache.Insert(processedKey, cacheItem, null, utcExpiry.ToLocalTime(), TimeSpan.Zero);
            }
            else
            {
                string cacheFilePath = GetFilePath(processedKey);

                using (var fs = new FileStream(cacheFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, cacheItem);
                }
            }
        }
 
        /// <summary>
        /// 处理缓存键值，防止在文件缓存时出现文件路径不允许的字符
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>处理后的键</returns>
        private string ProcessKey(string key)
        {
            return KEY_PREFIX + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        }
 
        /// <summary>
        /// 返回缓存文件的物理路径
        /// </summary>
        /// <param name="processedKey">处理后的键</param>
        /// <returns>物理路径</returns>
        private string GetFilePath(string processedKey)
        {
            return Path.Combine(FileCacheRoot, processedKey + ".data");
        }

 
        /// <summary>
        /// 如果缓存设定的时间超过此值则缓存到文件中，否则在HttpRuntime.Cache中做缓存
        /// </summary>
        [XmlAttribute("memoryCacheLimit")]
        public TimeSpan MemoryCacheLimit { get; set; }
 
 
        /// <summary>
        /// 文件缓存的根目录，可以指定任何可访问目录
        /// </summary>
        [XmlAttribute("fileCacheRoot")]
        public string FileCacheRoot { get; set; }
    }
 
    /// <summary>
    /// 对缓存数据和缓存的过期时间的封装
    /// </summary>
    [Serializable]
    internal class CacheDataWithExpiryTimeUtc
    {
        public object Data { get; set; }
 
        public DateTime ExpiryTimeUtc { get; set; }
    }
    
}