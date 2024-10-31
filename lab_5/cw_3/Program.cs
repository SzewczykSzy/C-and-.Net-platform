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
            int? liczba;
            //Console.WriteLine(liczba);
            liczba = null;

            Console.WriteLine(liczba.GetValueOrDefault());
            Console.WriteLine(liczba.HasValue);

            liczba = 42;

            Console.WriteLine(liczba.GetValueOrDefault());
            Console.WriteLine(liczba.HasValue);
            Console.ReadLine();
        }
    }
}
