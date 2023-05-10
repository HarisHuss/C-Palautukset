using System;
class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }

    public override string ToString()
    {
        return "Nuoli";
    }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }

    public override string ToString()
    {
        return "Jousi";
    }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }

    public override string ToString()
    {
        return "Köysi";
    }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }

    public override string ToString()
    {
        return "Vesi";
    }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }

    public override string ToString()
    {
        return "Ruokaa";
    }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }

    public override string ToString()
    {
        return "Miekka";
    }
}

class VaritettyTavara<T> where T : Tavara
{
    public T Tavara { get; }
    public ConsoleColor Vari { get; }

    public VaritettyTavara(T tavara, ConsoleColor vari)
    {
        Tavara = tavara;
        Vari = vari;
    }

    public void NaytaTavara()
    {
        Console.ForegroundColor = Vari;
        Console.WriteLine(Tavara.ToString());
        Console.ResetColor();
    }
}

class Ohjelma
{
    static void Main(string[] args)
    {
        VaritettyTavara<Nuoli> varitettyNuoli = new VaritettyTavara<Nuoli>(new Nuoli(), ConsoleColor.Red);
        varitettyNuoli.NaytaTavara();

        VaritettyTavara<Miekka> varitettymiekka = new VaritettyTavara<Miekka>(new Miekka(), ConsoleColor.Blue);
        varitettymiekka.NaytaTavara();

        VaritettyTavara<Vesi> varitettymuki = new VaritettyTavara<Vesi>(new Vesi(), ConsoleColor.DarkCyan);
        varitettymuki.NaytaTavara();
    }
}