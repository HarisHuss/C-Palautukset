using System;
using System.Numerics;

namespace RitariPeli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa peliin!☺");

            // Vihollinen Class
            Vihollinen vih = new Vihollinen();

            // Pelaaja Class
            Pelaaja player = new Pelaaja();


            while (true)
            {
                // Missä olet
                Console.WriteLine();
                Console.WriteLine($"Olet päävalikossa");
                Console.WriteLine($"Valitse mitä haluat tehdä");

                // Mihin haluat mennä
                Console.WriteLine("1. Kauppa");
                Console.WriteLine("2. Goblin");
                Console.WriteLine("3. Ritari");
                Console.WriteLine("4. Lohikäärme");
                Console.Write("Valinta: ");

                int valikko = int.Parse(Console.ReadLine());

                // Valikko

                if (valikko == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Olet Kauppassa");
                    Console.WriteLine($"Pelaajan Kulta: {player.Raha}");
                    Console.WriteLine($"Mitä haluat tehdä");

                    // Mitä haluat ostaa kaupasta
                    Console.WriteLine("1. Kyrpärä (5 kultaa) (Lisää 4 Elämää)");
                    Console.WriteLine("2. Haarniska (5 kultaa) (Lisää 5 Elämää)");
                    Console.WriteLine("3. Elämä juoma (5 kultaa) (Lisää 15 Elämää)");
                    Console.WriteLine("4. Miekkaan +1 vahinkoa (5 kultaa)");
                    Console.WriteLine("5. Taakse");
                    Console.Write("Valinta: ");
                    int valinta = int.Parse(Console.ReadLine());
                    if (player.Raha < 5)
                    {
                        Console.WriteLine("Sinulla ei ole riittävästi kultaa ostamiseen");
                    }
                    else
                    {
                        if (valinta == 1)
                        {
                            Console.WriteLine("Ostit kypärän (+3 elämää) (-5 kultaa)");
                            player.PelaajaHp += 3;
                            player.Raha -= 5;
                        }
                        if (valinta == 2)
                        {
                            Console.WriteLine("Ostit haarniskaa (+5 elämää) (-5 Kultaa)");
                            player.PelaajaHp += 5;
                            player.Raha -= 5;
                        }
                        if (valinta == 3)
                        {
                            Console.WriteLine("Ostit elämä juoman (-5 kultaa)");
                            player.juoma++;
                            player.Raha -= 5;
                        }
                        if (valinta == 4)
                        {
                            Console.WriteLine("Ostit vahvennuksen miekkaan +1 dmg (-5 gold)");
                            player.Damage++;
                            player.Raha -= 5;
                        }
                    }

                    if (valinta == 5)
                    {
                        continue;
                    }
                }


                // Onko pelaaja hävinnyt
                if (player.Havitty)
                {
                    Console.WriteLine("Kuolit ritarille");
                    return;
                }

                if (valikko == 2)
                {
                    while (!vih.Havitty)
                    {
                        // Missä olet
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan elämä: {player.PelaajaHp}");
                        Console.WriteLine($"Goblinin elämä: {vih.GoblinHp}");

                        // Tekeminen
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä kykyä");
                        Console.WriteLine($"3. Juoda elämä (juomat jäljellä : {player.juoma})");
                        Console.WriteLine("4. Peruuta");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        // Valinta
                        switch (val)
                        {
                            case 1:
                                player.Attack(vih);
                                break;
                            case 2:
                                player.UseAbility(vih);
                                break;
                            case 3:
                                {
                                    if (player.juoma > 0)
                                    {
                                        player.PelaajaHp += 20;
                                        player.juoma--;
                                    }
                                    if (player.juoma <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole elämä juomia");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pois taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi");
                                break;
                        }

                        // Vihollinen häisi
                        if (vih.Havitty)
                        {
                            Console.WriteLine("Tapoit Goblinin");
                            player.Raha += 10;
                            break;
                        }

                        // Hyökkäys pelaajaan
                        vih.Hyokkays(player);

                        // Onko hävitty
                        if (player.Havitty)
                        {
                            Console.WriteLine("Kuolit Goblinille");
                            return;
                        }
                    }
                }
                if (valikko == 3)
                {
                    while (!vih.HavittyRitari)
                    {
                        // Missä olet
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan elämä: {player.PelaajaHp}");
                        Console.WriteLine($"Ritarin elämä: {vih.GoblinHp}");

                        // Tekeminn
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä kykyä");
                        Console.WriteLine($"3. Juoda elämä (juomat jäljellä : {player.juoma})");
                        Console.WriteLine("4. Peruuta");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        // Valikko
                        switch (val)
                        {
                            case 1:
                                player.Attack(vih);
                                break;
                            case 2:
                                player.UseAbility(vih);
                                break;
                            case 3:
                                {
                                    if (player.juoma > 0)
                                    {
                                        player.PelaajaHp += 20;
                                    }
                                    if (player.juoma <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole elämä juomia");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pois taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi!");
                                break;
                        }

                        // Vihollinen hävinnyt
                        if (vih.HavittyRitari)
                        {
                            Console.WriteLine("Tapoit Ritarin");
                            player.Raha += 10;
                            break;
                        }

                        // Vihollinen hyökkää pelaajaan
                        vih.Hyokkays(player);

                        // Pelaaja hävinnyt
                        if (player.Havitty)
                        {
                            Console.WriteLine("Kuolit Ritarille");
                            continue;
                        }
                    }
                }
                if (valikko == 4)
                {
                    while (!vih.HavittyLohi)
                    {
                        // Missä olet
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan elämä: {player.PelaajaHp}");
                        Console.WriteLine($"Lohikäärmeen elämä: {vih.LohikäärmeHp}");

                        // Tekeminen
                        Console.WriteLine("Mitä haluat tehdä?");
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä abilitysi");
                        Console.WriteLine($"3. Käytä elämä juoma (juoma määrä : {player.juoma})");
                        Console.WriteLine("4. Peruuta");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        // Valikko
                        switch (val)
                        {
                            case 1:
                                player.Attack(vih);
                                break;
                            case 2:
                                player.UseAbility(vih);
                                break;
                            case 3:
                                {
                                    if (player.juoma > 0)
                                    {
                                        player.PelaajaHp += 20;
                                    }
                                    if (player.juoma <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole elämä juomia");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pois taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi!");
                                break;
                        }

                        // Vihollinen hävinnyt
                        if (vih.HavittyLohi)
                        {
                            Console.WriteLine("Tapoit Lohikäärmeen");
                            player.Raha += 15;
                            break;
                        }

                        // Vihollinen hyökkää
                        vih.Hyokkays(player);

                        // Pelaaja hävinnyt
                        if (player.Havitty)
                        {
                            Console.WriteLine("Kuolit Lohikäärmelle");
                            continue;
                        }
                    }
                }
            }
        }
    }
}