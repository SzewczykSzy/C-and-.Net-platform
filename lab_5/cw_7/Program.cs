using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_7
{
    internal class Program
    {
        public class Matrix
        {
            int[] _matrix;
            int c;
            int l;
            public Matrix(int rows, int cols, int[] values) 
            {
                l = rows;
                c = cols;
                _matrix = new int[rows * cols];

                for (int i = 0; i < _matrix.Length; i++)
                {
                    _matrix[i] = i < values.Length ? values[i] : 0;
                }
            }
            public void AddElem(int row, int column, int value)
            {
                if (row >= 0 && row < l && column >= 0 && column < c)
                {
                    _matrix[row * c + column] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Row or column is out of range.");
                }
            }
            public (int columns, int rows) GetSize()
            {
                return (c, l);
            }
            public int[] GetMatrixCopy()
            {
                return (int[])_matrix.Clone();
            }
            public static Matrix AddMatrix(Matrix m1, Matrix m2)
            {
                int maxRows = Math.Max(m1.l, m2.l);
                int maxColumns = Math.Max(m1.c, m2.c);
                int[] resultValues = new int[maxRows * maxColumns];

                for (int row = 0; row < maxRows; row++)
                {
                    for (int column = 0; column < maxColumns; column++)
                    {
                        int index = row * maxColumns + column;
                        int val1 = (row < m1.l && column < m1.c) ? m1._matrix[row * m1.c + column] : 0;
                        int val2 = (row < m2.l && column < m2.c) ? m2._matrix[row * m2.c + column] : 0;
                        resultValues[index] = val1 + val2;
                    }
                }
                return new Matrix(maxRows, maxColumns, resultValues);
            }
        }
        static void Main(string[] args)
        {
            int[] values1 = { 1, 1, 3, 4, 5, 6 };
            Matrix matrix1 = new Matrix(2, 3, values1);

            int[] values2 = { 7, 8, 9, 10, 11, 12, 13 };
            Matrix matrix2 = new Matrix(3, 2, values2);
            Console.WriteLine(matrix1.ToString());

            matrix1.AddElem(1, 2, 99);

            var size = matrix1.GetSize();
            Console.WriteLine(size);

            int[] matrixCopy = matrix1.GetMatrixCopy();

            Matrix resultMatrix = Matrix.AddMatrix(matrix1, matrix2);
            Console.WriteLine(resultMatrix);
            Console.ReadLine();
        }
    }
}
