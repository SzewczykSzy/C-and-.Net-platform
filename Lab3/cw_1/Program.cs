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
            public double X { get; set; }
            public double Y { get; set; }
            public Point2D(double x, double y)
            {
                X = x;
                Y = y;
            }

            public void Reset()
            {
                X = 0;
                Y = 0;
            }
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
        }
        static void Main(string[] args)
        {
            double rad = 4;

            List<Point2D> pointslist = new List<Point2D>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Wprowadz dwie wspolrzedne po spacji i nacisnij ENTER: ");
                string[] parts = Console.ReadLine().Split(' ');
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);

                var point = new Point2D(x, y);
                pointslist.Add(point);
            }


            while (true) {
                Console.WriteLine("Wprowadz dwie wspolrzedne ostatniego punktu: ");

                string[] parts_5 = Console.ReadLine().Split(' ');
                double x_5 = double.Parse(parts_5[0]);
                double y_5 = double.Parse(parts_5[1]);
                var point_5 = new Point2D(x_5, y_5);

                double min_dist = double.MaxValue;
                foreach (var p in pointslist) {
                    double dist = p.Dist(point_5);
                    if (dist < min_dist) { 
                        min_dist = dist;
                    }
                }

                if (point_5.X < 0 ^ point_5.Y < 0) {
                    Console.WriteLine("Współrzędne punktów to:");
                    foreach (var p in pointslist)
                    {
                        p.Print2DPoint();
                    }
                    point_5.Print2DPoint();
                    Console.WriteLine("KONIEC");
                    Console.ReadLine();
                    break;
                }
                else if (min_dist < rad) {
                    Console.WriteLine("Współrzędne punktów to:");
                    foreach (var p in pointslist)
                    {
                        p.Print2DPoint();
                    }
                    point_5.Print2DPoint();
                    Console.WriteLine("KONIEC");
                    Console.ReadLine();
                    break;
                }
                else {
                    Console.WriteLine($"Najblizszy punkt jest w odleglosci: {min_dist}");
                }
            }
        }
    }
}
