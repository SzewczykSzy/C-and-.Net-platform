using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static cw_2.Program;

namespace cw_2
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
            }
            public string BaubleColor(int index)
            {
                return base[index];
            }

        }
        static void Main(string[] args)
        {
            ChristmasTreeA treeA = new ChristmasTreeA();
            treeA.Add("Czerwony", "Kula");
            treeA.Add("Niebieski", "Gwiazda");
            treeA.Add("Złoty", "Aniołek");

            Console.WriteLine($"\nTyp bombki o indeksie 0: {treeA[0]}");

            Console.WriteLine($"Kolor bombki o indeksie 0: {treeA.BaubleColor(0)}");

            ChristmasTree treeAsBase = (ChristmasTree)treeA;

            Console.WriteLine($"\nTyp bombki o indeksie 0 po rzutowaniu: {treeAsBase[0]}");

            treeAsBase[0] = "Dzwonek";
            Console.WriteLine($"Nowy typ bombki o indeksie 0: {treeAsBase[0]}");

            Console.ReadLine();
        }
    }
}
