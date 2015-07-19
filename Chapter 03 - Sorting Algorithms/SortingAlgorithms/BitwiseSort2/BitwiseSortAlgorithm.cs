﻿namespace BitwiseSort2
{
    using System;
    using System.Text;

    public class BitwiseSortAlgorithm
    {
        private const int MaxValue = 100;
        private const int TestsCount = 100;
        private static readonly Random Rand = new Random();

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] elements = new Element[MaxValue];
            for (int i = 0; i < TestsCount; i++)
            {
                Console.WriteLine("----------Тест " + i + "----------");
                Initialize(elements, MaxValue);
                Console.WriteLine("Масив преди сортиране : ");
                PrintElements(elements);
                uint bitMask = (uint)int.MaxValue + 1;
                BitwiseSort(elements, 0, MaxValue - 1, bitMask);
                Console.WriteLine("Масив след сортиране : ");
                PrintElements(elements);
                Check(elements);
            }
        }

        private static void Initialize(Element[] elements, int maxValue)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new Element
                {
                    Key = Rand.Next(0, maxValue * 2)
                };
            }
        }

        private static void SwapValues(ref Element first, ref Element second)
        {
            Element oldValue = first;
            first = second;
            second = oldValue;
        }

        private static void BitwiseSort(Element[] elements, int leftIndex, int rightIndex, uint bitMask)
        {
            if (rightIndex > leftIndex && bitMask > 0)
            {
                int i = leftIndex;
                int j = rightIndex;
                while (j != i)
                {
                    while ((elements[i].Key & bitMask) != bitMask && i < j)
                    {
                        i++;
                    }

                    while ((elements[j].Key & bitMask) == bitMask && i < j)
                    {
                        j--;
                    }

                    SwapValues(ref elements[i], ref elements[j]);
                }

                if ((elements[rightIndex].Key & bitMask) != bitMask)
                {
                    j++; 
                }

                BitwiseSort(elements, leftIndex, j - 1, bitMask >> 1);
                BitwiseSort(elements, j, rightIndex, bitMask >> 1);
            }
        }

        private static void PrintElements(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write("{0} ", elements[i].Key);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void Check(Element[] elements)
        {
            bool isSorted = true;
            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i].Key > elements[i + 1].Key)
                {
                    isSorted = false;
                    break;
                }
            }

            if (!isSorted)
            {
                throw new Exception("Масивът не е сортиран правилно.");
            }
        }
    }
}
