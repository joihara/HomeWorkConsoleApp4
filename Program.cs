using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            var financesCompanies = GenerateParametr(12);

            foreach (var item in financesCompanies)
            {
                Console.WriteLine(item.GetInfoFinances());
            }

            Sorted(financesCompanies);



            var positiveProfits = financesCompanies.Where(financeCompany => financeCompany.profit >= 0);

            int CountProfit = positiveProfits.Count();
            Console.WriteLine($"Количество месяцев с положительной прибылью: {CountProfit}\n");

            RemoveRepeatValues(financesCompanies);
            var negativeProfits = financesCompanies.Where(financeCompany => financeCompany.profit < 0);
            Console.WriteLine($"Количество месяцев с отриательной прибылью: {negativeProfits.Count()}\n");


            var RangeMonth = Math.Clamp(CountProfit, 0, 3);
            List<StructFinancesCompany> financesCompaniesThreePosotive = new();
            for (int index = 1; index <= RangeMonth; index++)
            {
                financesCompaniesThreePosotive.Add(financesCompanies[index - 1]);
            }

            Console.WriteLine($"{RangeMonth} месяца с наименьшей прибылью");
            foreach (var item in financesCompaniesThreePosotive)
            {
                Console.WriteLine($"Месяц: {item.monthNumber} прибыль: {item.profit}");
            }
            //2 задание
            Console.WriteLine($"Для перехода к заданию №2 нажмите любую клавишу");
            Console.ReadLine();
            Console.Clear();
            PascalTriangle(10);
            //3 задание
            Console.WriteLine($"Для перехода к заданию №3 нажмите любую клавишу");
            Console.ReadLine();
            Console.Clear();
            //Генерация матриц
            var Matrix1 = MatrixRandom(4, 4, 0, 99);
            var Matrix2 = MatrixRandom(4, 4, 0, 99);
            Console.WriteLine($"1-я матрица");
            PrintMatrix(Matrix1);
            Console.WriteLine($"2-я матрица");
            PrintMatrix(Matrix2);
            var okSizeMatrix = EqualsSizeMatrix(Matrix1, Matrix2);
            var matrixMultiplicationByNumber = MatrixMultiplicationByNumber(Matrix1, 7);
            Console.WriteLine($"Умножение 1-й матрицы на число 7");
            PrintMatrix(matrixMultiplicationByNumber);

            if (okSizeMatrix)//Проверка если матрицы разных размеров
            {
                Console.WriteLine($"Сложение матриц");
                var matrixOperationAddition = MatrixOperation(Matrix1, Matrix2, EnumTypeOperation.Addition);
                PrintMatrix(matrixOperationAddition);
                Console.WriteLine($"Вычитание матриц");
                var matrixOperationSubtraction = MatrixOperation(Matrix1, Matrix2, EnumTypeOperation.Subtraction);
                PrintMatrix(matrixOperationSubtraction);
                Console.WriteLine($"Умножение двух матриц");
                var matrixOperationMultiplication = MatrixOperation(Matrix1, Matrix2, EnumTypeOperation.Multiplication);
                PrintMatrix(matrixOperationMultiplication);

            }
            else {
                Console.WriteLine($"Матрицы имеют разные размеры");
            }
            Console.ReadLine();
        }
        



        #region Work1
        /// <summary>
        /// Удаление повторяющихся значений прибыли из массива
        /// </summary>
        /// <param name="positiveProfits"></param>
        private static void RemoveRepeatValues(IEnumerable<StructFinancesCompany> positiveProfits)
        {
            List<StructFinancesCompany> financesCompaniesNoRepeat = new();

            foreach (var item in positiveProfits)
            {
                if (!financesCompaniesNoRepeat.All(financesCompanies => financesCompanies.profit == item.profit) || financesCompaniesNoRepeat.Count == 0)
                {
                    financesCompaniesNoRepeat.Add(item);
                }
            }

            positiveProfits = financesCompaniesNoRepeat.ToArray();
        }

        /// <summary>
        /// Генерация массива со случайными значениями
        /// </summary>
        /// <param name="SizeArray">Размер массива длягенераци</param>
        /// <returns></returns>
        private static StructFinancesCompany[] GenerateParametr(int SizeArray) {
            StructFinancesCompany[] financesCompanies = new StructFinancesCompany[SizeArray];

            for (int index = 0; index < financesCompanies.Length; index++)
            {
                financesCompanies[index].SetMonthNumber(index + 1);
                financesCompanies[index].GenerateNumbers();
            }
            return financesCompanies;
        }

        /// <summary>
        /// Сортировка прибыли компании по возврастанию
        /// </summary>
        /// <param name="financesCompanies">Массив с данными</param>
        private static void Sorted(StructFinancesCompany[] financesCompanies) {
            StructFinancesCompany temp;
            for (int index = 0; index < financesCompanies.Length - 1; index++) //Перебор всех занчений в массиве
            {
                for (int indexSort = index + 1; indexSort < financesCompanies.Length; indexSort++) //Перебор значений в масиве
                {
                    if (financesCompanies[index].profit > financesCompanies[indexSort].profit) //Поиск удовлетворяющий условию значений
                    {
                        temp = financesCompanies[index];                            // Сохранение во временную переменную
                        financesCompanies[index] = financesCompanies[indexSort];    // Перемещение значений в массиве
                        financesCompanies[indexSort] = temp;                        // 
                    }
                }
            }
        }
        #endregion
        #region Work2

        /// <summary>
        /// Расчёт факториала
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Factorial(int n)
        {
            int temp = 1;
            for (int index = 1; index <= n; index++)
            {
                temp *= index;
            }
            return temp;
        }
        /// <summary>
        /// Отрисовка треугольника паскаля
        /// </summary>
        /// <param name="n">Количество строк</param>
        private static void PascalTriangle(int n)
        {
            for (int indexX = 0; indexX < n; indexX++)
            {
                for (int indexY = 0; indexY <= indexX; indexY++)
                {
                    int value = Factorial(indexX) / (Factorial(indexY) * Factorial(indexX - indexY));
                    Console.Write($"{value,5}"); //Вычисления элементов треугольника
                }
                Console.WriteLine("\n");
            }
        }
        #endregion
        #region Work3

        private static int[][] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0.0. Проверка входных параметров опущена.
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new int[cols]; // автоинициализация в 0.0
            return result;
        }

        private static int[][] MatrixRandom(int rows, int cols, int minVal, int maxVal)
        {
            // Возвращаем матрицу со значениями
            // в диапазоне от minVal до maxVal
            Random ran = new();
            var result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j] = ran.Next(minVal,maxVal);
            return result;
        }

        /// <summary>
        /// умножение матрицы на число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int[][] MatrixMultiplicationByNumber(int[][] matrix, int number) {
            List<int[]> temp = new();
            List<int> tempY = new();
            foreach (var itemX in matrix)
            {
                foreach (var itemY in itemX)
                {
                    tempY.Add(itemY * number);
                }
                temp.Add(tempY.ToArray());
                tempY.Clear();
            }
            return temp.ToArray();
        }
        /// <summary>
        /// Проверка на одинаковый размер матриц
        /// </summary>
        /// <param name="Matrix1"></param>
        /// <param name="Matrix2"></param>
        /// <returns></returns>
        private static bool EqualsSizeMatrix(int[][] Matrix1, int[][] Matrix2) {
            int SizeMatrix1X = Matrix1.Length;
            int SizeMatrix1Y = Matrix1[0].Length;
            int SizeMatrix2X = Matrix2.Length;
            int SizeMatrix2Y = Matrix2[0].Length;
            return SizeMatrix1X == SizeMatrix2X && SizeMatrix1Y == SizeMatrix2Y;
        }
        /// <summary>
        /// Оператор работы с матрицами
        /// </summary>
        /// <param name="input">первая матрица</param>
        /// <param name="added">вторая матрица</param>
        /// <param name="EnumTypeOperation">Тип операци</param>
        /// <returns></returns>
        private static int[][] MatrixOperation(int[][] input, int[][] added, EnumTypeOperation EnumTypeOperation) {
            int[][] temp = new int[input.Length][];
            for (int index = 0; index < input.Length; index++)
            {
                temp[index] = new int[input[index].Length];
                for (int iterator = 0; iterator < input[index].Length; iterator++)
                {
                    switch (EnumTypeOperation)
                    {
                        case EnumTypeOperation.Addition:
                            temp[index][iterator] = input[index][iterator] + added[index][iterator];
                            break;
                        case EnumTypeOperation.Subtraction:
                            temp[index][iterator] = input[index][iterator] - added[index][iterator];
                            break;
                        case EnumTypeOperation.Multiplication:
                            temp[index][iterator] = input[index][iterator] * added[index][iterator];
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            return temp;
        }

        /// <summary>
        /// Печать матриц
        /// </summary>
        /// <param name="matrix"></param>
        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var itemX in matrix)
            {
                foreach (var itemY in itemX)
                {
                    Console.Write($"{itemY,5}");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
