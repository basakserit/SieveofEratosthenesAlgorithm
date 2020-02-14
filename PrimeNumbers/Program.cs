using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace PrimeNumbers
{
    class MainClass
    {
        public const int MAX_NUMBER = 1000;
        static TimeSpan timeSpan;

        public static void Main(string[] args)
        {
            Dictionary<int, bool> numbers = GenerateArray();
            PrintPrimeNumbers(GeneratePrimeNumbersWithDictionary(numbers), "With Dictionary & Adding numbers");

            PrintPrimeNumbers(GeneratePrimeNumbersWithHashSet(MAX_NUMBER), "With HashSet & Adding numbers");
        }

        static Dictionary<int, bool> GenerateArray()
        {
            Dictionary<int, bool> numbersDictionary = new Dictionary<int, bool>();

            for (int i = 2; i < MAX_NUMBER; i++)
            {
                numbersDictionary.Add(i, true);
            }

            return numbersDictionary;
        }

        static List<int> GeneratePrimeNumbersWithDictionary(Dictionary<int, bool> numbers)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            for (int i = 2; i < Math.Sqrt(MAX_NUMBER); i++)
            {
                if (numbers[i] == true)
                {
                    for (int j = i; j*i < MAX_NUMBER; j++)
                    {
                        numbers[i * j] = false;
                    }
                }
            }

            List<int> resultList = numbers.Where(x => x.Value).Select(x => x.Key).ToList();

            stopwatch.Stop();
            timeSpan = stopwatch.Elapsed;

            return resultList;
        }

        static List<int> GeneratePrimeNumbersWithHashSet(int maxNumber)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            HashSet<int> primeNumbers = new HashSet<int>();

            for (int i = 2; i < maxNumber; i++)
            {
                if (IsPrime(i))
                    primeNumbers.Add(i);
            }

            List<int> resultList = primeNumbers.ToList();

            stopwatch.Stop();
            timeSpan = stopwatch.Elapsed;

            return resultList;
        }

        static bool IsPrime(int limitNumber)
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(limitNumber); i++)
            {
                if (limitNumber % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        static void PrintPrimeNumbers(List<int> primeList, string methodName = null)
        {
            Console.WriteLine("Prime Numbers " + (!string.IsNullOrEmpty(methodName) ? methodName : string.Empty) );
            Console.WriteLine(string.Join(" ", primeList));

            Console.WriteLine("> Timer: "+ timeSpan.Milliseconds + " ms");
        }


    }
}
