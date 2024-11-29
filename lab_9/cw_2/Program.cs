using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Flag = true;
            while (Flag) {
                char input = Console.ReadKey(true).KeyChar;
                if (char.IsLetter(input))
                {
                    Console.WriteLine("Nacisnięto literę!");
                }
                else if (char.IsDigit(input))
                {
                    Console.WriteLine("Naciśnięto cyfrę!");
                }
                else
                {
                    Flag = false;
                }
            }
        }
    }
}
