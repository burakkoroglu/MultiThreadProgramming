using System;
using System.IO;
using System.Threading.Tasks;

namespace FromResultMethod
{
    internal class Program
    {
        public static string CacheData { get; set; }
        private async static Task Main(string[] args)
        {
            CacheData = await GetCacheDataAsync();
            Console.WriteLine(CacheData);

            CacheData = await GetCacheDataAsync();
            Console.WriteLine(CacheData);


        }

        public static Task<string> GetCacheDataAsync()
        {
            if (string.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("TextFile1.txt");
            }

            return Task.FromResult<string>(CacheData);

        }

    }
}
