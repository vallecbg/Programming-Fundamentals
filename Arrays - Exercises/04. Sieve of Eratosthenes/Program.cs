﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var arrInput = new int[n + 1];
            bool[] checkNums = new bool[n + 1];

            string primeNums = null;

            for (int i = 0; i <= n; i++)
            {
                arrInput[i] = i;
                checkNums[i] = true;
            }

            primeNums = SieveOfErat(arrInput, checkNums, primeNums);

            Console.WriteLine(primeNums.Trim());
        }

        static string SieveOfErat(int[] arrInput, bool[] checkNums, string primeNums)
        {
            checkNums[0] = false;
            checkNums[1] = false;

            for (int i = 0; i < arrInput.Length; i++)
            {
                if (checkNums[i])
                {
                    primeNums += $"{arrInput[i]} ";

                    for (int j = i + 1; j < arrInput.Length; j++)
                    {
                        if (arrInput[j] % i == 0 && checkNums[j] == true)
                        {
                            checkNums[j] = false;
                        }
                    }
                }
            }

            return primeNums;
        }
    }
}
