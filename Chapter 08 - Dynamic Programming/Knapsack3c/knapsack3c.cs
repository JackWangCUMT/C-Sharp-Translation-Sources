﻿namespace Knapsack3c
{
    using System;

    internal class Knapsack3C
    {
        private const int MaxN = 30;
        private const int MaxCapacity = 1000;
        private const int TotalCapacity = 15; /* Обща вместимост на раницата */
        private const int N = 6; /* Брой предмети */

        private static readonly int[] Weights = new int[] { 0, 1, 2, 3, 5, 6, 7 }; /* Тегло на предметите */
        private static readonly int[] Values = new int[] { 0, 1, 10, 19, 22, 25, 30 }; /* Стойност на предметите */

        internal static void Main()
        {
            Console.WriteLine("Брой предмети: {0}", N);
            Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
            Console.WriteLine("Максимална постигната ценност: {0}", Calculate());
        }

        /* Пресмята стойностите на целевата функция */
        private static int Calculate()
        {
            int[] f = new int[MaxCapacity]; /* Целева функция */
            int[] oldF = new int[MaxCapacity];

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= TotalCapacity; j++)
                {
                    if (j >= Weights[i] && oldF[j] < oldF[j - Weights[i]] + Values[i])
                    {
                        f[j] = oldF[j - Weights[i]] + Values[i];
                    }
                    else
                    {
                        f[j] = oldF[j];
                    }
                }

                for (int k = 0; k < TotalCapacity; k++)
                {
                    oldF[k] = f[k];
                }
            }

            return f[TotalCapacity];
        }
    }
}