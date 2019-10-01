using System;
using System.Diagnostics;
using System.Linq;

namespace FizzBuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 100;

            Console.WriteLine("Starting FizzBuzz");
            var watchNormal = Stopwatch.StartNew();
            var resultNormal = count.FizzBuzzNormal();
            watchNormal.Stop();

            Console.WriteLine("Starting FizzBuzz (Synchronized)");
            var watchSync = Stopwatch.StartNew();
            var resultSync = count.FizzBuzzSync();
            watchSync.Stop();

            Console.WriteLine("Starting FizzBuzz (Parallel)");
            var watchParallel = Stopwatch.StartNew();
            var resultParallel = count.FizzBuzzParallel();
            watchParallel.Stop();

            Console.WriteLine("Processing results");
            Console.WriteLine();

            Console.WriteLine($"Normal result: {resultNormal}");
            Console.WriteLine($"Parallel result: {resultSync}");
            Console.WriteLine($"Parallel result: {resultParallel}");
            Console.WriteLine();

            Console.WriteLine($"Are they identical? {resultNormal.Equals(resultParallel, StringComparison.CurrentCulture)&& resultNormal.Equals(resultSync, StringComparison.CurrentCulture)}");
            Console.WriteLine();

            Console.WriteLine($"Normal: {watchNormal.ElapsedTicks} ticks, {watchNormal.Elapsed} time, {watchNormal.ElapsedMilliseconds} ms. Running: {watchNormal.IsRunning}");
            Console.WriteLine($"Synchronized: {watchSync.ElapsedTicks} ticks, {watchSync.Elapsed} time, {watchSync.ElapsedMilliseconds} ms. Running: {watchSync.IsRunning}");
            Console.WriteLine($"Parallel: {watchParallel.ElapsedTicks} ticks, {watchParallel.Elapsed} time, {watchParallel.ElapsedMilliseconds} ms. Running: {watchParallel.IsRunning}");
        }
    }
}
