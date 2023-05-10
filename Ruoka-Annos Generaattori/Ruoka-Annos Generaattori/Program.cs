using System;

enum MainIngredient
{
    Nautaa,
    Kanaa,
    Kasviksia
}

enum SideDish
{
    Perunaa,
    Riisiä,
    Pastaa
}

enum Sauce
{
    Curry,
    Hapanimelä,
    Pippuri,
    Chili
}

class Program
{
    static void Main()
    {
        // Luodaan tuples-muuttuja kuvaamaan ruoka-annosta
        Tuple<MainIngredient, SideDish, Sauce> meal;

        // Kysytään käyttäjältä pääraaka-aine
        Console.Write("Valitse pääraaka-aine (nautaa, kanaa, kasviksia): ");
        MainIngredient mainIngredient;
        Enum.TryParse(Console.ReadLine(), out mainIngredient);

        // Kysytään käyttäjältä lisuke
        Console.Write("Valitse lisuke (perunaa, riisiä, pastaa): ");
        SideDish sideDish;
        Enum.TryParse(Console.ReadLine(), out sideDish);

        // Kysytään käyttäjältä kastike
        Console.Write("Valitse kastike (curry, hapanimelä, pippuri, chili): ");
        Sauce sauce;
        Enum.TryParse(Console.ReadLine(), out sauce);

        // Tallennetaan käyttäjän valinnat tuples-muuttujaan
        meal = new Tuple<MainIngredient, SideDish, Sauce>(mainIngredient, sideDish, sauce);

        // Tulostetaan käyttäjän valitsema ruoka-annos
        Console.WriteLine($"{mainIngredient} ja {sideDish} {sauce}-kastikkeella.");
    }
}
