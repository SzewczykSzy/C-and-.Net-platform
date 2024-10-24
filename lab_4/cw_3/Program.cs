using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_3
{
    internal class Program
    {   static void cw3()
        {   
            char[] table = new char[10];
            var numElems = 0;
            while (numElems < 10)
            {
                Console.WriteLine("\nZnak:");

                char el = Console.ReadKey().KeyChar;

                for (var i = numElems; i > 0; i--)
                    table[i] = table[i - 1];

                table[0] = el;
                numElems++;
            }
            Console.WriteLine("\nTablica:");
            foreach (char e in table)
                Console.Write($" {e}");
            Console.WriteLine("\n");
            Console.ReadLine();
        }

        static void cw4()
        {
            int[] table = new int[5];
            for (var i = 0; i < table.Length; i++)
            {
                Console.WriteLine("\nLiczba:");
                int el = int.Parse(Console.ReadLine());
                table[i] = el;
            }
            Console.WriteLine("\nTablica:");
            for (var i = 4;i >= 0; i--)
                Console.Write($" {table[i]}");
            Console.ReadLine() ;

        }

        static void cw5()
        {
            var array = new int[5];
            for (var i = 0; i < array.Length; i++)
                array[i] = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();
            foreach (var value in array)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }
            }
            foreach (var item in dict)
                Console.WriteLine($"Val: {item.Key}, count: {item.Value}");
            Console.ReadLine();
        }

        static void cw6()
        {
            int[,] tab_1 = { { 1, 2, 3, 4, 5 }, 
                             { 1, 2, 1, 1, 1},
                             { 2, 2, 2, 2, 2},
                             { 1, 1, 1, 1, 1},
                             { 1, 1, 1, 1, 1}};

            int[,] tab_2 = { { 1, 2, 3, 4, 5 },
                             { 1, 2, 1, 1, 1},
                             { 2, 2, 2, 2, 2},
                             { 1, 1, 1, 1, 1},
                             { 1, 1, 1, 1, 1}};

            int[,] tab_3 = new int[5, 5];

            for (int i = 0; i < tab_1.GetLength(0); i++)
            {
                for (int j = 0; j < tab_1.GetLength(1); j++)
                {
                    tab_3[i, j] = tab_1[i, j] + tab_2[i, j];
                }
            }
            Console.WriteLine(tab_3.Length);
            Console.WriteLine(tab_3.LongLength);
            Console.WriteLine(tab_3.Rank);
            Console.ReadLine();
        }

        static void cw7()
        {
            int[,] tab = { { 1,   0, -1 }, 
                           { 0,   0,  1 }, 
                           { -1, -1,  0} };

            int det = 0;
            for (var i = 0; i < 3; i++)
            {
                det += (tab[0, i] * (tab[1, (i + 1) % 3] * tab[2, (i + 2) % 3]
                                        - tab[1, (i + 2) % 3] * tab[2, (i + 1) % 3]));
            }
            Console.WriteLine(det);
            Console.ReadLine();
        }
        static void cw8()
        {
            var tab_1 = new int[5][];
            tab_1[0] = new[] { 1, 2, 3 };
            tab_1[1] = new[] { 4, 5, 6, 7, 8, 9 };
            tab_1[2] = new[] { 10, 11, 12, 13 };
            tab_1[3] = new[] { 14, 15, 16, 17, 18 };
            tab_1[4] = new[] { 19, 20, 21 };

            int[][] tab_2 =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6, 7, 8, 9 },
                new[] { 10, 11, 12, 13 },
                new[] { 14, 15, 16, 17, 18 },
                new[] { 19, 20, 21 }
            };

            foreach(var el in tab_1) 
            {
                Console.Write("{");
                for(var j = 0; j < el.Length; j++)
                {
                    Console.Write(j + " ");
                }
                Console.Write("}\n");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("cw3");
            cw3();
            Console.WriteLine("cw4");
            cw4();
            Console.WriteLine("cw5");
            cw5();
            Console.WriteLine("cw6");
            cw6();
            Console.WriteLine("cw7");
            cw7();
            Console.WriteLine("cw8");
            cw8();
        }
    }
}
