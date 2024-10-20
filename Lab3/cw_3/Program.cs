using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intCount = 0;
            int floatCount = 0;
            int stringCount = 0;

            while (true)
            {
                Console.WriteLine("Wprowadź dane (lub -1 aby zakończyć): ");
                string input = Console.ReadLine();

                if (input == "-1")
                {
                    break;
                }
                if (int.TryParse(input, out _))
                {
                    intCount++;
                }
                if (float.TryParse(input, out _))
                {
                    floatCount++;
                }
                else
                {
                    stringCount++;
                }
            }
            Console.WriteLine($"Int: {intCount}");
            Console.WriteLine($"Float: {floatCount}");
            Console.WriteLine($"String: {stringCount}");
            Console.ReadLine();
        }
    }
}
