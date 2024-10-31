using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_1
{
    internal class Program
    {
        static void forLoop(int input) {
            for (int i = 1; i <= input+1; i++)
            {
                for (int j=1; j<i; j++)
                {
                    Console.Write(j);
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            for (int i = 1; i < input + 1; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.Write("\n");
            }
        }

        static void whileLoop(int input)
        {
            int i = 1;
            while (i <= input + 1)
            {
                int j = 1;
                while (j < i)
                {
                    Console.Write(j);
                    j++;
                }
                Console.Write("\n");
                i++;
            }
            Console.WriteLine();
            i = 1;
            while (i < input + 1)
            {
                int j = 1;
                while (j <= i)
                {
                    Console.Write(i);
                    j++;
                }
                Console.Write("\n");
                i++;
            }
        }

        static void doWhileLoop(int input)
        {
            int i = 1;
            do
            {
                int j = 1;
                while (j < i)
                {
                    Console.Write(j);
                    j++;
                }
                Console.Write("\n");
                i++;
            } while (i <= input + 1);
            Console.WriteLine();
            i = 1;
            do
            {
                int j = 1;
                while (j <= i)
                {
                    Console.Write(i);
                    j++;
                }
                Console.Write("\n");
                i++;
            } while (i < input + 1);
        }

    static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            forLoop(input);
            whileLoop(input);
            doWhileLoop(input);
            Console.ReadLine();
        }
    }
}
