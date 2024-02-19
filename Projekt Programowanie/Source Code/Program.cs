using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w grze Ukryta Liczba!");

        bool czyGracDalej = true;
        while (czyGracDalej)
        {
            int iloscProb = GetAttemptsFromUser();
            int maxLiczba = GetMaxNumberFromUser();

            Random random = new Random();
            int ukrytaLiczba = random.Next(1, maxLiczba + 1);

            Console.WriteLine("\nZgadnij ukrytą liczbę z zakresu od 1 do " + maxLiczba + ".");
            Console.WriteLine("Masz " + iloscProb + " szans(ę).");

            bool zgadl = false;

            for (int proba = 1; proba <= iloscProb; proba++)
            {
                Console.Write("\nTwoja próba (pozostało " + (iloscProb - proba + 1) + " szans): ");
                int zgadniecie = GetIntegerInput();

                if (zgadniecie == ukrytaLiczba)
                {
                    Console.WriteLine("Gratulacje! Zgadłeś ukrytą liczbę " + ukrytaLiczba + " po " + proba + " próbach.");
                    zgadl = true;
                    break;
                }
                else if (zgadniecie < ukrytaLiczba)
                {
                    Console.WriteLine("Za mało!");
                }
                else
                {
                    Console.WriteLine("Za dużo!");
                }
            }

            if (!zgadl) //
            {
                Console.WriteLine("\nNiestety, nie udało Ci się zgadnąć. Sekretna liczba to: " + ukrytaLiczba);
            }

            Console.WriteLine("\nCzy chcesz zagrać ponownie? (tak/nie)");
            string odpowiedz = Console.ReadLine().ToLower();
            czyGracDalej = odpowiedz == "tak";
        }
    }

    static int GetAttemptsFromUser()
    {
        Console.Write("Podaj ilość szans na zgadnięcie liczby: ");
        return GetIntegerInput();
    }

    static int GetMaxNumberFromUser()
    {
        Console.Write("Podaj maksymalną liczbę, do jakiej można zgadywać: ");
        return GetIntegerInput();
    }

    static int GetIntegerInput()
    {
        int nieLiczba;
        while (!int.TryParse(Console.ReadLine(), out nieLiczba) || nieLiczba <= 0)
        {
            Console.Write("To nie jest liczba!. Tym razem podaj liczbę: ");
        }
        return nieLiczba;
    }
}
