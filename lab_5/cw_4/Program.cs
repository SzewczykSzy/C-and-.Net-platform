using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? i = null;
            int j = 10;
            Console.WriteLine(i < j);
            Console.WriteLine(i == j);
            Console.WriteLine(i > j);
            Console.ReadLine();
        }
    }
}
