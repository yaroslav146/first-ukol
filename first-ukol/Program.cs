using System;

void Menu()
{
    Console.WriteLine();
    Console.WriteLine("Vítejte na programu!");
    Console.WriteLine("Vaše volby:");
    Console.WriteLine("1 - KALKULAČKA");
    Console.WriteLine("2 - POLE (součet, min, max, hledání)");
    Console.WriteLine("3 - ŘETĚZCE (délka, převrácení, palindrom)");
    Console.WriteLine("4 - KONEC");
    Console.WriteLine();
}

while (true)
{
    Menu();
    Console.Write("Zadejte volbu: ");
    string volbaText = Console.ReadLine();
    int volba;
    if (!int.TryParse(volbaText, out volba))
    {
        Console.WriteLine("Neplatná volba. Zkuste znovu.");
        continue;
    }

    if (volba == 1)
    {
        Kalkulacka();
    }
    else if (volba == 2)
    {
        PoleOperace();
    }
    else if (volba == 3)
    {
        RetezceOperace();
    }
    else if (volba == 4)
    {
        Console.WriteLine("Konec programu. Nashledanou!");
        break;
    }
    else
    {
        Console.WriteLine("Neznámá volba. Zkuste znovu.");
    }
}

static void Kalkulacka()
{
    Console.WriteLine();
    Console.WriteLine("KALKULAČKA - zadejte dvě čísla a operaci (+, -, *, /, ^):");

    double a = ReadDouble("První číslo: ");
    double b = ReadDouble("Druhé číslo: ");

    Console.Write("Operace (+, -, *, /, ^): ");
    string op = Console.ReadLine() ?? "";

    if (op == "+")
    {
        Console.WriteLine("Výsledek: " + (a + b));
    }
    else if (op == "-")
    {
        Console.WriteLine("Výsledek: " + (a - b));
    }
    else if (op == "*")
    {
        Console.WriteLine("Výsledek: " + (a * b));
    }
    else if (op == "/")
    {
        if (b == 0)
            Console.WriteLine("Chyba: dělení nulou není povoleno.");
        else
            Console.WriteLine("Výsledek: " + (a / b));
    }
    else if (op == "^")
    {
        double vys = Math.Pow(a, b);
        Console.WriteLine("Výsledek: " + vys);
    }
    else
    {
        Console.WriteLine("Neznámá operace.");
    }

    Pause();
}

static void PoleOperace()
{
    Console.WriteLine();
    Console.WriteLine("POLE - zadejte čísla postupně.");

    int pocet = ReadInt("Kolik čísel chcete zadat? ");
    if (pocet <= 0)
    {
        Console.WriteLine("Počet musí být větší než 0.");
        Pause();
        return;
    }

    double[] pole = new double[pocet];
    for (int i = 0; i < pocet; i++)
    {
        pole[i] = ReadDouble($"Číslo [{i}]: ");
    }

    double soucet = 0;
    double min = pole[0];
    double max = pole[0];
    for (int i = 0; i < pole.Length; i++)
    {
        double v = pole[i];
        soucet += v;
        if (v < min) min = v;
        if (v > max) max = v;
    }

    double prumer = soucet / pole.Length;

    Console.WriteLine("Součet: " + soucet);
    Console.WriteLine("Minimum: " + min);
    Console.WriteLine("Maximum: " + max);
    Console.WriteLine("Průměr: " + prumer);

    Console.Write("Chcete hledat prvek? (ano/ne): ");
    string odp = (Console.ReadLine() ?? "").Trim().ToLower();
    if (odp == "ano" || odp == "a")
    {
        double hledat = ReadDouble("Zadejte hodnotu k vyhledání: ");
        bool found = false;
        string indexes = "";
        for (int i = 0; i < pole.Length; i++)
        {
            if (pole[i] == hledat)
            {
                if (found) indexes += ", ";
                indexes += i.ToString();
                found = true;
            }
        }
        if (found)
            Console.WriteLine("Prvek nalezen na indexech: " + indexes);
        else
            Console.WriteLine("Prvek nebyl nalezen.");
    }

    Pause();
}

static void RetezceOperace()
{
    Console.WriteLine();
    Console.WriteLine("ŘETĚZCE - zadejte text:");
    string text = Console.ReadLine() ?? "";

    Console.WriteLine("Délka: " + text.Length);

    // převrácení řetězce
    char[] znaky = text.ToCharArray();
    for (int i = 0, j = znaky.Length - 1; i < j; i++, j--)
    {
        char tmp = znaky[i];
        znaky[i] = znaky[j];
        znaky[j] = tmp;
    }
    string reversed = new string(znaky);
    Console.WriteLine("Převráceně: " + reversed);

    // kontrola palindromu (ignoruje nepísmená/nezákladní znaky - jen jednoduché)
    string norm = "";
    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if (char.IsLetterOrDigit(c))
            norm += char.ToLower(c);
    }

    // převrácení norm
    char[] nn = norm.ToCharArray();
    for (int i = 0, j = nn.Length - 1; i < j; i++, j--)
    {
        char tmp = nn[i];
        nn[i] = nn[j];
        nn[j] = tmp;
    }
    string normRev = new string(nn);

    if (norm.Length > 0 && norm == normRev)
        Console.WriteLine("Je palindrom: ANO");
    else
        Console.WriteLine("Je palindrom: NE");

    Pause();
}

static int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string s = Console.ReadLine() ?? "";
        int x;
        if (int.TryParse(s, out x)) return x;
        Console.WriteLine("Neplatné číslo. Zkuste znovu.");
    }
}

static double ReadDouble(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string s = Console.ReadLine() ?? "";
        double x;
        if (double.TryParse(s, out x)) return x;
        Console.WriteLine("Neplatné číslo. Zkuste znovu.");
    }
}

static void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Stiskněte ENTER pro návrat do menu...");
    Console.ReadLine();
}






