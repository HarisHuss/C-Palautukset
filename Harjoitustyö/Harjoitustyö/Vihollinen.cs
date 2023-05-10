using System;

namespace RitariPeli
{
    class Vihollinen
    {
        // Elämät
        public int RitariHp { get; set; } = 80;
        public int GoblinHp { get; set; } = 50;
        public int LohikäärmeHp { get; set; } = 175;

        // Vihollinen heikko kykyyn
        public bool Weak { get; set; } = false;

        // Vihollisen hyökkäys DMG
        public int HyokkaysDMG { get; set; } = 5;


        // Hyökkäys viholliseen
        public void Vahinko(int vah)
        {
            // Onko kyky heikkous
            if (Weak)
            {
                vah *= 2;
                Console.WriteLine($"iskit vihollisen heikkoon kohtaan ja teit {vah} vahinkoa");
            }
            else
            {
                Console.WriteLine($"iskit viholliseen ja teit {vah} vahinkoa");
            }

            RitariHp -= vah;
            LohikäärmeHp -= vah;
            GoblinHp -= vah;
        }

        // Vihollinen hyökkäys
        public void Hyokkays(Pelaaja player)
        {
            int vah = HyokkaysDMG;
            Console.WriteLine($"Vihollinen hyökkäsi ja teki {vah} vahinkoa");
            player.Vahinko(vah);
        }
        // Onko vihollinen hävinnyt
        public bool HavittyLohi { get { return LohikäärmeHp <= 0; } }
        public bool Havitty { get { return GoblinHp <= 0; } }
        public bool HavittyRitari { get { return RitariHp <= 0; } }
    }
}