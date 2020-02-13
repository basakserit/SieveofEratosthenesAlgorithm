using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers
{
    class MainClass
    {
        //public const int ARRAY_SIZE = 100;
        public const int MAX_NUMBER = 10;

        public static void Main(string[] args)
        {
            Dictionary<int, bool> numbers = GenerateArray();
            printPrimeNumbers(GeneratePrimeNumbersWithDictionary(numbers), "With Dictionary & Adding numbers");



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

            return numbers.Where(x => x.Value).Select(x => x.Key).ToList();
        }


        //static List<int> GeneratePrimeNumbersWithHashSet(HashSet<int> numbers)
        //{

        //}

        static void printPrimeNumbers(List<int> primeList, string methodName = null)
        {
            Console.WriteLine("Prime Numbers " + (!string.IsNullOrEmpty(methodName) ? methodName : string.Empty) );
            Console.WriteLine(string.Join(" ", primeList));
        }


    }
}
