using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_4
{
    internal class Program
    {
        public enum DzienTygodnia
        {
            Poniedziałek = 1,
            Wtorek = 2,
            Środa = 3,
            Czwartek = 4,
            Piątek = 5,
            Sobota = 6,
            Niedziela = 7
        }

        public enum RozmiarLiczby
        {
            mała,
            średnia,
            duża
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź liczbę z zakresu 1-7:");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine((DzienTygodnia)input);
            Console.ReadLine();

            Console.WriteLine("Część 2: \nWprowadź dowolną liczbę:");
            int liczba = int.Parse(Console.ReadLine());

            RozmiarLiczby rozmiar;

            if (liczba < 10)
            {
                rozmiar = RozmiarLiczby.mała;
            }
            else if (liczba < 100)
            {
                rozmiar = RozmiarLiczby.średnia;
            }
            else
            {
                rozmiar = RozmiarLiczby.duża;
            }
            Console.WriteLine($"Liczba {liczba} jest {rozmiar}.");
            Console.ReadLine() ;
        }
    }
}
