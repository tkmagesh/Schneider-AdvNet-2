using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParallelismDemo
{
    public static class MyUtilities
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var o = new object();
            int primeCount = 0,
                max = 500000;
            var stopwatch = new Stopwatch();
            Console.ReadLine();
            stopwatch.Start();
            /*Enumerable.Range(1,max).ForEach(n =>
                {
                    if (isPrime(n)) primeCount++;
                });*/
            //41540
            
            /*Parallel.For(1, max, (n) =>
                {
                    lock (o)
                    {
                        if (isPrime(n))
                            primeCount++;    
                    }
                    
                });
            */

            Parallel.For(1, max, () => 0, (n, pls, ls) =>
                {
                    if (isPrime(n))
                        return ls + 1;
                    return ls;
                }, (lc) => primeCount += lc);

            stopwatch.Stop();
            Console.WriteLine("{0} prime numbers found between 1 to {1}", primeCount, max);
            Console.WriteLine("Time taken = {0} seconds", stopwatch.ElapsedMilliseconds / 1000);
            Console.ReadLine();
        }

        private static bool isPrime(int number)
        {
            if (number <= 2) return true;
            var limit = number/2;
            for (var i = 2; i < limit; i++)
            {
                if (number%i == 0)
                    return false;
            }
            return true;
        }
    }
}
