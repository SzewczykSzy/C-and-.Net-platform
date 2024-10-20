using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_8
{
    internal class Program
    {
        public struct Coords
        {
            public int x, y;
            public Coords(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        public class Point
        {
            public int x, y;
            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        static void Fun1(Point p)
        {
            p.x = 3;
            p.y = 4;
        }
        static void Fun2(Coords c)
        {
            c.x = 3;
            c.y = 4;
        }

        static void Main(string[] args)
        {
            var p = new Point(1, 2);
            var c = new Coords(1, 2);

            // --------- 1 -----------
            //Fun1(p: p);
            //Fun2(c: c);
            //Console.WriteLine($"class:  {p.x}, {p.y}"); 
            //Console.WriteLine($"struct: {c.x}, {c.y}");
            //Console.ReadLine();

            // --------- 2 -----------
            Console.WriteLine(Object.Equals(p, c));
            Console.WriteLine(c.Equals(p));
            Console.WriteLine(p.Equals(c));
            Console.WriteLine(Object.ReferenceEquals(p, c));
            Console.ReadLine();
        }
    }
}
