using System;
using System.Diagnostics;
using System.Linq;
using FizzBuzz;

namespace FizzBuzzApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 100;

            Console.WriteLine("Starting FizzBuzz");
            var normal = Stopwatch.StartNew();
            var result = count.FizzBuzzSync();
            normal.Stop();

            Console.WriteLine("Starting FizzBuzz (Parallel)");
            var parallel = Stopwatch.StartNew();
            var resultParallel = count.FizzBuzzParallel();
            parallel.Stop();

            Console.WriteLine("Processing results");
            Console.WriteLine();

            Console.WriteLine($"Normal result: {result}");
            Console.WriteLine($"Parallel result: {resultParallel}");
            Console.WriteLine();

            Console.WriteLine($"Are they identical? {result.Equals(resultParallel, StringComparison.CurrentCulture)}");
            Console.WriteLine();

            Console.WriteLine($"Normal: {normal.ElapsedTicks} ticks, {normal.Elapsed} time, {normal.ElapsedMilliseconds} ms. Running: {normal.IsRunning}");
            Console.WriteLine($"Parallel: {parallel.ElapsedTicks} ticks, {parallel.Elapsed} time, {parallel.ElapsedMilliseconds} ms. Running: {parallel.IsRunning}");
        }
    }
}
