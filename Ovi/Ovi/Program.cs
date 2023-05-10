using System;

enum OvenState
{
    Auki,
    Kiinni,
    Lukittu
}

class Program
{
    static void Main()
    {
        OvenState state = OvenState.Kiinni;

        while (true)
        {
            Console.WriteLine("Oven tila: " + state);

            Console.Write("Anna komento (Avaa lukko, Avaa, Sulje, Lukitse): ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "avaa lukko":
                    if (state == OvenState.Lukittu)
                    {
                        state = OvenState.Kiinni;
                        Console.WriteLine("Lukko avattu.");
                    }
                    else
                    {
                        Console.WriteLine("Virhe: Lukkoa ei voi avata tässä tilassa.");
                    }
                    break;
                case "avaa":
                    if (state == OvenState.Kiinni)
                    {
                        state = OvenState.Auki;
                        Console.WriteLine("Ovi avattu.");
                    }
                    else
                    {
                        Console.WriteLine("Virhe: Ovea ei voi avata tässä tilassa.");
                    }
                    break;
                case "sulje":
                    if (state == OvenState.Auki)
                    {
                        state = OvenState.Kiinni;
                        Console.WriteLine("Ovi suljettu.");
                    }
                    else
                    {
                        Console.WriteLine("Virhe: Ovea ei voi sulkea tässä tilassa.");
                    }
                    break;
                case "lukitse":
                    if (state == OvenState.Kiinni)
                    {
                        state = OvenState.Lukittu;
                        Console.WriteLine("Ovi lukittu.");
                    }
                    else
                    {
                        Console.WriteLine("Virhe: Ovea ei voi lukita tässä tilassa.");
                    }
                    break;
                default:
                    Console.WriteLine("Virhe: Tuntematon komento.");
                    break;
            }
        }
    }
}
