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
            PascalTriangle(5);
            //3 задание
            Console.WriteLine($"Для перехода к заданию №3 нажмите любую клавишу");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"1-я матрица");
            var Matrix1 = new Matrix(4, 4);
            Matrix1.RandomGenerated(0, 99);
            Matrix1.Print();
            Console.WriteLine($"2-я матрица");
            var Matrix2 = new Matrix(4, 4);
            Matrix2.RandomGenerated(0, 99);
            Matrix2.Print();
            Console.WriteLine($"Умножение 1-й матрицы на число 7");
            var matrixMultiplicationByNumber = Matrix1 * 7;
            matrixMultiplicationByNumber.Print();
            Console.WriteLine($"Сложение матриц");
            var matrixOperationAddition = Matrix1 + Matrix2;
            matrixOperationAddition.Print();
            Console.WriteLine($"Вычитание матриц");
            var matrixOperationSubtraction = Matrix1 - Matrix2;
            matrixOperationSubtraction.Print();
            Console.WriteLine($"Умножение двух матриц");
            var matrixOperationMultiplication = Matrix1 * Matrix2;
            matrixOperationMultiplication.Print();

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
                Console.Write(new string(' ', (n - indexX)*2));
                for (int indexY = 0; indexY <= indexX; indexY++)
                {
                    
                    int value = Factorial(indexX) / (Factorial(indexY) * Factorial(indexX - indexY));
                    Console.Write($"{value}   "); //Вычисления элементов треугольника
                }
                Console.WriteLine("\n");
            }
        }
        #endregion
    }
}
