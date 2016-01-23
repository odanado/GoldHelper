using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    class GoldHelper
    {
        public Pokemon pokemon { get; set; }
        public IVManager ivManager { get; }

        public GoldHelper()
        {
            pokemon = new Pokemon();
            ivManager = new IVManager();
        }
        public override string ToString()
        {
            string result = "";

            result += pokemon.ToString();
            result += "\r\n";
            result += ivManager.ToString();

            return result;
        }

        public void kill(Enemy.Name name, int level, bool isWild)
        {
            int expPoint = level * Enemy.getExpPoint(name) / 7;
            if (!isWild) expPoint = expPoint * 3 / 2;
            pokemon.ExpPoint += expPoint;
            pokemon.EV += Enemy.getStats(name);
            pokemon.update();
        }

        public void updateHP(int hp)
        {
            update(0, hp);
        }

        public void updateAtk(int atk)
        {
            update(1, atk);
        }

        public void updateDef(int def)
        {
            update(2, def);
        }

        public void updateSpd(int spd)
        {
            update(3, spd);
        }

        public void updateSpAtk(int spAtk)
        {
            update(4, spAtk);
        }

        public void updateSpDef(int spDef)
        {
            update(5, spDef);
        }

        void update(int idx, int stats)
        {
            for (int iv = 0; iv < 16; iv++)
            {
                // idx == 5(Dについてのupdate) の時にはCの個体値を更新して使う
                pokemon.IV[Math.Min(idx, 4)] = iv;
                pokemon.update();
                if (pokemon.Stats[idx] != stats)
                    ivManager[idx].reset(iv);
            }

            ivManager.update();
        }


    }



}
