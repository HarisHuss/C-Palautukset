using System;

namespace RitariPeli
{
    class Pelaaja
    {
        // Pelaajan elämä
        public int PelaajaHp { get; set; } = 100;

        // Pelaajan kyvyn cooldown
        public int AbilCoolD { get; set; } = 3;

        // Onko pelaaja hävinnyt
        public bool Havitty { get { return PelaajaHp <= 0; } }
        public int juoma { get; set; } = 0;
        public int Raha { get; set; } = 0;

        // Ritarin hyökkäys vahinko määrä
        public int Damage { get; set; } = 7;

        // Vuorojen määrä kyvyn käyttöön
        private int abilCoolDJlj = 0;



        // Hyökkäys viholliseen
        public void Attack(Vihollinen vih)
        {
            int damage = Damage;
            Console.WriteLine($"Hyökkäsit viholliseen ja teit {damage} vahinkoa");

            // Apply damage to the enemy
            vih.Vahinko(damage);
        }

        // Pelaaja ottaa vahinkoa
        public void Vahinko(int vah)
        {
            PelaajaHp -= vah;
            Console.WriteLine($"Otit viholliselta {vah} vahinkoa");
        }
        public void UseAbility(Vihollinen vih)
        {
            // Onko kyky vielä cooldownissa
            if (abilCoolDJlj > 0)
            {
                Console.WriteLine("Kyky on vielä cooldownissa");
                return;
            }

            int vah = Damage * 2;
            Console.WriteLine($"Käytit kykyä viholliseen ja teit {vah} vahinkoa");

            vih.Vahinko(vah);

            // Laittaa cooldownia
            abilCoolDJlj = AbilCoolD;
        }


    }
}