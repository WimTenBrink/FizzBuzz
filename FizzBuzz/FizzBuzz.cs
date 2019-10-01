// Project FizzBuzz of FizzBuzz:
// * File FizzBuzz.cs
// Created by Wim ten Brink

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzApp
{
    using IntEnum = IEnumerable<int>;
    using IntList = List<int>;
    using IntParallel = ParallelQuery<int>;
    using Pair = KeyValuePair<int, string>;
    using PairEnum = IEnumerable<KeyValuePair<int, string>>;
    using PairList = List<KeyValuePair<int, string>>;
    using PairParallel = ParallelQuery<KeyValuePair<int, string>>;
    using StringList = IEnumerable<string>;

    public static class MakeArrayHelper
    {
        public static IntEnum MakeArray(this int count) => Enumerable.Range(1, count);
        public static IntList MakeArraySync(this int count) => Enumerable.Range(1, count).ToList();
        public static IntParallel ParallelMakeArray(this int count) => Enumerable.Range(1, count).AsParallel();

    }
    public static class MakePairHelper
    {
        public static PairEnum MakePairs(this IntEnum data) => data.Select(i => new Pair(i, string.Empty));
        public static PairList MakePairsSync(this IntList data) => data.Select(i => new Pair(i, string.Empty)).ToList();
        public static PairParallel ParallelMakePairs(this IntParallel data) => data.Select(i => new Pair(i, string.Empty));
    }
    public static class FizzHelper
    {
        public static Pair Fizz(this Pair data) => data.Key % 3 == 0 ? new Pair(data.Key.ShowThread("Fizz"), "Fizz" + data.Value) : data;
        public static PairEnum Fizz(this PairEnum data) => data.Select(p => p.Fizz());
        public static PairList FizzSync(this PairList data) => data.Select(p => p.Fizz()).ToList();
        public static PairParallel ParallelFizz(this PairParallel data) => data.Select(p => p.Fizz());
    }
    public static class BuzzHelper
    {
        public static Pair Buzz(this Pair data) => data.Key % 5 == 0 ? new Pair(data.Key.ShowThread("Buzz"), data.Value + "Buzz") : data;
        public static PairEnum Buzz(this PairEnum data) => data.Select(p => p.Buzz());
        public static PairList BuzzSync(this PairList data) => data.Select(p => p.Buzz()).ToList();
        public static PairParallel ParallelBuzz(this PairParallel data) => data.Select(p => p.Buzz());
    }
    public static class NumberHelper
    {
        public static Pair Number(this Pair data) => string.IsNullOrEmpty(data.Value) ? new Pair(data.Key.ShowThread("Number"), data.Key.ToString()) : data;
        public static PairEnum Number(this PairEnum data) => data.Select(p => p.Number());
        public static PairList NumberSync(this PairList data) => data.Select(p => p.Number()).ToList();
        public static PairParallel ParallelNumber(this PairParallel data) => data.Select(p => p.Number());
    }
    public static class FizzBuzzHelper
    {
        public static PairEnum Sort(this PairEnum data) => data.OrderBy(p => p.Key);
        public static StringList Values(this PairEnum data) => data.Select(p => p.Value);
        public static string Combine(this StringList data) => string.Join(", ", data);
    }
    public static class FizzBuzz
    {
        public static string FizzBuzzNormal(this int count) => count.MakeArray().MakePairs().Fizz().Buzz().Number().Values().Combine();
        public static string FizzBuzzSync(this int count) => count.MakeArraySync().MakePairsSync().FizzSync().BuzzSync().NumberSync().Values().Combine();
        public static string FizzBuzzParallel(this int count) => count.ParallelMakeArray().ParallelMakePairs().ParallelFizz().ParallelBuzz().ParallelNumber().Sort().Values().Combine();
    }
}
