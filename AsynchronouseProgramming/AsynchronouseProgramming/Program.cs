using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronouseProgramming
{
    internal class Program
    {
        private static async Task Main()
        {
            var stopwatch = Stopwatch.StartNew();

            BigInteger[] results = await Task.WhenAll(
                Task.Run(() => Sum(1, 1_000_000_00)),
                Task.Run(() => Sum(100_000, 1_100_000_00)));

            stopwatch.Stop();
            Console.WriteLine($"Finished in {stopwatch.ElapsedMilliseconds} milliseconds");

            BigInteger total = results[0] + results[1];
            Console.WriteLine($"Total = {total}");

            Console.ReadLine();
        }

        private static BigInteger Sum(long start, long end)
        {
            BigInteger result = 0;
            for (long i = start; i <= end; i++)
            {
                result += i;
            }

            return result;
        }
    }
}