using System;
using System.Threading.Tasks;

namespace ValueTask
{
    internal class Program
    {
        public static int CacheData { get; set; } = 150;
        private async static Task Main(string[] args)
        {
            await GetData();
        }
 
        
        public static ValueTask<int> GetData()
        {
            return new ValueTask<int>(CacheData);
        }
    
    }
}
