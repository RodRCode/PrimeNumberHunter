using System;
using System.Collections.Generic;

namespace PrimeNumberHunter
{
    class MainClass
    {
        static List<int> primes = new List<int>();

        public static void Main(string[] args)
        {
            Console.Write($"Enter the upper bound you want to go to {int.MaxValue}: ");
            string upperLimit = Console.ReadLine();
            int n = int.Parse(upperLimit);

            DateTime start = DateTime.Now;
            List<bool> primeTest = GeneratePrimeList(n);
            DateTime end = DateTime.Now;

            Console.WriteLine($"OK, list is generated, it took  {end - start}");

            primes.Add(2);

            start = DateTime.Now;
            SieveOfEratosthenes(n, primeTest);
            end = DateTime.Now;

            Console.WriteLine($"The Sieve of Eratosthenes took {end - start} ");

            GetListOfPrimes(primeTest);
            Console.WriteLine($"and found {primes.Count} primes from 2 - {n}");

            Console.WriteLine("Hit any key to see the list of primes found");
            Console.ReadKey();
            PrintListOfPrimes();
        }

        private static void PrintListOfPrimes()
        {
            foreach (var num in primes)
            {
                Console.WriteLine(num);
            }
        }

        private static void GetListOfPrimes(List<bool> primeTest)
        {
            primes.Clear();
            int i = 0;
            foreach (var num in primeTest)
            {
                if (num == true)
                {
                    primes.Add(i);
                }
                i++;
            }
        }

        private static void SieveOfEratosthenes(int n, List<bool> primeTest)
        {
            for (int i = 0; i < n; i++)
            {
                if (primeTest[i] == true)
                {
                    int j = 2;
                    while (i * j < n)
                    {
                        primeTest[i * j] = false;
                        j++;
                    }
                }
            }
        }

        static private List<bool> GeneratePrimeList(int n)
        {
            List<bool> primeTest = new List<bool>();
            for (int i = 0; i < n; i++)
            {
                primeTest.Add(true);
            }
            primeTest[0] = false;
            primeTest[1] = false;

            return primeTest;
        }
    }
}

