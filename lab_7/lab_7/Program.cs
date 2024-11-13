using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    public interface ICepikData
    {
        string TypPojazdu { get; }
        string Marka { get; }
        double Pojemnosc { get; }
        int LiczbaMiejsc { get; }
        string VIN { get; }
        string NrRejestracyjny { get; }
        int RokProdukcji { get; }
        string Kolor { get; }
        string PolisaNr { get; }
        string ImieNazwisko { get; }
        string AdresZamieszkania { get; }
        string PESEL { get; }
        string NrPrawaJazdy { get; }
        DateTime DataUzyskaniaPrawaJazdy { get; }
        int RokZakupu { get; }
    }

    public interface IStatData
    {
        string TypPojazdu { get; }
        string Marka { get; }
        double Pojemnosc { get; }
        int LiczbaMiejsc { get; }
        string VIN { get; }
        string NrRejestracyjny { get; }
        int RokProdukcji { get; }
        string Kolor { get; }
        string PolisaNr { get; }
    }

    public interface IPoliceData : ICepikData
    {
        int LiczbaPunktowKarnych { get; }
    }

    public class Auto : ICepikData, IStatData, IPoliceData
    {
        public string TypPojazdu { get; set; }
        public string Marka { get; set; }
        public double Pojemnosc { get; set; }
        public int LiczbaMiejsc { get; set; }
        public string VIN { get; set; }
        public string NrRejestracyjny { get; set; }
        public int RokProdukcji { get; set; }
        public string Kolor { get; set; }
        public string PolisaNr { get; set; }
        public string ImieNazwisko { get; set; }
        public string AdresZamieszkania { get; set; }
        public string PESEL { get; set; }
        public string NrPrawaJazdy { get; set; }
        public DateTime DataUzyskaniaPrawaJazdy { get; set; }
        public int RokZakupu { get; set; }
        public int LiczbaPunktowKarnych { get; set; }

        public Auto(string typPojazdu, string marka, double pojemnosc, int liczbaMiejsc, string vin, string nrRejestracyjny,
                    int rokProdukcji, string kolor, string polisaNr, string imieNazwisko, string adresZamieszkania,
                    string pesel, string nrPrawaJazdy, DateTime dataUzyskaniaPrawaJazdy, int rokZakupu, int liczbaPunktowKarnych)
        {
            TypPojazdu = typPojazdu;
            Marka = marka;
            Pojemnosc = pojemnosc;
            LiczbaMiejsc = liczbaMiejsc;
            VIN = vin;
            NrRejestracyjny = nrRejestracyjny;
            RokProdukcji = rokProdukcji;
            Kolor = kolor;
            PolisaNr = polisaNr;
            ImieNazwisko = imieNazwisko;
            AdresZamieszkania = adresZamieszkania;
            PESEL = pesel;
            NrPrawaJazdy = nrPrawaJazdy;
            DataUzyskaniaPrawaJazdy = dataUzyskaniaPrawaJazdy;
            RokZakupu = rokZakupu;
            LiczbaPunktowKarnych = liczbaPunktowKarnych;
        }
    }
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
        public static Point operator + (Point p1, Point p2) 
        { 
            Point p3 = new Point(p1.x + p2.x, p1.y + p2.y);
            return p3; 
        }
        public static bool operator true (Point p1)
        {
            return p1.x != 0 || p1.y != 0; 
        }
        public static bool operator false (Point p1)
        {
            return p1.x == 0 && p1.y == 0;
        }
        public static bool operator == (Point p1, Point p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }
        public static bool operator != (Point p1, Point p2)
        {
            return p1.x != p2.x || p1.y != p2.y;
        }
        public static bool operator < (Point p1, Point p2)
        {
            return p1.x < p2.x && p1.y < p2.y;
        }
        public static bool operator > (Point p1, Point p2)
        {
            return p1.x > p2.x && p1.y > p2.y;
        }
        public static bool operator <= (Point p1, Point p2)
        {
            return p1.x <= p2.x && p1.y <= p2.y;
        }
        public static bool operator >= (Point p1, Point p2)
        {
            return p1.x >= p2.x && p1.y >= p2.y;
        }
        public static Point operator ++ (Point p1)
        {
            p1.x++;
            p1.y++;
            return p1;
        }
        public static Point operator --(Point p1)
        {
            p1.x--; 
            p1.y--;
            return p1;
        }
        public static implicit operator Point(int value)
        {
            return new Point(value, 0);
        }
        public static implicit operator int(Point p1)
        {
            return p1.x + p1.y;
        }


    }

    public delegate void Operation(int a, int b);

    public class Calculator
    {
        public void Add(int a, int b) {Console.WriteLine($"Suma {a} + {b} = {a + b}");}
        public void Subtract(int a, int b) {Console.WriteLine($"Różnica {a} - {b} = {a - b}");}
        public void Multiply(int a, int b) {Console.WriteLine($"Iloczyn {a} * {b} = {a * b}");}
        public void Divide(int a, int b){
            if (b != 0) {Console.WriteLine($"Iloraz {a} / {b} = {a / b}");}
            else {Console.WriteLine("Błąd: Dzielenie przez zero.");}
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto1 = new Auto("SUV", "Toyota", 2.5, 5, "VIN1234567890", "AB1234", 2021, "Czarny", "POLISA1234",
                                    "Jan Kowalski", "ul. Kwiatowa 10, Warszawa", "90010112345", "PL12345678",
                                    new DateTime(2015, 5, 12), 2021, 5);
            Auto auto2 = new Auto("Sedan", "Honda", 1.6, 5, "VIN0987654321", "CD5678", 2019, "Biały", "POLISA5678",
                                    "Anna Nowak", "ul. Długa 20, Kraków", "92020212345", "PL87654321",
                                    new DateTime(2018, 8, 20), 2019, 0);

            List<ICepikData> cepikDataList = new List<ICepikData> { auto1, auto2 };
            List<IStatData> statDataList = new List<IStatData> { auto1, auto2 };
            List<IPoliceData> policeDataList = new List<IPoliceData> { auto1, auto2 };

            Console.WriteLine("Dane CEPIK:");
            foreach (ICepikData auto in cepikDataList)
            {
                Console.WriteLine($"Typ: {auto.TypPojazdu}, Marka: {auto.Marka}, Pojemność: {auto.Pojemnosc} L, Liczba miejsc: {auto.LiczbaMiejsc}");
                Console.WriteLine($"VIN: {auto.VIN}, Nr rejestracyjny: {auto.NrRejestracyjny}, Rok produkcji: {auto.RokProdukcji}, Kolor: {auto.Kolor}");
                Console.WriteLine($"Polisa nr: {auto.PolisaNr}");
                Console.WriteLine($"Imię i nazwisko właściciela: {auto.ImieNazwisko}, Adres zamieszkania: {auto.AdresZamieszkania}");
                Console.WriteLine($"PESEL: {auto.PESEL}, Nr prawa jazdy: {auto.NrPrawaJazdy}");
                Console.WriteLine($"Data uzyskania prawa jazdy: {auto.DataUzyskaniaPrawaJazdy:yyyy-MM-dd}, Rok zakupu: {auto.RokZakupu}\n");
            }

            Console.WriteLine("\nDane statystyczne:");
            foreach (IStatData auto in statDataList)
            {
                Console.WriteLine($"Typ: {auto.TypPojazdu}, Marka: {auto.Marka}, Pojemność: {auto.Pojemnosc} L, Liczba miejsc: {auto.LiczbaMiejsc}");
                Console.WriteLine($"VIN: {auto.VIN}, Nr rejestracyjny: {auto.NrRejestracyjny}, Rok produkcji: {auto.RokProdukcji}, Kolor: {auto.Kolor}");
                Console.WriteLine($"Polisa nr: {auto.PolisaNr}\n");
            }

            Console.WriteLine("\nDane dla Policji:");
            foreach (IPoliceData auto in policeDataList)
            {
                Console.WriteLine($"Typ: {auto.TypPojazdu}, Marka: {auto.Marka}, Pojemność: {auto.Pojemnosc} L, Liczba miejsc: {auto.LiczbaMiejsc}");
                Console.WriteLine($"VIN: {auto.VIN}, Nr rejestracyjny: {auto.NrRejestracyjny}, Rok produkcji: {auto.RokProdukcji}, Kolor: {auto.Kolor}");
                Console.WriteLine($"Polisa nr: {auto.PolisaNr}");
                Console.WriteLine($"Imię i nazwisko właściciela: {auto.ImieNazwisko}, Adres zamieszkania: {auto.AdresZamieszkania}");
                Console.WriteLine($"PESEL: {auto.PESEL}, Nr prawa jazdy: {auto.NrPrawaJazdy}");
                Console.WriteLine($"Data uzyskania prawa jazdy: {auto.DataUzyskaniaPrawaJazdy:yyyy-MM-dd}, Rok zakupu: {auto.RokZakupu}");
                Console.WriteLine($"Liczba punktów karnych: {auto.LiczbaPunktowKarnych}\n");
            }

            Console.WriteLine("\n\n\n");

            Point p1 = new Point(3, 4);
            Point p2 = new Point(5, 6);

            Point p3 = p1 + p2;
            Console.WriteLine($"Wynik dodawania: ({p3.x}, {p3.y})");

            if (p1) { Console.WriteLine("p1 jest traktowany jako true"); }
            else { Console.WriteLine("p1 jest traktowany jako false"); }

            Point p0 = new Point(0, 0);
            if (p0) { Console.WriteLine("p0 jest traktowany jako true"); }
            else { Console.WriteLine("p0 jest traktowany jako false"); }


            Console.WriteLine(p1 < p2);
            Console.WriteLine(p1 <= p2);

            Point p4 = new Point(1, 1);
            p4++;
            Console.WriteLine($"Po inkrementacji: ({p4.x},{p4.y})");
            p4--;
            Console.WriteLine($"Po dekrementacji: ({p4.x},{p4.y})");

            Point p5 = 5;
            Console.WriteLine($"Point p4: ({p5.x},{p5.y})");

            Point p6 = new Point(2, 5);
            int suma = (int)p6;
            Console.WriteLine($"Suma współrzędnych: {suma}");

            Console.WriteLine("\n\n\n");

            Calculator calculator = new Calculator();

            Operation operation;
            operation = calculator.Add;
            operation(10, 5);

            operation = calculator.Subtract;
            operation(10, 5);

            operation = calculator.Multiply;
            operation(10, 5);

            operation = calculator.Divide;
            operation(10, 5);

            Console.ReadLine();

        }
    }
}
