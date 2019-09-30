// Project FizzBuzz of FizzBuzz:
// * File FizzBuzz.cs
// Created by Wim ten Brink

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FizzBuzz;

namespace FizzBuzz
{
    using IntList = IEnumerable<int>;
    using ParallelIntList = ParallelQuery<int>;
    using Pair = KeyValuePair<int, string>;
    using PairList = IEnumerable<KeyValuePair<int, string>>;
    using ParallelPairList = ParallelQuery<KeyValuePair<int, string>>;
    using StringList = IEnumerable<string>;
    using ParallelStringList = ParallelQuery<string>;

    public static class FizzBuzz
    {
        public static T ShowThread<T>(this T data, string action)
        {
#if(DEBUG) 
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} for {action} with value {data}.");
#endif
            return data;
        }

        public static IntList MakeArray(this int count) => Enumerable.Range(1, count).AsParallel();

        public static ParallelIntList ParallelMakeArray(this int count) => Enumerable.Range(1, count).AsParallel();

        public static PairList MakePairs(this IntList data) => data.Select(i => new Pair(i, string.Empty));

        public static ParallelPairList ParallelMakePairs(this ParallelIntList data) => data.Select(i => new Pair(i, string.Empty));

        public static Pair Fizz(this Pair data) => data.Key % 3 == 0 ? new Pair(data.Key.ShowThread("Fizz"), "Fizz" + data.Value) : data;

        public static PairList Fizz(this PairList data) => data.Select(p => p.Fizz());

        public static ParallelPairList ParallelFizz(this ParallelPairList data) => data.Select(p => p.Fizz());

        public static Pair Buzz(this Pair data) => data.Key % 5 == 0 ? new Pair(data.Key.ShowThread("Buzz"), data.Value + "Buzz") : data;

        public static ParallelPairList ParallelBuzz(this ParallelPairList data) => data.Select(p => p.Buzz());

        public static PairList Buzz(this PairList data) => data.Select(p => p.Buzz());

        public static Pair Number(this Pair data) => string.IsNullOrEmpty(data.Value) ? new Pair(data.Key.ShowThread("Number"), data.Key.ToString()) : data;

        public static PairList Number(this PairList data) => data.Select(p => p.Number());

        public static ParallelPairList ParallelNumber(this ParallelPairList data) => data.Select(p => p.Number());

        public static PairList Sort(this PairList data) => data.OrderBy(p => p.Key);

        public static StringList Values(this PairList data) => data.Select(p => p.Value);

        public static string Combine(this StringList data) => string.Join(", ", data);

        public static string FizzBuzzSync(this int count) => count.MakeArray().MakePairs().Fizz().Buzz().Number().Values().Combine();

        public static string FizzBuzzParallel(this int count) => count.ParallelMakeArray().ParallelMakePairs().ParallelFizz().ParallelBuzz().ParallelNumber().Sort().Values().Combine();
    }
}
