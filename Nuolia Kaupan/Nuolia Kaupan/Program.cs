using System;

string karkitilaus = "a";
string peratilaus = "b";
int pituustilaus = 0;
string pituus;
string valinta;

Console.WriteLine("Haluatko tehdä oma nuolia vai haluatko valmiina olevan? (p = Valmiina oleva, o = Oma tekemä)");
while (true)
{
    valinta = Console.ReadLine();
    if (valinta == "p" || valinta == "o")
    {
        break;
    }
}

Nuoli tilattuNuoli;
if (valinta == "p")
{
    Console.WriteLine("Valitse nuolen tyyppi (1 = aloittelijanuoli, 2 = perusnuoli, 3 = eliitti nuoli)");
    while (true)
    {
        string valittuNuoli = Console.ReadLine();
        if (valittuNuoli == "1")
        {
            tilattuNuoli = Nuoli.LuoAloittelijanuoli();

            break;
        }
        else if (valittuNuoli == "2")
        {
            tilattuNuoli = Nuoli.LuoPerusnuoli();
            break;
        }
        else if (valittuNuoli == "3")
        {
            tilattuNuoli = Nuoli.LuoEliittiNuoli();
            break;
        }
    }
}
else
{
    Console.WriteLine("Minkälainen kärki (puu, teräs, timantti) :");
    while (karkitilaus != "puu" || karkitilaus != "teräs" || karkitilaus != "timantti")
    {
        karkitilaus = Console.ReadLine();
        if (karkitilaus == "puu" || karkitilaus == "timantti" || karkitilaus == "teräs")
        {
            break;
        }
    }
    Console.WriteLine("Minkälainen perä (lehti, kanansulka, kotkansulka) :");
    while (peratilaus != "lehti" || peratilaus != "kanansulka" || peratilaus != "kotkansulka")
    {
        peratilaus = Console.ReadLine();
        if (peratilaus == "lehti" || peratilaus == "kanansulka" || peratilaus == "kotkansulka")
        {
            break;
        }
    }
    Console.WriteLine("Nuolen pituus (60-100cm) :");
    while (pituustilaus < 60 || pituustilaus > 100)
    {
        pituus = Console.ReadLine();
        if (int.TryParse(pituus, out pituustilaus) == true && pituustilaus < 100 && pituustilaus > 60)
        {
            break;
        }
    }
    tilattuNuoli = new Nuoli(karkitilaus, peratilaus, pituustilaus);
}

Console.WriteLine("Nuoli maksaa " + tilattuNuoli.PalautaHinta + " kultaa");

public class Nuoli
{
    private string _karki;
    private string _pera;
    private double _pituus;
    private double nuolenhinta;

    public Nuoli(string karki, string pera, int pituus)
    {
        _karki = karki;
        _pera = pera;
        _pituus = pituus;
        if (_karki == "puu")
        {
            nuolenhinta += 3;
        }
        if (_karki == "teräs")
        {
            nuolenhinta += 5;
        }
        if (_karki == "timantti")
        {
            nuolenhinta += 50;
        }
        if (_pera == "kanansulka")
        {
            nuolenhinta += 1;
        }
        if (_pera == "kotkansulka")
        {
            nuolenhinta += 5;
        }
        nuolenhinta = nuolenhinta + _pituus * 0.05;
        return;
    }
    public static Nuoli LuoEliittiNuoli()
    {
        return new Nuoli("timantti", "kotkansulka", 100);
    }
    public static Nuoli LuoAloittelijanuoli()
    {
        return new Nuoli("puu", "kanansulka", 70);
    }
    public static Nuoli LuoPerusnuoli()
    {
        return new Nuoli("teräs", "kanansulka", 85);
    }

    public double PalautaHinta
    {
        get { return nuolenhinta; }
        set { nuolenhinta = value; }
    }
    public string Karki
    {
        get { return _karki; }
        set { _karki = value; }
    }
    public string Pera
    {
        get { return _pera; }
        set { _pera = value; }
    }
    public double Pituus
    {
        get { return _pituus; }
        set { _pituus = value; }
    }
}