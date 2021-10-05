using System;

namespace HomeWorkConsoleApp4
{
    public struct StructFinancesCompany
    {
        public int monthNumber; // номер месяца
        public int income; // доход
        public int consumption; // расход
        public int profit; // прибыль

        public void SetMonthNumber(int number) {
            monthNumber = number;
        }

        public void GenerateNumbers() {
            Random randomizer = new();
            income = randomizer.Next(10000);
            consumption = randomizer.Next(10000);
            profit = income - consumption;
        }

        public string GetInfoFinances() {
            return $"Месяц {monthNumber,10}\n" +
                $"Доход {income,10}\n" +
                $"Расход {consumption,9}\n" +
                $"Прибыль {profit,8}\n" +
                $"=============================";
        }
    }
}
