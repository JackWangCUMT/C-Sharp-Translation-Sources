﻿namespace A_Center
{
    using System;

    public class ACenter
    {
        private const int VerticesCount = 6;
        private const int MaxValue = 1000000;

        private static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0 }
        };

        internal static void Main()
        {
            Floyd();
            FindCenter();
        }

        // Намира дължината на минималния път между всяка двойка върхове
        private static void Floyd()
        {
            InitializeGraph();

            // Алгоритъм на Флойд
            for (int k = 0; k < VerticesCount; k++)
            {
                for (int i = 0; i < VerticesCount; i++)
                {
                    for (int j = 0; j < VerticesCount; j++)
                    {
                        if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                        {
                            Graph[i, j] = Graph[i, k] + Graph[k, j];
                        }
                    }
                }
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                Graph[i, i] = 0;
            }
        }

        private static void InitializeGraph()
        {
            // Стойностите 0 се променят на MaxValue
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (Graph[i, j] == 0)
                    {
                        Graph[i, j] = MaxValue;
                    }
                }
            }
        }

        private static void FindCenter()
        {
            int center = 0;
            int min = MaxValue;
            int max = int.MinValue;
            /* Sot(Xi) = max { Vj [d(Xi, Xj) + d[Xj, Xi])] }, центърът е върхът X*,
         * за който Sot(X*) е минимално */
            for (int i = 0; i < VerticesCount; i++)
            {
                max = Graph[i, 0] + Graph[0, i];
                for (int j = 0; j < VerticesCount; j++)
                {
                    if ((i != j) && (Graph[i, j] + Graph[j, i]) > max)
                    {
                        max = Graph[i, j] + Graph[j, i];
                    }
                }

                if (max < min)
                {
                    min = max;
                    center = i;
                }
            }

            Console.WriteLine("Центърът на графа е връх {0}", center + 1);
            Console.WriteLine("Радиусът на графа е {0}", min);
        }
    }
}