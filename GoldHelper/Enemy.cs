using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    public class Enemy
    {
        public enum Name
        {
            Pidgey,
            Chikorita,
            Sentret,
            Spearow,
            Rattata,
            Pidgeotto,
            Caterpie,
            Goldeen,
            Koffing,
            Geodude,
            Vulpix,
            Sandshrew,
            Machop,
            Onix,
            Ekans,
            Zubat

        }

        static public int getExpPoint(Name name)
        {
            int expPoint = 0;
            switch (name)
            {
                case Name.Pidgey:
                    expPoint = 55;
                    break;
                case Name.Chikorita:
                    expPoint = 64;
                    break;
                case Name.Sentret:
                    expPoint = 57;
                    break;
                case Name.Spearow:
                    expPoint = 58;
                    break;
                case Name.Rattata:
                    expPoint = 57;
                    break;
                case Name.Pidgeotto:
                    expPoint = 133;
                    break;
                case Name.Caterpie:
                    expPoint = 53;
                    break;
                case Name.Goldeen:
                    expPoint = 111;
                    break;
                case Name.Koffing:
                    expPoint = 114;
                    break;
                case Name.Geodude:
                    expPoint = 73;
                    break;
                case Name.Vulpix:
                    expPoint = 63;
                    break;
                case Name.Sandshrew:
                    expPoint = 93;
                    break;
                case Name.Machop:
                    expPoint = 75;
                    break;
                case Name.Onix:
                    expPoint = 108;
                    break;
                case Name.Ekans:
                    expPoint = 62;
                    break;
                case Name.Zubat:
                    expPoint = 54;
                    break;
                default:
                    break;
            }
            return expPoint;
        }

        static public Stats getStats(Name name)
        {
            Stats result = new Stats(0, 0, 0, 0, 0, 0);
            switch (name)
            {
                case Name.Pidgey:
                    result = new Stats(40, 45, 50, 56, 35, 35);
                    break;
                case Name.Chikorita:
                    result = new Stats(45, 49, 65, 45, 49, 65);
                    break;
                case Name.Sentret:
                    result = new Stats(35, 46, 34, 20, 35, 45);
                    break;
                case Name.Spearow:
                    result = new Stats(40, 60, 30, 70, 31, 31);
                    break;
                case Name.Rattata:
                    result = new Stats(30, 56, 35, 72, 25, 35);
                    break;
                case Name.Pidgeotto:
                    result = new Stats(63, 60, 55, 71, 50, 50);
                    break;
                case Name.Caterpie:
                    result = new Stats(45, 30, 35, 45, 20, 20);
                    break;
                case Name.Goldeen:
                    result = new Stats(45, 67, 60, 63, 35, 50);
                    break;
                case Name.Koffing:
                    result = new Stats(40, 65, 95, 35, 60, 45);
                    break;
                case Name.Geodude:
                    result = new Stats(40, 80, 100, 20, 30, 30);
                    break;
                case Name.Vulpix:
                    result = new Stats(38, 41, 40, 65, 50, 65);
                    break;
                case Name.Sandshrew:
                    result = new Stats(50, 75, 85, 40, 20, 30);
                    break;
                case Name.Machop:
                    result = new Stats(70, 80, 50, 35, 35, 35);
                    break;
                case Name.Onix:
                    result = new Stats(35, 45, 160, 70, 30, 45);
                    break;
                case Name.Ekans:
                    result = new Stats(35, 60, 44, 55, 40, 54);
                    break;
                case Name.Zubat:
                    result = new Stats(40, 45, 35, 55, 30, 40);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
