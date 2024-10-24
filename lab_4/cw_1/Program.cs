using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_1
{
    internal class Program
    {
        public class Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        static void Fun1(in int i) 
        {
            //i = 0; parametry in są tylko do odczytu
        }
        //static void Fun1(out int i)
        //{
        //    //i = 0;
        //}

        static void Fun2(out int i) {
            i = 0;
        }

        static void Fun3(ref int i) {
            i = 0;
        }

        static void Fun4(int i) { 
            i= 0;
        }

        static void Fun5(Point p)
        {
            Point p_new = new Point(3, 3);
            p = p_new;
        }

        static void Fun6(ref Point p)
        {
            Point p_new = new Point(3, 3);
            p = p_new;
        }

        static void Main(string[] args)
        {
            int i_1 = 1;
            int i_2 = 1;
            int i_3 = 1;
            int i_4 = 1;

            Fun1(i_1);
            Fun2(out i_2);
            Fun3(ref i_3);
            Fun4(i_4);
            //Console.WriteLine(i_1);
            //Console.WriteLine(i_2);
            //Console.WriteLine(i_3);
            //Console.WriteLine(i_4);
            //Console.ReadLine();

            short i = 1;
            Fun1(i);
            //Fun2(out i);
            //Fun3(ref i);
            Fun4(i);

            Point p1 = new Point(1, 1);
            Point p2 = new Point(1, 1);
            //Console.WriteLine($"{p1.x}, {p1.y}");
            //Console.WriteLine($"{p2.x}, {p2.y}");
            Fun5(p1);
            Fun6(ref p2);
            //Console.WriteLine($"Po: ");
            //Console.WriteLine($"{p1.x}, {p1.y}");
            //Console.WriteLine($"{p2.x}, {p2.y}");
            //Console.ReadLine();

            p2 = null;
            Fun6(ref p2);
            Console.WriteLine($"{p2.x}, {p2.y}");
            Console.ReadLine();

        }
    }
}
