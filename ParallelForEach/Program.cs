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
        //MultiThread programlama örneği
        //İlk foreach multithread ikinci ise tek thread üzerinde resimleri thumbnail e çevirip kaydediyor
        //Liste içerisindeki item sayısı büyüdükçe multithread daha az zaman alıyor fakat küçük listeler için çok daha uzun sürüyor.



        static void Main(string[] args)
        {
            string picPath = @"C:\Users\A\Desktop\Practice\MultiThreadProgramming\img\";
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var files = Directory.GetFiles(picPath);


            Parallel.ForEach(files, (file) =>
             {
                 Console.WriteLine( "Thread No : {0}", Thread.CurrentThread.ManagedThreadId);
                 Image img = new Bitmap(file);

                 var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                 thumbnail.Save(Path.Combine(picPath,"thumbnail" ,Path.GetFileName(file)));

             });

            stopwatch.Stop();
            Console.WriteLine("İşlem Biti \n Geçensüre : {0}" , stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            files.ToList().ForEach( (file) =>
            {
                Console.WriteLine("Thread No : {0}", Thread.CurrentThread.ManagedThreadId);
                Image img = new Bitmap(file);

                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                thumbnail.Save(Path.Combine(picPath, "thumbnail", Path.GetFileName(file)));

            });
            stopwatch.Stop ();

            Console.WriteLine("Normal ForEach bitti . \n Geçen süre : {0}" , stopwatch .ElapsedMilliseconds);
        }
    }
}
