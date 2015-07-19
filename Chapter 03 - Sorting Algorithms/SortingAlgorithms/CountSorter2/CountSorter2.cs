﻿namespace CountSorter2
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class CountSorter2
    {
        private const int MaxValue = 100;
        private static Random rand = new Random();

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] array = new Element[MaxValue];
            Element[] saveArray = new Element[MaxValue];
            Initialize(array);
            Array.Copy(array, saveArray, array.Length); /* Запазва се копие на масива */
            Console.WriteLine("Масивът преди сортирането");
            Print(array);
            CountSort(array);
            Console.WriteLine("Масивът след сортирането");
            Print(array);

            Check(array, saveArray);
        }

        private static void Initialize(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Key = rand.Next() % MaxValue;
            }
        }

        private static void Print(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i].Key);
            }

            Console.WriteLine();
        }

        private static void CountSort(Element[] array)
        {
            List[] list = new List[MaxValue];

            /* 1. Разпределяне на елементите по списъци */
            for (int i = 0; i < MaxValue; i++)
            {
                list[i] = null;
            }

            /* 1.2. Добавяне на елемента в началото на списъка */
            List p;
            for (int i = 0; i < array.Length; i++)
            {
                p = new List
                {
                    Data = array[i],
                    Next = list[array[i].Key]
                };

                list[array[i].Key] = p;
            }

            /* 2. Извеждане на ключовете на сортираната последователност */
            for (int i = 0, j = 0; i < MaxValue; i++)
            {
                while ((p = list[i]) != null)
                {
                    array[j++] = list[i].Data;
                    list[i] = list[i].Next;
                }
            }
        }

        private static void Check(Element[] array, Element[] coppiedArray)
        {
            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 0; i < array.Length - 1; i++)
            {
                Debug.Assert(array[i].Key <= array[i + 1].Key, "Wrong order");
            }

            /* 2. Проверка за пермутация на изходните елементи */
            bool[] found = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j;
                for (j = 0; j < array.Length; j++)
                {
                    if (!found[j] && array[i].Equals(coppiedArray[j]))
                    {
                        found[j] = true;
                        break;
                    }
                }

                Debug.Assert(j < array.Length, "No element found"); /* Пропада, ако не е намерен съответен */
            }
        }
    }
}