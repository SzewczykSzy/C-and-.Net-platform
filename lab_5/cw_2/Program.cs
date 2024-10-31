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
            Int32 i = 23;
            object o = 1;
            i = 123;
            Console.WriteLine(i + ", " + (Int32) o);
            

            long j = (long) o;
            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}
