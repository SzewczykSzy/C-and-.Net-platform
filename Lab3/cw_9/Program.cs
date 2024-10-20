using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_9
{
    internal class Program
    {
        static bool IsValid(string input) 
        {
            foreach (char c in input) 
            {
                if (!char.IsDigit(c) && c != '+' && c != '-') 
                {
                    return false;
                }
            }
            return true;
        }

        static int ApplyOperation(int result, char operation, int number)
        {
            if (operation == '+')
            {
                return result + number;
            }
            else if (operation == '-')
            {
                return result - number;
            }
            else
            {
                throw new InvalidOperationException("Nieznany operator.");
            }
        }

        static int Calculate(string input)
        {
            int result = 0;
            string number = string.Empty;
            char sign = '+';

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(number))
                    {
                        result = ApplyOperation(result, sign, int.Parse(number));
                        number = string.Empty;
                    }
                    sign = c;
                }
            }
            if (!string.IsNullOrEmpty(number))
            {
                result = ApplyOperation(result, sign, int.Parse(number));
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź wyrażenie do obliczenia (np. 12+2-3): ");
            string input = Console.ReadLine();

            if (!IsValid(input))
            {
                Console.WriteLine("Błąd: Wyrażenie zawiera niepoprawne znaki.");
                Console.ReadLine();
                return;
            }
            int result = Calculate(input);
            Console.WriteLine($"Wynik: {result}");
            Console.ReadLine();
        }
    }
}