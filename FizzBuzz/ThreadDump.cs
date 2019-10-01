using System;
using System.Threading;

namespace FizzBuzzApp
{
    public static class ThreadDump
    {
        public static T ShowThread<T>(this T data, string action)
        {
#if(DEBUG)
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} for {action} with value {data}.");
#endif
            return data;
        }

    }
}
