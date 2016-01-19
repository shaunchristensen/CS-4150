using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            double doubleElapsedContains;
            double doubleElapsedForEach;

            int intCount;
            int intNumber;

            const int intLower = 10;
            const int intUpper = 20;

            List<int> listInt;
            SortedSet<int> sortedSetInt;

            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();

            for (int i = intLower; i <= intUpper; i++)
            {
                // calculate the tree count
                intCount = (int)Math.Pow(2, i);

                // create the new sorted set and list
                listInt = new List<int>();
                sortedSetInt = new SortedSet<int>();

                // populate the sorted set and list with random integers
                while (sortedSetInt.Count < intCount)
                {
                    intNumber = random.Next();

                    if (sortedSetInt.Add(intNumber))
                    {
                        listInt.Add(intNumber);
                    }
                }

                // measure the time required to execute the binary tree search
                stopwatch.Start();

                foreach (int j in listInt)
                {
                    sortedSetInt.Contains(j);
                }

                stopwatch.Stop();

                doubleElapsedContains = ((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;

                stopwatch.Reset();

                // measure the time required to execute the foreach loop
                stopwatch.Start();

                foreach (int j in listInt)
                {
                }

                stopwatch.Stop();

                doubleElapsedForEach = ((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;

                stopwatch.Reset();

                Console.Out.WriteLine("\nTree Count: " + intCount);
                Console.Out.WriteLine("Total Time: " + doubleElapsedContains);
                Console.Out.WriteLine("Loop Time: " + doubleElapsedForEach);
                Console.Out.WriteLine("Search Time: " + (doubleElapsedContains - doubleElapsedForEach));
                Console.Out.WriteLine("Average Search Time: " + (doubleElapsedContains - doubleElapsedForEach) / intCount);

                /*
                  // Construct a sorted array
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = i;
            }

            // Create a stopwatch
            Stopwatch sw = new Stopwatch();

            // Keep increasing the number of repetitions until one second elapses.
            double elapsed = 0;
            long repetitions = 1;
            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int elt = 0; elt < size; elt++)
                    {
                        BinarySearch(data, elt);
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < DURATION);
            double totalAverage = elapsed / repetitions;

            // Create a stopwatch
            sw = new Stopwatch();

            // Keep increasing the number of repetitions until one second elapses.
            elapsed = 0;
            repetitions = 1;
            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int elt = 0; elt < size; elt++)
                    {
                        //BinarySearch(data, elt);
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < DURATION);
            double overheadAverage = elapsed / repetitions;

            // Display the raw data as a sanity check
            //Console.WriteLine("Total avg:    " + totalAverage.ToString("G2"));
            //Console.WriteLine("Overhead avg: " + overheadAverage.ToString("G2"));

            // Return the difference, averaged over size
            return (totalAverage - overheadAverage) / size;
            */





                /*
                Console.Out.Write("Length " + sortedSetInt.Count + ":");

                for (int j = 0; j < 10; j++)
                {
                    Console.Out.Write(" " + listInt[j]);
                }

                Console.Out.WriteLine();
                */
            }
        }
    }
}