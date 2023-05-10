using System;

public struct Koordinaatti
{
    public readonly int X;
    public readonly int Y;

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void OnVieressa()
    {
        if (X == 0 && Y == 0)
        {
            Console.WriteLine("Annettu kordinaatti on kordinaatissa 0,0");
        }
        else if (Math.Abs(X) <= 1 && Math.Abs(Y) <= 1)
        {
            Console.WriteLine($"Annettu kordinaatti {X},{Y} on kordinaatissa 0,0 vieressä");
        }
        else
        {
            Console.WriteLine($"Annettu kordinaatti {X},{Y} ei ole kordinaatissa 0,0 vieressä");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Koordinaatti k1 = new Koordinaatti(-1, -1);
        Koordinaatti k2 = new Koordinaatti(-1, 0);
        Koordinaatti k3 = new Koordinaatti(-1, 1);
        Koordinaatti k4 = new Koordinaatti(0, -1);
        Koordinaatti k5 = new Koordinaatti(0, 0);
        Koordinaatti k6 = new Koordinaatti(0, 1);
        Koordinaatti k7 = new Koordinaatti(1, -1);
        Koordinaatti k8 = new Koordinaatti(1, 0);
        Koordinaatti k9 = new Koordinaatti(1, 1);

        k1.OnVieressa();
        k2.OnVieressa();
        k3.OnVieressa();
        k4.OnVieressa();
        k5.OnVieressa();
        k6.OnVieressa();
        k7.OnVieressa();
        k8.OnVieressa();
        k9.OnVieressa();
    }
}