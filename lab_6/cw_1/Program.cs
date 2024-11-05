using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static cw_1.Program;

namespace cw_1
{
    internal class Program
    {
        class Tree 
        {
            public string Nazwa { get; set; }
            public int Wiek { get; set; }
            public Tree()
            {
                Nazwa = "Drzewo";
                Wiek = 0;
            }
        }

        class Fir:Tree 
        {
            protected class Bauble 
            {
                public string Kolor { get; set; }
                public string Typ { get; set; }
                public Bauble(string kolor, string typ) 
                {
                    Kolor = kolor;
                    Typ = typ;
                }
            }
            public Fir()
            {
                Nazwa = "Jodła";
                Wiek = 5;
            }
        }

        class ChristmasTree : Fir {

            private List<Bauble> baubles;
            public ChristmasTree()
            {
                Nazwa = "Choinka";
                Wiek = 2;
                baubles = new List<Bauble>();
            }

            public void Add(string kolor, string typ) {
                Bauble bauble = new Bauble(kolor, typ);
                baubles.Add(bauble);
            }

            public void Remove(int index) { 
                if (index >= 0 && index < baubles.Count) 
                { 
                    baubles.RemoveAt(index); 
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy indeks. Nie można usunąć bombki.");
                }
            }

            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index < baubles.Count)
                    {
                        return baubles[index].Kolor;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Nieprawidłowy indeks bombki.");
                    }
                }
                set
                {
                    if (index >= 0 && index < baubles.Count)
                    {
                        baubles[index].Kolor = value;
                        Console.WriteLine($"Zmieniono kolor bombki o indeksie {index} na {value}.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Nieprawidłowy indeks bombki.");
                    }
                }
            }

            public int this[string color]
            {
                get
                {
                    int count = 0;
                    foreach (var bauble in baubles)
                    {
                        if (bauble.Kolor.Equals(color, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }
        }
        static void Main(string[] args)
        {
            ChristmasTree christmasTree = new ChristmasTree { Wiek = 3};

            christmasTree.Add("Czerwony", "Kula");
            christmasTree.Add("Niebieski", "Gwiazda");
            christmasTree.Add("Złoty", "Aniołek");
            christmasTree.Add("Czerwony", "Dzwonek");

            int goldBaubles = christmasTree["Złoty"];
            Console.WriteLine($"\nLiczba bombek o kolorze 'Złoty': {goldBaubles}");

            int redBaubles = christmasTree["Czerwony"];
            Console.WriteLine($"Liczba bombek o kolorze 'Czerwony': {redBaubles}");

            int silverBaubles = christmasTree["Srebrny"];
            Console.WriteLine($"Liczba bombek o kolorze 'Srebrny': {silverBaubles}");


            Console.WriteLine($"\nKolor bombki o indeksie 0: {christmasTree[0]}");

            christmasTree[0] = "Srebrny";


            int goldBaubles_ = christmasTree["Złoty"];
            Console.WriteLine($"\nLiczba bombek o kolorze 'Złoty': {goldBaubles_}");

            int redBaubles_ = christmasTree["Czerwony"];
            Console.WriteLine($"Liczba bombek o kolorze 'Czerwony': {redBaubles_}");

            int silverBaubles_ = christmasTree["Srebrny"];
            Console.WriteLine($"Liczba bombek o kolorze 'Srebrny': {silverBaubles_}");

            Console.ReadLine();
        }
    }
}
