using System;
using System.Collections.Generic;

class Tavara
{
    public float Paino { get; }
    public float Tilavuus { get; }

    public Tavara(float paino, float tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1f, 0.05f) { }

    public override string ToString()
    {
        return "Nuoli";
    }
}

class Jousi : Tavara
{
    public Jousi() : base(1f, 4f) { }

    public override string ToString()
    {
        return "Jousi";
    }
}

class Köysi : Tavara
{
    public Köysi() : base(1f, 1.5f) { }

    public override string ToString()
    {
        return "Köysi";
    }
}

class Vesi : Tavara
{
    public Vesi() : base(2f, 2f) { }

    public override string ToString()
    {
        return "Vesi";
    }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1f, 0.5f) { }

    public override string ToString()
    {
        return "RuokaAnnos";
    }
}

class Miekka : Tavara
{
    public Miekka() : base(5f, 3f) { }

    public override string ToString()
    {
        return "Miekka";
    }
}

class Reppu
{
    private List<Tavara> tavarat;
    public int MaxTavarat { get; }
    public float MaxPaino { get; }
    public float MaxTilavuus { get; }

    public int TavaroidenMaara => tavarat.Count;
    public float TavaroidenPaino { get; private set; }
    public float TavaroidenTilavuus { get; private set; }

    public override string ToString()
    {
        if (tavarat.Count == 0)
        {
            return "Reppu on tyhjä.";
        }

        string sisalto = "Reppussa on seuraavat tavarat: ";
        for (int i = 0; i < tavarat.Count; i++)
        {
            sisalto += tavarat[i].ToString();
            if (i < tavarat.Count - 1)
            {
                sisalto += ", ";
            }
        }
        return sisalto;
    }

    public Reppu(int maxTavarat, float maxPaino, float maxTilavuus)
    {
        tavarat = new List<Tavara>();
        MaxTavarat = maxTavarat;
        MaxPaino = maxPaino;
        MaxTilavuus = maxTilavuus;
    }

    public bool Lisaa(Tavara tavara)
    {
        if (TavaroidenMaara < MaxTavarat &&
            TavaroidenPaino + tavara.Paino <= MaxPaino &&
            TavaroidenTilavuus + tavara.Tilavuus <= MaxTilavuus)
        {
            tavarat.Add(tavara);
            TavaroidenPaino += tavara.Paino;
            TavaroidenTilavuus += tavara.Tilavuus;
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reppu reppu = new Reppu(10, 30, 20);
        Console.WriteLine(reppu.ToString());
        Console.WriteLine("Valitse lisättävä tavara:");
        Console.WriteLine("1. Nuoli");
        Console.WriteLine("2. Jousi");
        Console.WriteLine("3. Köysi");
        Console.WriteLine("4. Vesi");
        Console.WriteLine("5. Ruoka-annos");
        Console.WriteLine("6. Miekka");

        while (true)
        {
            int valinta = int.Parse(Console.ReadLine());
            Tavara tavara = null;

            switch (valinta) {
                case 1: tavara = new Nuoli(); break;
                case 2: tavara = new Jousi(); break;
                case 3: tavara = new Köysi(); break;
                case 4: tavara = new Vesi(); break;
                case 5: tavara = new RuokaAnnos(); break;
                case 6: tavara = new Miekka(); break;
            }

            if (reppu.Lisaa(tavara))
            {
                Console.WriteLine("Tavara lisätty.");
            }
            else
            {
                Console.WriteLine("Ei voi lisätä, reppu täynnä tai liian painava.");
            }

            Console.WriteLine($"Repussa on {reppu.TavaroidenMaara} / 10 tavaraa, paino {reppu.TavaroidenPaino} / 30 ja tilavuus {reppu.TavaroidenTilavuus} / 20.");
        }
    }
}