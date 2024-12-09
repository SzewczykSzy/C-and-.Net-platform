using System;
using System.Threading;

namespace ObracajacaSieChoinka
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ukryj kursor konsoli
            Console.CursorVisible = false;

            // Utwórz obiekt choinki i uruchom animację w nowym wątku
            Choinka choinka = new Choinka();
            Thread watekAnimacji = new Thread(choinka.Animuj);
            watekAnimacji.Start();

            // Czekaj na naciśnięcie klawisza przez użytkownika
            Console.ReadKey();

            // Zatrzymaj wątek animacji w bezpieczny sposób
            choinka.Zatrzymaj();
            watekAnimacji.Join();
        }
    }

    class Choinka
    {
        private int wysokosc = 25; // Wysokość choinki (bez wierzchołka)
        private int szerokoscMaksymalna; // Maksymalna szerokość choinki
        private int wysokoscPnia = 4;
        private int szerokoscPnia = 4;

        private Random rand = new Random();
        private volatile bool dziala = true;

        // Zestaw znaków do generowania choinki (bez '*')
        private char[] znakiChoinki = @"oOp09bdq~!@#$^&()-+={}[]|\'"";:,<.>/?".ToCharArray();

        // Zestaw kolorów dla znaków (bez zielonego)
        private ConsoleColor[] kolory = new ConsoleColor[]
        {
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White
        };

        // Zestaw znaków do generowania pnia, z '|' występującym najczęściej
        private char[] znakiPnia = { '|', '|', '|', '\\', '/' };

        public Choinka()
        {
            // Ustaw maksymalną szerokość choinki na połowę szerokości konsoli
            szerokoscMaksymalna = (Console.WindowWidth - 10) / 2;
        }

        public void Zatrzymaj()
        {
            dziala = false;
        }

        public void Animuj()
        {
            while (dziala)
            {
                // Wyczyść konsolę i narysuj choinkę
                Console.Clear();
                RysujChoinke();

                // Odczekaj chwilę przed następną iteracją
                Thread.Sleep(200);
            }
        }

        private void RysujChoinke()
        {
            // Generuj losowe szerokości wierszy choinki
            int[] szerokosci = GenerujSzerokosciWierszy();

            // Oblicz pozycję początkową choinki w konsoli
            int top = Console.WindowHeight / 2 - (wysokosc + wysokoscPnia + 1) / 2;
            int left = Console.WindowWidth / 2;

            // Rysuj wierzchołek choinki z '*' w kolorze żółtym
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('*');
            Console.ResetColor();

            // Rysuj każdy wiersz choinki
            for (int i = 0; i < wysokosc; i++)
            {
                int szerokoscWiersza = szerokosci[i];
                int lewaPozycja = left - szerokoscWiersza / 2;

                // Generuj linię z losowych znaków
                char[] linia = GenerujLinie(szerokoscWiersza);

                for (int j = 0; j < szerokoscWiersza; j++)
                {
                    Console.SetCursorPosition(lewaPozycja + j, top + 1 + i);
                    char c = linia[j];

                    if (c == '*')
                    {
                        // Znak '*' w kolorze zielonym
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        // Losowy kolor (bez zielonego)
                        Console.ForegroundColor = kolory[rand.Next(kolory.Length)];
                    }

                    Console.Write(c);
                }
            }

            // Rysuj pień choinki z losowych znaków, '|' występuje najczęściej
            for (int i = 0; i < wysokoscPnia; i++)
            {
                int lewaPozycjaPnia = left - szerokoscPnia / 2;
                char[] liniaPnia = GenerujLiniePnia(szerokoscPnia);

                for (int j = 0; j < szerokoscPnia; j++)
                {
                    Console.SetCursorPosition(lewaPozycjaPnia + j, top + 1 + wysokosc + i);
                    char c = liniaPnia[j];
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Brązowy kolor
                    Console.Write(c);
                }
                Console.ResetColor();
            }
        }

        private int[] GenerujSzerokosciWierszy()
        {
            int[] szerokosci = new int[wysokosc];

            for (int i = 0; i < wysokosc; i++)
            {
                // Ustal minimalną i maksymalną szerokość dla danego wiersza
                int minimalnaSzerokosc = Math.Max(1, (i * szerokoscMaksymalna) / (wysokosc * 2));
                int maksymalnaSzerokosc = Math.Min(szerokoscMaksymalna, (i * szerokoscMaksymalna) / wysokosc + 1);

                if (minimalnaSzerokosc > maksymalnaSzerokosc)
                    minimalnaSzerokosc = maksymalnaSzerokosc;

                // Zmniejsz rozrzut między minimalną a maksymalną szerokością
                int sredniaSzerokosc = (minimalnaSzerokosc + maksymalnaSzerokosc) / 4;
                int rozrzut = (maksymalnaSzerokosc - minimalnaSzerokosc) / 2; // Mniejszy rozrzut

                int minLosowaSzerokosc = Math.Max(minimalnaSzerokosc, sredniaSzerokosc - rozrzut);
                int maxLosowaSzerokosc = Math.Min(maksymalnaSzerokosc, sredniaSzerokosc + rozrzut);

                // Upewnij się, że min i max są poprawne
                if (minLosowaSzerokosc > maxLosowaSzerokosc)
                    minLosowaSzerokosc = maxLosowaSzerokosc;

                // Losuj szerokość wiersza z zawężonego zakresu
                int szerokoscWiersza = rand.Next(minLosowaSzerokosc, maxLosowaSzerokosc + 1);

                // Upewnij się, że szerokość jest nieparzysta, aby choinka była symetryczna
                if (szerokoscWiersza % 2 == 0)
                    szerokoscWiersza++;

                // Nie przekraczaj maksymalnej szerokości
                szerokoscWiersza = Math.Min(szerokoscWiersza, szerokoscMaksymalna);

                szerokosci[i] = szerokoscWiersza;
            }

            return szerokosci;
        }

        private char[] GenerujLinie(int szerokosc)
        {
            char[] linia = new char[szerokosc];
            for (int i = 0; i < szerokosc; i++)
            {
                int los = rand.Next(100);
                if (los < 60)
                {
                    // 60% szans na '*'
                    linia[i] = '*';
                }
                else
                {
                    // 40% szans równomiernie rozłożone na pozostałe znaki
                    linia[i] = znakiChoinki[rand.Next(znakiChoinki.Length)];
                }
            }
            return linia;
        }

        private char[] GenerujLiniePnia(int szerokosc)
        {
            char[] linia = new char[szerokosc];
            for (int i = 0; i < szerokosc; i++)
            {
                // Losuj znak z zestawu znaków pnia, z '|' występującym najczęściej
                linia[i] = znakiPnia[rand.Next(znakiPnia.Length)];
            }
            return linia;
        }
    }
}
