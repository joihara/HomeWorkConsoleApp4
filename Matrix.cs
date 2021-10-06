using System;

namespace HomeWorkConsoleApp4
{
    public class Matrix
    {
        public int[,] matrix;

        public Matrix(int row, int col) {
            MatrixCreate(row, col);
        }

        private void MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0. Проверка входных параметров опущена.
            matrix = new int[rows, cols];
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    matrix[x,y] = 0; // автоинициализация в 0
        }

        public void RandomGenerated(int minVal, int maxVal)
        {
            // Возвращаем матрицу со значениями
            // в диапазоне от minVal до maxVal
            Random ran = new();
            
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i,j] = ran.Next(minVal, maxVal);
        }

        /// <summary>
        /// Печать матриц
        /// </summary>
        /// <param name="matrix"></param>
        public void Print()
        {
            for (int i = 0; i < RowsCount(); i++) { 
                for (int j = 0; j < ColumnsCount(); j++) {
                    Console.Write($"{matrix[i, j],7}");
                }
                Console.WriteLine();
            }
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Для матриц с разным размером умножение не возможно!");
            }

            var matrixC = new Matrix(matrixA.RowsCount(), matrixB.ColumnsCount());

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC.matrix[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC.matrix[i, j] += matrixA.matrix[i, k] * matrixB.matrix[k, j];
                    }
                }
            }

            return matrixC;
        }

        public static Matrix operator *(Matrix matrixA, int chislo)
        {
            var matrixC = new Matrix(matrixA.RowsCount(), matrixA.ColumnsCount());
            for (int i = 0; i < matrixA.RowsCount(); i++)
            {
                for (int j = 0; j < matrixA.ColumnsCount(); j++)
                {
                    matrixC.matrix[i, j] = matrixA.matrix[i, j] * chislo;
                }
            }
            return matrixC;
        }

        // метод для сложения двух матриц
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            if ((matrixA.ColumnsCount() != matrixB.ColumnsCount()) || (matrixA.RowsCount() != matrixB.RowsCount()))
            {
                throw new Exception("Для матриц с разным размером сложение не возможно!");
            }

            var matrixC = new Matrix(matrixA.RowsCount(), matrixB.ColumnsCount());

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC.matrix[i, j] = matrixA.matrix[i, j] + matrixB.matrix[i, j];
                }
            }

            return matrixC;
        }

        // метод для вычитания двух матриц
        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            if ((matrixA.ColumnsCount() != matrixB.ColumnsCount()) || (matrixA.RowsCount() != matrixB.RowsCount()))
            {
                throw new Exception("Для матриц с разным размером вычитание не возможно!");
            }

            var matrixC = new Matrix(matrixA.RowsCount(), matrixB.ColumnsCount());

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC.matrix[i, j] = matrixA.matrix[i, j] - matrixB.matrix[i, j];
                }
            }

            return matrixC;
        }

        private int RowsCount()
        {
            return matrix.GetLength(0);
        }

        private int ColumnsCount()
        {
            return matrix.GetLength(1);
        }
    }
}
