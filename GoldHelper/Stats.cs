using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    public class Stats
    {
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }

        public Stats(int hp, int atk, int def, int spd, int spAtk, int spDef)
        {
            HP = hp;
            Atk = atk;
            Def = def;
            Spd = spd;
            SpAtk = spAtk;
            SpDef = spDef;

        }
        public override string ToString()
        {
            string result = "";

            result += String.Format("HP: {0} ", HP);
            result += String.Format("Atk: {0} ", Atk);
            result += String.Format("Def: {0} ", Def);
            result += String.Format("Spd: {0} ", Spd);
            result += String.Format("SpAtk: {0} ", SpAtk);
            result += String.Format("SpDef: {0} ", SpDef);

            return result;
        }

        public static Stats operator +(Stats s1, Stats s2)
        {
            return new Stats(s1.HP + s2.HP, s1.Atk + s2.Atk, s1.Def + s2.Def, s1.Spd + s2.Spd, s1.SpAtk + s2.SpAtk, s1.SpDef + s2.SpDef);
        }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return HP;
                    case 1: return Atk;
                    case 2: return Def;
                    case 3: return Spd;
                    case 4: return SpAtk;
                    default: return SpDef;
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        HP = value;
                        break;
                    case 1:
                        Atk = value;
                        break;
                    case 2:
                        Def = value;
                        break;
                    case 3:
                        Spd = value;
                        break;
                    case 4:
                        SpAtk = value;
                        break;
                    default:
                        SpDef = value;
                        break;
                }
            }

        }
    }
}
