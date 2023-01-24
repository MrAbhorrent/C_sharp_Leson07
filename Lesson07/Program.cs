using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson07
{
    class Program
    {
        private static int screenWidth = 119;
        private static String divider = new String('=', screenWidth);

        private static void Divider( int _size )
        {
            String _divider = new String('=', _size);
            Console.WriteLine(_divider);
        }

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

        private static int[,] CreateRandom2DArray( int _sizeM, int _sizeN, int _minValue, int _maxValue )
        {
            Random rnd = new Random();
            int[,] array = new int[_sizeM, _sizeN];
            for (int i = 0; i < _sizeM; i++)
            {
                for (int j = 0; j < _sizeN; j++)
                {
                    array[i, j] = rnd.Next((int)_minValue, (int)_maxValue - 1);
                }
            }
            return array;
        }

        public class TPoint
        {
            private int row;
            private int column;

            public TPoint( int _row, int _column )
            {
                setRow(_row);
                setColumn(_column);
            }

            public void setRow( int _x )
            {
                this.row = _x;
            }

            public void setColumn( int _y )
            {
                this.column = _y;
            }

            public int getRow()
            {
                return this.row;
            }

            public int getColumn()
            {
                return this.column;
            }

            public override String ToString()
            {
                return String.Format("({0,3}; {1,3})", this.row, this.column);
            }
        }

        private static int FindElementIn2DArray( TPoint _point, int[,] _array )
        {
            return _array[_point.getRow(), _point.getColumn()];
        }

        private static double[] AverageColumnFromArray( int[,] _array )
        {
            double sum;
            double[] array = new double[_array.GetLength(1)];
            for (int i = 0; i < _array.GetLength(1); i++)
            {
                sum = 0;
                for (int j = 0; j < _array.GetLength(0); j++)
                {
                    sum = sum + (double)_array[i, j];
                }
                array[i] = sum / _array.GetLength(0);                
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
                            Console.Write("{0,6}", _array[i, j]);
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

        private static void PrintArray<T>( T[] _array )
        {
            if (_array.Length > 0)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.Write("[");
                for (int i = 0; i < _array.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (_array[i] is double)
                    {
                        Console.Write("{0,6:F2}", _array[i]);
                    }
                    else
                    {
                        Console.Write("{0,6}", _array[i]);
                    }
                    Console.ForegroundColor = color;
                    if (i == _array.Length - 1)
                    {
                        Console.Write("]");
                    }
                    else
                    {
                        Console.Write(", ");
                    }
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
            double[,] array1 = CreateRandom2DArray(_sizeM: 3, _sizeN: 4, _minValue: -100f, _maxValue: 101f);
            Print2DArray(array1);

            Divider(screenWidth);

            //Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
            //Например, задан массив:
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //1 7 -> элемента с такими индексами в массиве нет
            Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
            int[,] array2 = CreateRandom2DArray(_sizeM: 3, _sizeN: 4, _minValue: -100, _maxValue: 101);
            Print2DArray(array2);
            Console.Write("Введите номер строки (k): ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер столбца (n): ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (k > 0 && k <= array2.GetLength(0)  && n > 0 && n <= array2.GetLength(1))
            {
                TPoint point = new TPoint(_row: k - 1, _column: n -1);
                Console.WriteLine("Элемент с индексами ({0}, {1}) = {2}", k, n, FindElementIn2DArray(_point: point, _array: array2));
            }
            else
            {
                Console.WriteLine("Индекс выходит за границы диапазона. Элемента с такими индексами ({0}, {1}) в массиве нет", k, n);
            }
            Divider(screenWidth);
            //Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
            //Например, задан массив:
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
            int[,] array3 = CreateRandom2DArray(_sizeM: 4, _sizeN: 4, _minValue: -100, _maxValue: 101);
            Print2DArray(array3);
            double[] array4 = AverageColumnFromArray(array3);
            Divider(32);
            PrintArray(array4); 
            Console.WriteLine();
            Console.WriteLine(divider);

            Console.ReadKey();
        }

        
    }
}
