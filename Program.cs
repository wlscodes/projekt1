using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Program
    {

        static void Main(string[] args)
        {
            StartProject();
            Console.WriteLine("KONIEC!");
            Console.ReadKey();
        }

        static void StartProject()
        {
            SimpleCounterPesymistic();
            SimpleCounterMedium();
            BinaryCounterPesymistic();
            BinaryCounterMedium();

            SimpleTimerPesymistic();
            SimpleTimerMedium();
            BinaryTimerPesymistic();
            BinaryTimerMedium();
        }


        #region counters
        static void SimpleCounterPesymistic()
        {
            Console.WriteLine("Simple - Counter - Pesymistic");
            Console.WriteLine("ArraySize;Counter");
            SearchClass sc = new SearchClass();
            for(long i = 2000000; i<=(long)Math.Pow(2,28); i += 2000000)
            {
                sc.SimpleSearchWithCounter(CreateAndFillArray(i), 1001);
                Console.WriteLine("{0};{1}", i, sc.counter);
            }
        }

        static void SimpleCounterMedium()
        {
            Console.WriteLine("Simple - Counter - Medium");
            Console.WriteLine("ArraySize;Counter");
            SearchClass sc = new SearchClass();
            Random rand = new Random();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                long min = long.MaxValue;
                long max = long.MinValue;
                long total = 0;
                for(int j = 0; j < 12; j++)
                {
                    sc.SimpleSearchWithCounter(CreateAndFillArray(i), rand.Next(0,1000));
                    total += sc.counter;
                    if (sc.counter > max) max = sc.counter;
                    if (sc.counter < min) min = sc.counter;
                }

                Console.WriteLine("{0};{1}", i, (total - (max + min))/10);
            }
        }

        static void BinaryCounterPesymistic()
        {
            Console.WriteLine("Binary - Counter - Pesymistic");
            Console.WriteLine("ArraySize;Counter");
            SearchClass sc = new SearchClass();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                sc.BinarySearchWithCounter(CreateAndFillArray(i, true), 1001);
                Console.WriteLine("{0};{1}", i, sc.counter);
            }
        }

        static void BinaryCounterMedium()
        {
            Console.WriteLine("Binary - Counter - Medium");
            Console.WriteLine("ArraySize;Counter");
            SearchClass sc = new SearchClass();
            Random rand = new Random();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                long min = long.MaxValue;
                long max = long.MinValue;
                long total = 0;
                for (int j = 0; j < 12; j++)
                {
                    sc.BinarySearchWithCounter(CreateAndFillArray(i, true), rand.Next(0, 1000));
                    total += sc.counter;
                    if (sc.counter > max) max = sc.counter;
                    if (sc.counter < min) min = sc.counter;
                }

                Console.WriteLine("{0};{1}", i, (total - (max + min)) / 10);
            }
        }
        #endregion

        #region timers
        static void SimpleTimerPesymistic()
        {
            Console.WriteLine("Simple - Timer - Pesymistic");
            Console.WriteLine("ArraySize;Time[s]");
            SearchClass sc = new SearchClass();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                int[] arr = CreateAndFillArray(i);
                long start = Stopwatch.GetTimestamp();
                sc.SimpleSearch(arr, 1001);
                long stop = Stopwatch.GetTimestamp();
                Console.WriteLine("{0};{1}", i, (stop - start) * (1.0 / Stopwatch.Frequency));
            }
        }

        static void SimpleTimerMedium()
        {
            Console.WriteLine("Simple - Timer - Medium");
            Console.WriteLine("ArraySize;Time[s]");
            SearchClass sc = new SearchClass();
            Random rand = new Random();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                long min = long.MaxValue;
                long max = long.MinValue;
                long total = 0;
                for (int j = 0; j < 12; j++)
                {
                    int[] arr = CreateAndFillArray(i);
                    long start = Stopwatch.GetTimestamp();
                    sc.SimpleSearch(arr, rand.Next(0,1000));
                    long stop = Stopwatch.GetTimestamp();
                    long difference = stop - start;
                    total += difference;
                    if (difference > max) max = difference;
                    if (difference < min) min = difference;
                }

                Console.WriteLine("{0};{1}", i, (total - (max + min)) / 10);
            }
        }

        static void BinaryTimerPesymistic()
        {
            Console.WriteLine("Binary - Timer - Pesymistic");
            Console.WriteLine("ArraySize;Time[s]");
            SearchClass sc = new SearchClass();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                int[] arr = CreateAndFillArray(i,true);
                long start = Stopwatch.GetTimestamp();
                sc.BinarySearch(arr, 1001);
                long stop = Stopwatch.GetTimestamp();
                Console.WriteLine("{0};{1}", i, (stop - start) * (1.0 / Stopwatch.Frequency));
            }
        }

        static void BinaryTimerMedium()
        {
            Console.WriteLine("Binary - Timer - Medium");
            Console.WriteLine("ArraySize;Time[s]");
            SearchClass sc = new SearchClass();
            Random rand = new Random();
            for (long i = 2000000; i <= (long)Math.Pow(2, 28); i += 2000000)
            {
                long min = long.MaxValue;
                long max = long.MinValue;
                long total = 0;
                for (int j = 0; j < 12; j++)
                {
                    int[] arr = CreateAndFillArray(i,true);
                    long start = Stopwatch.GetTimestamp();
                    sc.BinarySearch(arr, rand.Next(0, 1000));
                    long stop = Stopwatch.GetTimestamp();
                    long difference = stop - start;
                    total += difference;
                    if (difference > max) max = difference;
                    if (difference < min) min = difference;
                }

                Console.WriteLine("{0};{1}", i, (total - (max + min)) / 10);
            }
        }
        #endregion


        static int[] CreateAndFillArray(long length, bool isSorted = false, int minValue = 0, int maxValue = 1000)
        {
            int[] arr = new int[length];

            Random generator = new Random();
            for (long i = 0; i < length; i++)
                arr[i] = generator.Next(minValue, maxValue);

            if (isSorted)
                Array.Sort(arr);

            return arr;
        }
    }
}
