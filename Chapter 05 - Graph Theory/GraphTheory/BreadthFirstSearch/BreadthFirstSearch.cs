﻿namespace BreadthFirstSearch
{
    using System;
    using System.Collections.Generic;

    public class BreadthFirstSearch
    {
        private const int VerticesCount = 14;
        private const int StartVertex = 5;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];

        internal static void Main()
        {
            Console.WriteLine("Обхождане в ширина от връх {0}:", StartVertex);
            Bfs(StartVertex - 1);
        }

        private static void Bfs(int startVertex)
        {
            Queue<int> verticesQueue = new Queue<int>();
            verticesQueue.Enqueue(startVertex);
            Used[startVertex] = true;
            int levelVertex = 1;
            while (verticesQueue.Count > 0)
            {
                for (int i = 0; i < levelVertex; i++)
                {
                    int currentVertex = verticesQueue.Dequeue();
                    Console.Write("{0} ", currentVertex + 1);

                    for (int j = 0; j < VerticesCount; j++)
                    {
                        if (Graph[currentVertex, j] == 1 && !Used[j])
                        {
                            verticesQueue.Enqueue(j);
                            Used[j] = true;
                        }
                    }
                }

                Console.WriteLine();
                levelVertex = verticesQueue.Count;
            }
        }
    }
}