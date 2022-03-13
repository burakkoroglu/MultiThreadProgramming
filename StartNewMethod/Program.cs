using System;
using System.Threading;
using System.Threading.Tasks;

namespace StartNewMethod
{

    public class Status
    {
        public int ThreadId { get; set; }
        public DateTime Date { get; set; }
    }
    // start new run mmethodundan farklı olarak içerisine obje alabilir ve dönebilir.
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            var myTask = Task.Factory.StartNew((Obj ) =>
            {
                Console.WriteLine("myTask Çalıştı");
                var status = Obj as Status;

                status.ThreadId = Thread.CurrentThread.ManagedThreadId;


            } , new Status() { Date=DateTime.Now});

            await myTask;

            Status stat = myTask.AsyncState as Status;

            Console.WriteLine(stat.ThreadId);
            Console.WriteLine(stat.Date);


        }

    }
}
