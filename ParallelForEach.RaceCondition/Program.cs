using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long FilesByte = 0;


            string picPath = @"C:\Users\A\Desktop\Practice\MultiThreadProgramming\img\";
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var files = Directory.GetFiles(picPath);


            Parallel.ForEach(files, (file) =>
            {
                Console.WriteLine("Thread No : {0}", Thread.CurrentThread.ManagedThreadId);

                FileInfo fileInfo = new FileInfo(file);

                Interlocked.Add(ref FilesByte ,fileInfo.Length); // değeri verilen param ile toplar.

                Interlocked.Exchange(ref FilesByte ,300); // değeri verilen param ile değiştirir.

                // her bir thread değişkene ulaşmak istediğinde ınterlocked sınıfı değer güncellenene kadar başka threadleri bekletir.

            });

            Console.WriteLine("toplam boyut : {0}" , FilesByte.ToString());
        }
    }
}
