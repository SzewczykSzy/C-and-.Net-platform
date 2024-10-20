using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź jeden znak: ");
            char input = Console.ReadKey().KeyChar;

            if ("aeąęiouy".IndexOf(input) >= 0)
            {
                Console.WriteLine("\nsamogłoska");
            }
            else if (char.IsDigit(input))
            {
                Console.WriteLine("\ncyfra");
            }
            else
            {
                Console.WriteLine("\ninny znak");
            }
            Console.ReadLine(); 
        }
    }
}
