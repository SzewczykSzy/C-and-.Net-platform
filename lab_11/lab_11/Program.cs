using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab_11
{
    //class ThreadExample
    //{
    //    ////Ćwiczenie 1
    //    //static void Main()
    //    //{
    //    //    Thread t = new Thread(Write1); //Uruchom inny wątek
    //    //    t.Start();
    //    //    // Główny wątek.
    //    //    for (int i = 0; i < 1000; i++) Console.Write("0");
    //    //}
    //    ////Inny wątek
    //    //static void Write1()
    //    //{
    //    //    for (int i = 0; i < 1000; i++) Console.Write("1");
    //    //    Console.ReadKey();
    //    //}

    //    ////Ćwiczenie 2
    //    //static void Main()
    //    //{
    //    //    new Thread(Run).Start(); // Uruchom Run w innym wątku
    //    //    Run(); // Uruchom Run w głownym wątku
    //    //    Console.ReadLine();
    //    //}
    //    //static void Run()
    //    //{
    //    //    // Deklaracja i użycie zmiennej lokalnej - 'cycles'
    //    //    for (int cycles = 0; cycles < 5; cycles++) Console.Write('x');
    //    //}

    //    ////Ćwiczenie 4
    //    //static bool done; // Pole statyczne
    //    //static void Main()
    //    //{
    //    //    new Thread(Run).Start();
    //    //    Run();
    //    //    Console.ReadLine();
    //    //}
    //    ////static void Run()
    //    ////{
    //    ////    if (!done) { done = true; Console.WriteLine("Done"); }
    //    ////}
    //    //static void Run()
    //    //{
    //    //    if (!done) { Console.WriteLine("Done"); done = true; }
    //    //}

    //    ////Ćwiczenie 5
    //    //static bool done; // Pole statyczne
    //    //static readonly object locker = new object();
    //    //static void Main()
    //    //{
    //    //    new Thread(Run).Start();
    //    //    Run();
    //    //    Console.ReadLine();
    //    //}
    //    //static void Run()
    //    //{
    //    //    lock (locker)
    //    //    {
    //    //        done = true;
    //    //        Console.WriteLine("Done");
    //    //    }
    //}

    //    //Ćwiczenie 6
    //    static void Main()
    //    {
    //        Thread t = new Thread(Run);
    //        t.Start();
    //        //t.Join();
    //        Console.WriteLine("Thread t has ended!");
    //        Console.ReadLine();
    //    }
    //    static void Run()
    //    {
    //        for (int i = 0; i < 777; i++) Console.Write("J");
    //    }
    //}


    ////Ćwiczenie 3
    //class ThreadTest
    //{
    //    bool done;
    //    static void Main()
    //    {
    //        ThreadTest tt = new ThreadTest();
    //        new Thread(tt.Run).Start();
    //        tt.Run();
    //        Console.ReadLine();
    //    }
    //    // Zauważ, że Run jest teraz metodą instancji
    //    void Run()
    //    {
    //        if (!done) { done = true; Console.WriteLine("Done"); }
    //    }
    //}

    class TheadMatix
    {
        static int[] results;
        static readonly object locker = new object();

        static void CalculateMatrixSum(int[][] matrix, int index)
        {
            int sum = 0;
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    sum += element;
                }
            }

            lock (locker)
            {
                results[index] = sum;
            }

            Console.WriteLine($"Wątek {index + 1}: Suma elementów macierzy = {sum}");
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int[][][] matrices = new int[5][][];

            for (int i = 0; i < matrices.Length; i++)
            {
                int n = random.Next(2, 7);
                matrices[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    matrices[i][j] = new int[n];
                    for (int k = 0; k < n; k++)
                    {
                        matrices[i][j][k] = random.Next(0, 10);
                    }
                }
            }

            results = new int[matrices.Length];

            Thread[] threads = new Thread[matrices.Length];

            for (int i = 0; i < matrices.Length; i++)
            {
                int index = i;
                threads[i] = new Thread(() => CalculateMatrixSum(matrices[index], index));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            int totalSum = 0;
            foreach (var result in results)
            {
                totalSum += result;
            }

            Console.WriteLine($"Suma wszystkich elementów: {totalSum}");
            Console.ReadLine(); 
        }
    }
}
