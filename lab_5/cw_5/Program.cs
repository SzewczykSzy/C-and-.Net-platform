using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace cw_5
{
    internal class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int puts(string str);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _flushall();


        static void Main(string[] args)
        {
            puts("Hello, world from P/Invoke!");

            _flushall();

            Console.ReadLine();
        }
    }
}
