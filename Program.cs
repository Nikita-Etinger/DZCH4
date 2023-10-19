using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    class Converter
    {
        public int ConvertToDecimal(string input, int fromBase)
        {
            try
            {
                int decimalValue = Convert.ToInt32(input, fromBase);
                return decimalValue;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный формат числа.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число вышло за пределы диапазона типа int.");
            }

            return -1;
        }

        public string ConvertFromDecimal(int decimalValue, int toBase)
        {
            return Convert.ToString(decimalValue, toBase);
        }
    }
    public enum NumberWords
    {
        Ноль = 0,
        Один = 1,
        Два = 2,
        Три = 3,
        Четыре = 4,
        Пять = 5,
        Шесть = 6,
        Семь = 7,
        Восемь = 8,
        Девять = 9
    }
    class Passport
    {
        public string PassportNumber { get; private set; }
        public string FullName { get; private set; }
        public DateTime DateOfIssue { get; private set; }

        public Passport(string passportNumber, string fullName, DateTime dateOfIssue)
        {
            if (string.IsNullOrWhiteSpace(passportNumber))
            {
                throw new ArgumentException("Номер паспорта не может быть пустым или содержать только пробелы.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("ФИО владельца не может быть пустым или содержать только пробелы.");
            }

            if (dateOfIssue > DateTime.Now)
            {
                throw new ArgumentException("Дата выдачи не может быть в будущем.");
            }

            PassportNumber = passportNumber;
            FullName = fullName;
            DateOfIssue = dateOfIssue;
        }
    }

    class Program
    {

        static void PassCreator()
        {
            try
            {
                string passportNumber = "AB1234567"; 
                string fullName = "Иванов Иван Иванович"; 
                DateTime dateOfIssue = new DateTime(2022, 1, 15);

                Passport passport = new Passport(passportNumber, fullName, dateOfIssue);

                Console.WriteLine("Информация о паспорте:");
                Console.WriteLine($"Номер паспорта: {passport.PassportNumber}");
                Console.WriteLine($"ФИО владельца: {passport.FullName}");
                Console.WriteLine($"Дата выдачи: {passport.DateOfIssue.ToShortDateString()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка инициализации паспорта: {ex.Message}");
            }
        }
        static void ConverterMenu()
        {
            Converter converter = new Converter();

            Console.WriteLine("Выберите направление перевода:");
            Console.WriteLine("1. Из десятичной в другую систему");
            Console.WriteLine("2. Из другой системы в десятичную");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Введите число в десятичной системе: ");
                string input = Console.ReadLine();
                Console.Write("Введите целевую систему исчисления (2, 8, 16 и т.д.): ");
                int targetBase = int.Parse(Console.ReadLine());

                int decimalValue = converter.ConvertToDecimal(input, 10);
                if (decimalValue != -1)
                {
                    string result = converter.ConvertFromDecimal(decimalValue, targetBase);
                    Console.WriteLine($"Результат: {result}");
                }
            }
            else if (choice == 2)
            {
                Console.Write("Введите число в другой системе исчисления: ");
                string input = Console.ReadLine();
                Console.Write("Введите основание системы (2, 8, 16 и т.д.): ");
                int sourceBase = int.Parse(Console.ReadLine());

                int decimalValue = converter.ConvertToDecimal(input, sourceBase);
                if (decimalValue != -1)
                {
                    Console.WriteLine($"Результат: {decimalValue}");
                }
            }
            else
            {
                Console.WriteLine("Неправильный выбор.");
            }
        }
        static void Q2()
        {
            Console.Write("Введите слово для перевода в цифру (Ноль, Один, Два, и т.д.): ");
            string userInput = Console.ReadLine();

            if (Enum.TryParse(userInput, true, out NumberWords numberWord))
            {
                int number = (int)numberWord;
                Console.WriteLine($"Результат: {number}");
            }
            else
            {
                Console.WriteLine("Неправильное слово.");
            }


        }
        static bool EvaluateEx(string expression)
        {
            try
            {
                // Разбиваем введенное выражение на операнды и оператор
                string[] token = expression.Split(' ');
                if (token.Length != 3)
                {
                    throw new ArgumentException("Неверный формат выражения.");
                }

                int operand1 = int.Parse(token[0]);
                string op = token[1];
                int operand2 = int.Parse(token[2]);

                
                switch (op)
                {
                    case "<":
                        return operand1 < operand2;
                    case ">":
                        return operand1 > operand2;
                    case "<=":
                        return operand1 <= operand2;
                    case ">=":
                        return operand1 >= operand2;
                    case "==":
                        return operand1 == operand2;
                    case "!=":
                        return operand1 != operand2;
                    default:
                        throw new ArgumentException("Неподдерживаемый оператор.");
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException("Неверный формат числа.");
            }
        }
        static void Q3()
        {
            Console.Write("Введите логическое выражение (например, 3 > 2 или 7 < 3): ");
            string expression = Console.ReadLine();

            try
            {
                bool result = EvaluateEx(expression);
                Console.WriteLine($"Результат: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void Main()
        {
            //ConverterMenu();
            //Q2();
            //PassCreator();
            //Q3();

        }
    }
}
