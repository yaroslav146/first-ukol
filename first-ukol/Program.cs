using System.Diagnostics;
using System.Linq;
string user_input;
int volba;
int allert;
void menu()
{
    Console.WriteLine("Vítejte na programu nepláceneho, hládoveho IT-aka!");
    Console.WriteLine("Váše volby:");
    Console.WriteLine("-- 1 -- KALKULACKA");
    Console.WriteLine("-- 2 -- RETEZCE");
    Console.WriteLine("-- 3 -- KONEC - *konec programu");
}
void kalkulacka()
{
    // součet, minimum, maximum, vyhledání prvku
    Console.Clear();
    int pocet_kalkulacky;
    Console.WriteLine("KALKULACKA");
    List<double> kalkulacka_cisla = new List<double> { };
    allert = 1;

    while (true)
    {
        if (allert != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Chyba vstupu!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Kolik cisel chcete?   ! MAX 10 !");
            Console.Write("Zádejte pocet ještě jednou: ");
        }
        else
        {
            Console.WriteLine("Kolik cisel chcete?   ! MAX 10 !");
            Console.Write("zadejte pocet: ");
        }

        user_input = Console.ReadLine();

        if (int.TryParse(user_input, out pocet_kalkulacky) && pocet_kalkulacky >= 1 && pocet_kalkulacky <= 10)
        {
            break;
        }
        else
            allert--;
    }
    for (int i = 0; i < pocet_kalkulacky; i++)
    {
        Console.Write($"zadejte cislo #{i+1}: ");
        while (true)
        {
            var cislo_lorem = Console.ReadLine();
            if (double.TryParse(cislo_lorem, out double cislo))
            {
                kalkulacka_cisla.Add((double)cislo);
                break;
            }
                
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Chyba vstupu! To není platné číslo.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Zadejte cislo #{i+1} jeste jednou: ");
            }
        }
    }
    Console.WriteLine(string.Join(", ", kalkulacka_cisla));
    Console.WriteLine($"Soucet cisel: {kalkulacka_cisla.Sum()}");
    Console.WriteLine($"Nejmensi cislo: {kalkulacka_cisla.Min()}");
    Console.WriteLine($"Nejvetsi cislo: {kalkulacka_cisla.Max()}");
    Console.WriteLine("Vyhledani prvku se mi nechce dělat uz aj tak mi z toho boli hlava :(");
    Console.ReadLine();
}
void retezce()
{
    Console.Clear();
    Console.WriteLine("RETEZCE");

    Console.Write("Zadejte retezec: ");
    string retezec = Console.ReadLine();

    Console.WriteLine($"Delka retezce: {retezec.Length}");

    char[] znaky = retezec.ToCharArray();
    Array.Reverse(znaky);
    string obraceny_retezec = new string(znaky);

    Console.WriteLine($"Prevraceny retezec: {obraceny_retezec}");

    if (palindrom(retezec, 0, retezec.Length - 1))
    {
        Console.WriteLine("Palindrom: ANO");
    }
    else
    {
        Console.WriteLine("Palindrom: NE");
    }

    Console.ReadLine();
}
// Priznavam pro palidrom jsem potreboval pomoc AI
bool palindrom(string retezec, int zacatek, int konec)
{
    if (zacatek >= konec)
    {
        return true;
    }

    if (retezec[zacatek] != retezec[konec])
    {
        return false;
    }

    return palindrom(retezec, zacatek + 1, konec - 1);
}


while (true)
{
    menu();
    allert = 1;
    do
    {
        Console.WriteLine(allert);
        if (allert != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Chyba vstupu!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Zádejte svojí volbu ještě jednou: ");
        }
        else
            Console.Write("Zádejte volbu: ");
        user_input = Console.ReadLine();
        allert--;
    } while (!int.TryParse(user_input, out volba) || volba < 1 || volba > 3);

    Console.WriteLine();
    switch(volba)
    {
        case 1:
            kalkulacka();
            break;
        case 2:
            retezce();
            break;
        case 3:
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"ukonceni za: {i}");
                Thread.Sleep(1000);
            }
            Console.Clear();


            string odkaz = "https://media.tenor.com/JnX58Fqz8RcAAAAM/konosuba-anime.gif";
            Process.Start(new ProcessStartInfo
            {
                FileName = odkaz,
                UseShellExecute = true
            });
            Environment.Exit(0);
            break;
    }
    Console.Clear();    
}






