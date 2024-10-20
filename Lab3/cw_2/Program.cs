using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_1
{
    internal class Program
    {
        public struct Point2D
        {
            private double X = 1;
            private double Y = 1;
            public Point2D() { }

            //public void Reset()
            //{
            //    X = 0;
            //    Y = 0;
            //}
            public void IncrX(double dx)
            {
                X += dx;
            }
            public void IncrY(double dy)
            {
                Y += dy;
            }
            public void Print2DPoint()
            {
                Console.WriteLine($"(X={X} Y={Y})");
            }

            public double Dist(Point2D point)
            {
                double dist = Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
                return dist;
            }
            public override string ToString() => $"({X}, {Y})";
        }
        static void Main(string[] args)
        {
            Point2D point = new Point2D();
            Console.WriteLine(point.ToString());
            Console.ReadLine();
        }
    }
}
