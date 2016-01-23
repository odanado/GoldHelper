using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    public class IVManager
    {
        public IVCand HP { get; set; }
        public IVCand Atk { get; set; }
        public IVCand Def { get; set; }
        public IVCand Spd { get; set; }
        public IVCand Spc { get; set; }

        public IVManager()
        {
            HP = new IVCand();
            Atk = new IVCand();
            Def = new IVCand();
            Spd = new IVCand();
            Spc = new IVCand();
        }

        public override string ToString()
        {
            string result = "";

            result += String.Format("HP = {0}\r\n", HP.ToString());
            result += String.Format("Atk = {0}\r\n", Atk.ToString());
            result += String.Format("Def = {0}\r\n", Def.ToString());
            result += String.Format("Spd = {0}\r\n", Spd.ToString());
            result += String.Format("Spc = {0}\r\n", Spc.ToString());

            return result;
        }

        public IVCand this[int idx]
        {
            get
            {
                switch(idx)
                {
                    case 0: return HP;
                    case 1: return Atk;
                    case 2: return Def;
                    case 3: return Spd;
                    default: return Spc;

                }
            }
        }

        public void update()
        {
            updateHP();
            updateIVs();
            updateHP();
            updateIVs();
        }

        // HPを更新する
        public void updateHP()
        {
            IVCand[] ivCands = { Atk, Def, Spd, Spc };
            for (int i = 0; i < ivCands.Length; i++)
            {
                var ivCand = ivCands[i];
                Boolean isOdd = true;
                Boolean isEven = true;
                // 有効な個体値が全て奇数か偶数か
                for (int iv = 0; iv < 16; iv++)
                {
                    if (ivCand.get(iv))
                    {
                        isOdd &= iv % 2 == 1;
                        isEven &= iv % 2 == 0;
                    }

                }

                // どちらもfalse -> 情報が未確定
                if (!isOdd && !isEven) continue;

                // 全て奇数なら対応するbitを立てる
                int mask = 0;
                if (isOdd) mask = 1 << (3 - i);

                // 情報が確定しているので更新
                for (int iv = 0; iv < 16; iv++)
                {
                    // 3-i番目のbitが異なる
                    if (((iv ^ mask) >> (3 - i)) % 2 == 1)
                    {
                        HP.reset(iv);
                    }
                }

            }

        }

        public void updateIVs()
        {
            IVCand[] ivCands = { Atk, Def, Spd, Spc };
            for (int i = 0; i < ivCands.Length; i++)
            {
                var ivCand = ivCands[i];
                Boolean isOdd = true;
                Boolean isEven = true;

                // 有効なHPの個体値のうち、3-i番目のbitを調べる
                for (int iv = 0; iv < 16; iv++)
                {
                    if (HP.get(iv))
                    {
                        isOdd &= (iv >> (3 - i)) % 2 == 1;
                        isEven &= (iv >> (3 - i)) % 2 == 0;
                    }

                }

                // どちらもfalse -> 情報が未確定
                if (!isOdd && !isEven)
                {
                    continue;
                }

                for (int iv = 0; iv < 16; iv++)
                {
                    if (isOdd)
                    {
                        if (iv % 2 == 0) ivCand.reset(iv);
                    }
                    if (isEven)
                    {
                        if (iv % 2 == 1) ivCand.reset(iv);
                    }
                }
            }
        }
    }
}