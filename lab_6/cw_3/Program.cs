using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static cw_3.Program;

namespace cw_3
{
    internal class Program
    {
        abstract class Home
        {
            public abstract int Price();
        }
        class Tree : Home
        {
            public string Nazwa { get; set; }
            public int Wiek { get; set; }
            public Tree()
            {
                Nazwa = "Drzewo";
                Wiek = 0;
            }
            public override int Price()
            {
                return Wiek * 2;
            }
        }

        class Fir : Tree
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

            public override int Price()
            {
                return Wiek * 20;
            }
        }

        class ChristmasTree : Fir
        {

            protected List<Bauble> baubles;
            public ChristmasTree()
            {
                Nazwa = "Choinka";
                Wiek = 2;
                baubles = new List<Bauble>();
            }

            public void Add(string kolor, string typ)
            {
                Bauble bauble = new Bauble(kolor, typ);
                baubles.Add(bauble);
            }

            public void Remove(int index)
            {
                if (index >= 0 && index < baubles.Count)
                {
                    baubles.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy indeks. Nie można usunąć bombki.");
                }
            }

            public virtual string this[int index]
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
            public override int Price()
            {
                return (Wiek * 30) + (baubles.Count * 5);
            }
        }

        class ChristmasTreeA : ChristmasTree
        {
            public override string this[int index]
            {
                get
                {
                    if (index >= 0 && index < baubles.Count)
                    {
                        return baubles[index].Typ;
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
                        baubles[index].Typ = value;
                        Console.WriteLine($"Zmieniono typ bombki o indeksie {index} na {value}.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Nieprawidłowy indeks bombki.");
                    }
                }
            }
            public string BaubleColor(int index)
            {
                return base[index];
            }
            public override int Price()
            {
                return base.Price() + 50;
            }
        }
        class ChristmasTreeB : ChristmasTreeA 
        {
            public new string this[int index]
            {
                get
                {
                    if (index >= 0 && index < baubles.Count)
                    {
                        return $"{baubles[index].Kolor}_{baubles[index].Typ}";
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Nieprawidłowy indeks bombki.");
                    }
                }
                set
                {
                    throw new NotImplementedException("Setter nie jest zaimplementowany w tej wersji indeksatora.");
                }
            }
            public override int Price()
            {
                return base.Price() + 100;
            }
        }

        sealed class ChristmasTreeC : ChristmasTreeB
        {
            public void ShowBaubleCount()
            {
                Console.WriteLine($"Liczba bombek na {Nazwa}: {baubles.Count}");
            }

            public override int Price()
            {
                return base.Price() + 500;
            }
        }

        static void Main(string[] args)
        {
            Tree tree = new Tree { Wiek = 10 };
            Console.WriteLine($"Cena drzewa: {tree.Price()} zł\n");

            Fir fir = new Fir { Wiek = 7 };
            Console.WriteLine($"Cena jodły: {fir.Price()} zł\n");

            ChristmasTree christmasTree = new ChristmasTree { Wiek = 3};
            christmasTree.Add("Czerwony", "Kula");
            christmasTree.Add("Niebieski", "Gwiazda");
            christmasTree.Add("Złoty", "Aniołek");
            christmasTree.Add("Czerwony", "Dzwonek");


            Console.WriteLine($"\nKolor bombki o indeksie 0: {christmasTree[0]}");

            christmasTree[0] = "Srebrny";

            Console.WriteLine("\nBombki po zmianie koloru:");

            int goldBaubles = christmasTree["Złoty"];
            Console.WriteLine($"\nLiczba bombek o kolorze 'Złoty': {goldBaubles}");

            int redBaubles = christmasTree["Czerwony"];
            Console.WriteLine($"Liczba bombek o kolorze 'Czerwony': {redBaubles}");

            christmasTree.Remove(1);

            Console.WriteLine("\nBombki po usunięciu bombki o indeksie 1:");

            Console.WriteLine($"Cena choinki: {christmasTree.Price()} zł\n");

            ChristmasTreeA treeA = new ChristmasTreeA();
            treeA.Add("Zielony", "Kula");
            treeA.Add("Czerwony", "Gwiazda");
            treeA.Add("Niebieski", "Aniołek");

            Console.WriteLine($"\nTyp bombki o indeksie 0: {treeA[0]}");

            Console.WriteLine($"Kolor bombki o indeksie 0: {treeA.BaubleColor(0)}");

            ChristmasTree treeAsBaseA = (ChristmasTree)treeA;

            Console.WriteLine($"\nKolor bombki o indeksie 0 po rzutowaniu na ChristmasTree: {treeAsBaseA[0]}");

            treeA[0] = "Dzwonek";
            Console.WriteLine($"Nowy typ bombki o indeksie 0: {treeA[0]}");

            Console.WriteLine("\nBombki po zmianie typu:");

            Console.WriteLine($"Cena choinki A: {treeA.Price()} zł\n");

            ChristmasTreeB treeB = new ChristmasTreeB();
            treeB.Add("Złoty", "Dzwonek");
            treeB.Add("Srebrny", "Kula");
            treeB.Add("Czerwony", "Gwiazda");

            Console.WriteLine($"\nKolor i typ bombki o indeksie 1: {treeB[1]}");

            ChristmasTreeA treeAsA = (ChristmasTreeA)treeB;

            Console.WriteLine($"Typ bombki o indeksie 1 po rzutowaniu na ChristmasTreeA: {treeAsA[1]}");

            Console.WriteLine($"Kolor bombki o indeksie 1: {treeAsA.BaubleColor(1)}");

            ChristmasTree treeAsBaseB = (ChristmasTree)treeB;

            Console.WriteLine($"Kolor bombki o indeksie 1 po rzutowaniu na ChristmasTree: {treeAsBaseB[1]}");

            Console.WriteLine($"Cena choinki B: {treeB.Price()} zł\n");

            ChristmasTreeC treeC = new ChristmasTreeC();
            treeC.Add("Biały", "Aniołek");
            treeC.Add("Zielony", "Dzwonek");
            treeC.Add("Czerwony", "Kula");

            Console.WriteLine($"\nKolor i typ bombki o indeksie 2: {treeC[2]}");

            treeC.ShowBaubleCount();


            Console.WriteLine($"Cena choinki C: {treeC.Price()} zł\n");

            Console.ReadLine();
        }
    }
}
