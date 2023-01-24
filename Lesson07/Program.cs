using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson07
{
    class Program
    {
        private static String divider = new String('=', 119);
        
        private static double[,] CreateRandom2DArray( int _sizeM, int _sizeN, double _minValue, double _maxValue )
        {
            Random rnd = new Random();
            double[,] array = new double[_sizeM, _sizeN];
            for (int i = 0; i < _sizeM; i++)
            {
                for (int j = 0; j < _sizeN; j++)
                {
                    array[i,j] = rnd.Next((int)_minValue, (int)_maxValue - 1) + rnd.NextDouble();
                }                
            }
            return array;
        }

        private static void Print2DArray<T>( T[,] _array )
        {
            if (_array.GetLength(0) > 0 && _array.GetLength(1) > 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                for (int i = 0; i < _array.GetLength(0); i++ )
                {
                    Console.Write("[");
                    for (int j = 0; j < _array.GetLength(1); j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (_array[i, j] is double)
                        {
                            Console.Write("{0,6:F2}", _array[i, j]);
                        }
                        else
                        {
                            Console.Write("{0},6", _array[i, j]);
                        }
                        Console.ForegroundColor = color;
                        if (j == _array.GetLength(1) - 1)
                        {
                            Console.Write("]");
                        }
                        else
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = color;
            }
        }
        
        static void Main( string[] args )
        {
            //Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
            //m = 3, n = 4.
            //0,5 7 -2 -0,2
            //1 -3,3 8 -9,9
            //8 7,8 -7,1 9
            Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
            double[,] array1 = CreateRandom2DArray(_sizeM: 3, _sizeN: 4, _minValue: -100, _maxValue: 101);
            Print2DArray(array1);

            Console.WriteLine(divider);
            //Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
            //Например, задан массив:
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //1 7 -> элемента с такими индексами в массиве нет
            Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");

            Console.WriteLine(divider);
            //Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
            //Например, задан массив:
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

                        
            Console.WriteLine(divider);

            Console.ReadKey();
        }
    }
}
