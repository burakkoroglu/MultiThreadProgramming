
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLocalVariables
{
    public class Program
    { // ParallelForEachMetodunda yerel değişkenler kullanarak Race Condition durumunun önüne geçilmesi
      // ForEach methoduna param olarak sırasıyla kaynağı(burada 1,100 range) , Her thread için local init (burada 0)
      // ve nihai olarak InterLocked kullanarak her thread üzerinde hesaplanan değer ortak değişkene yazılması
      // Sadece InterLocked'a göre daha performanslıdır.
        public static void Main(string[] args)
        {
            int total = 0;
            Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0 , (x,loop,subTotal) =>
            {
                subTotal += x;
                return subTotal;
            } , 
            (y) => Interlocked.Add(ref total , y));
            
            Console.WriteLine(total);
        }
    }
}
