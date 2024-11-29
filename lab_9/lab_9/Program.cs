using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] slowa = new string[] {
                "Już północ",
                "cień",
                "ponury",
                "pół",
                "świata",
                "odrkywa",
                "A jeszcze",
                "serce",
                "zmysłom",
                "spoczynku nie daje"
            };

            //Console.WriteLine($"{slowa[^1]}");
            // Funkcja "operator indeksowania" nie jest dostępna w języku C# 7.3
            Console.WriteLine($"{slowa[slowa.Length - 1]}");

            //string[] sonet1 = slowa[2..6];
            // funkcja operator zakresu nie jest dostępna w języku C# 7.3
            int start = 2;
            int length = 4;
            string[] sonet1 = new string[length];
            Array.Copy(slowa, start, sonet1, 0, length);
            foreach (var word in sonet1) { 
                Console.Write($"{word}");
            }
            Console.WriteLine();

            //string[] sonet2 = slowa[^3..^0];
            // funkcja operator zakresu nie jest dostępna w języku C# 7.3
            string[] sonet2 = slowa.Skip(slowa.Length - 3).Take(3).ToArray();
            foreach (var word in sonet2) {
                Console.Write($"{word}");
            }
            Console.WriteLine();

            string[] sonet3 = slowa.Skip(0).Take(slowa.Length).ToArray();
            foreach (var word in sonet3)
            {
                Console.Write($"{word}");
            }
            Console.WriteLine();

            string[] sonet4 = slowa.Skip(0).Take(5).ToArray();
            foreach (var word in sonet4)
            {
                Console.Write($"{word}");
            }
            Console.WriteLine();

            string[] sonet5 = slowa.Skip(7).Take(slowa.Length).ToArray();
            foreach (var word in sonet5)
            {
                Console.Write($"{word}");
            }
            Console.WriteLine();


            //Index stri = ^5;
            int stri = slowa.Length - 5;
            Console.WriteLine(slowa[stri]);

            //Range fraza = 2..7;
            string[] tekst = slowa.Skip(2).Take(7).ToArray();
            foreach (var word in tekst) {
                Console.Write($" {word}");
            };
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
