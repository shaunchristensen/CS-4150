/*
*   Author:  Shaun Christensen
*   Course:  CS 4150 - Algorithms
*   Created: 2016.01.18
*   Edited:  2016.01.18
*   Project: A1
*   Summary: Using the programming language of your choice, determine the average amount of time it takes to look up a key in a randomly-generated balanced binary search tree, as a function of the size of the tree. You need only deal with the case in which the key is in the tree.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace A1
{
    class Program
    {
        // fields

        static bool boolStopwatch;
        static bool boolTimer;

        static double doubleContainsElapsedTime;
        static double doubleContainsElapsedTimeAverage;
        static double doubleControlElapsedTime;
        static double doubleControlElapsedTimeAverage;
        static double doubleSearchElapsedTimeAverage;

        static int intCount;
        static int intRandom;

        const int intLower = 10;
        const int intUpper = 20;

        static long longContainsCount;
        static long longContainsElapsedTicks;
        static long longControlCount;
        static long longControlElapsedTicks;
        static long longCount;

        static List<int> listInt;
        static SortedSet<int> sortedSetInt;

        static Random random;
        static Stopwatch stopwatch;
        static Timer timer;

        // methods

        static void Main(string[] args)
        {
            random = new Random();

            stopwatch = new Stopwatch();

            timer = new Timer(1000);
            timer.Elapsed += timerElapsed;

            Console.Out.WriteLine("Stopwatch Frequency\t" + Stopwatch.Frequency);

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
                    intRandom = random.Next();

                    // if the integer is added to the sorted set then add it to the list
                    if (sortedSetInt.Add(intRandom))
                    {
                        listInt.Add(intRandom);
                    }
                }

                // include the binary tree search when measuring execution time
                time(true);

                // store data for reporting
                longContainsCount = longCount;
                longContainsElapsedTicks = stopwatch.ElapsedTicks;
                doubleContainsElapsedTime = (double)longContainsElapsedTicks / Stopwatch.Frequency;
                doubleContainsElapsedTimeAverage = doubleContainsElapsedTime / longContainsCount;

                stopwatch.Reset();

                // exclude the binary tree search when measuring execution time
                time(false);

                // store data for reporting
                longControlCount = longCount;
                longControlElapsedTicks = stopwatch.ElapsedTicks;
                doubleControlElapsedTime = (double)longControlElapsedTicks / Stopwatch.Frequency;
                doubleControlElapsedTimeAverage = doubleControlElapsedTime / longControlCount;
                doubleSearchElapsedTimeAverage = doubleContainsElapsedTimeAverage - doubleControlElapsedTimeAverage;

                stopwatch.Reset();

                // report data
                Console.Out.WriteLine("\nCount\t" + intCount);
                Console.Out.WriteLine("Contains Count\t" + longContainsCount);
                Console.Out.WriteLine("Contains Elapsed Ticks\t" + longContainsElapsedTicks);
                Console.Out.WriteLine("Contains Elapsed Time\t" + doubleContainsElapsedTime.ToString("F10"));
                Console.Out.WriteLine("Contains Elapsed Time Average\t" + doubleContainsElapsedTimeAverage.ToString("F10"));
                Console.Out.WriteLine("Control Count\t" + longControlCount);
                Console.Out.WriteLine("Control Elapsed Ticks\t" + longControlElapsedTicks);
                Console.Out.WriteLine("Control Elapsed Time\t" + doubleControlElapsedTime.ToString("F10"));
                Console.Out.WriteLine("Control Elapsed Time Average\t" + doubleControlElapsedTimeAverage.ToString("F10"));
                Console.Out.WriteLine("Search Elapsed Time Average\t" + doubleSearchElapsedTimeAverage.ToString("F10"));
            }
        }

        /// <summary>
        /// Time the binary tree search.
        /// </summary>
        /// <param name="b">Whether to search the binary tree.</param>
        static void time(bool b)
        {
            boolTimer = true;
            longCount = 0;

            timer.Start();

            while (boolTimer)
            {
                foreach (int i in listInt)
                {
                    // if true search the binary tree
                    if (b)
                    {
                        sortedSetInt.Contains(i);
                    }

                    // if the stopwatch is running increment the search count
                    if (boolStopwatch)
                    {
                        longCount++;
                    }
                }
            }
        }

        /// <summary>
        /// Controls the stopwatch and timer.
        /// </summary>
        /// <param name="sender">The object invoking the elapsed event handler.</param>
        /// <param name="e">The elapsed event arguments.</param>
        static void timerElapsed(object sender, ElapsedEventArgs e)
        {
            // if the stopwatch is running then stop the stopwatch and timer
            if (boolStopwatch)
            {
                boolStopwatch = boolTimer = false;

                stopwatch.Stop();
                timer.Stop();
            }
            // otherwise start the stopwatch
            else
            {
                boolStopwatch = true;

                stopwatch.Start();
            }
        }
    }
}