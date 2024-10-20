using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int liczba = 9999999999; // błąd przepełnienia

            try
            {
                int liczba = int.MaxValue;

                checked
                {
                    liczba = liczba + 1;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Błąd przepełnienia: " + ex.Message);
            }
            Console.ReadLine();

        }
    }
}
