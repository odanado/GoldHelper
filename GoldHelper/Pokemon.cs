using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    public class Pokemon
    {
        public Stats IV { get; set; }
        public Stats EV { get; set; }
        public Stats BaseStats { get; set; }
        public Stats Stats { get; }
        public int Level { get; set; }
        public int ExpPoint { get; set; }

        public Pokemon()
        {
            ExpPoint = 135;
            IV = new Stats(0, 0, 0, 0, 0, 0);
            EV = new Stats(0, 0, 0, 0, 0, 0);
            Stats = new Stats(0, 0, 0, 0, 0, 0);

        }
        public override string ToString()
        {
            string result = "";

            result += String.Format("BaseStats = {0}\r\n", BaseStats.ToString());
            result += String.Format("IV = {0}\r\n", IV.ToString());
            result += String.Format("EV = {0}\r\n", EV.ToString());
            result += String.Format("Stats = {0}\r\n", Stats.ToString());
            result += String.Format("Leval = {0}\r\n", Level);
            result += String.Format("ExpPoint = {0}\r\n", ExpPoint);

            return result;
        }

        public void update()
        {
            levelUp();
            Stats.Atk = calcStats(BaseStats.Atk, IV.Atk, toEVLevel(EV.Atk), Level);
            Stats.Def = calcStats(BaseStats.Def, IV.Def, toEVLevel(EV.Def), Level);
            Stats.Spd = calcStats(BaseStats.Spd, IV.Spd, toEVLevel(EV.Spd), Level);
            Stats.SpAtk = calcStats(BaseStats.SpAtk, IV.SpAtk, toEVLevel(EV.SpAtk), Level);
            Stats.SpDef = calcStats(BaseStats.SpDef, IV.SpAtk, toEVLevel(EV.SpAtk), Level);
            Stats.HP = calcHP(BaseStats.HP, IV.HP, toEVLevel(EV.HP), Level);
        }

        private void levelUp()
        {
            Level = 0;
            while (requireExpPoint(Level + 1) <= ExpPoint)
            {
                Level++;
            }
        }

        private int requireExpPoint(int level)
        {
            return Math.Max(0, 6 * level * level * level / 5 - 15 * level * level + 100 * level - 140);
        }

        private int toEVLevel(int ev)
        {
            if (ev == 0) return 0;
            return (int)(Math.Sqrt(ev - 1) + 1) / 4;
        }

        private int calcStats(int baseStats, int iv, int evLevel, int level)
        {
            int result = 0;
            result = (2 * (baseStats + iv) + (evLevel)) * level / 100 + 5;
            return result;
        }
        private int calcHP(int baseStats, int iv, int evLevel, int level)
        {
            int result = 0;
            result = (2 * (baseStats + iv) + (evLevel)) * level / 100 + 10 + level;
            return result;
        }
    }
}
