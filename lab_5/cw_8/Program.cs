using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_8
{
    internal class Program
    {
        public class Matrix
        {
            protected int[][] _matrix;
            protected int c;
            protected int l;

            public Matrix(int rows, int columns, int[] values)
            {
                l = rows;
                c = columns;
                _matrix = new int[rows][];

                for (int i = 0; i < rows; i++)
                {
                    _matrix[i] = new int[columns];
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int index = i * columns + j;
                        _matrix[i][j] = index < values.Length ? values[index] : 0;
                    }
                }
            }

            public static Matrix Add(Matrix m1, Matrix m2)
            {
                int maxRows = Math.Max(m1.l, m2.l);
                int maxColumns = Math.Max(m1.c, m2.c);
                int[] resultValues = new int[maxRows * maxColumns];

                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < maxColumns; j++)
                    {
                        int val1 = (i < m1.l && j < m1.c) ? m1._matrix[i][j] : 0;
                        int val2 = (i < m2.l && j < m2.c) ? m2._matrix[i][j] : 0;
                        resultValues[i * maxColumns + j] = val1 + val2;
                    }
                }

                return new Matrix(maxRows, maxColumns, resultValues);
            }

            public static Matrix Subtract(Matrix m1, Matrix m2)
            {
                int maxRows = Math.Max(m1.l, m2.l);
                int maxColumns = Math.Max(m1.c, m2.c);
                int[] resultValues = new int[maxRows * maxColumns];

                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < maxColumns; j++)
                    {
                        int val1 = (i < m1.l && j < m1.c) ? m1._matrix[i][j] : 0;
                        int val2 = (i < m2.l && j < m2.c) ? m2._matrix[i][j] : 0;
                        resultValues[i * maxColumns + j] = val1 - val2;
                    }
                }
                return new Matrix(maxRows, maxColumns, resultValues);
            }

            public void Display()
            {
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        Console.Write(_matrix[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            int[] values1 = { 1, 1, 1, 2, 2, 2 };
            Matrix matrix1 = new Matrix(2, 3, values1);
            matrix1.Display();
            Console.WriteLine();

            int[] values2 = { 2, 2, 2, 3, 3, 3 };
            Matrix matrix2 = new Matrix(2, 3, values2);
            matrix2.Display();

            Matrix sumMatrix = Matrix.Add(matrix1, matrix2);
            Console.WriteLine("Dodawanie:");
            sumMatrix.Display();

            Matrix diffMatrix = Matrix.Subtract(matrix1, matrix2);
            Console.WriteLine("\nOdejmowanie:");
            diffMatrix.Display();
            Console.ReadLine();
        }
    }
}
