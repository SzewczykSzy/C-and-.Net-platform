using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_2
{
    internal class Program
    {
        class TestPointer {
            public unsafe static void swap(int* p, int* q)
            {
                int temp = *p;
                *p = *q;
                *q = temp;
            }
            public unsafe static void Main()
            {
                int[] list = { 10, 100, 200 };
                fixed (int* ptr = list)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Adres [{0}]={1}", i, (int)(ptr + 1));
                        Console.WriteLine("Wartość [{0}]={1}", i, *(ptr + 1));
                    }
                }

                Console.ReadKey();

                int x = 1;
                int y = 2;

                Console.WriteLine(x);
                Console.WriteLine(y);
                swap(&x, &y);
                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.ReadKey();

                int[] buffer = new int[1024];
                fixed (int* bufferPtr = buffer)
                {
                    for (int i = 0; i < 1024; i++)
                    {
                        *(bufferPtr + i) = i % 4;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        var val = *(bufferPtr + i);
                        Console.WriteLine($"Wartość [{i}]={val}");
                    }
                }
                Console.ReadKey();
            }
        }

    }
}
