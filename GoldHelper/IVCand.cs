using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper
{
    // 個体値の候補
    public class IVCand
    {
        private Boolean[] valid;
        public IVCand()
        {
            valid = new Boolean[16];
            for (int i = 0; i < valid.Length; i++)
            {
                valid[i] = true;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < 16; i++)
            {
                result += String.Format("{0}: {1} ",i, valid[i]);
            }
            return result;
        }

        public string getValidRange()
        {
            string result = "";

            int min = 16;
            int max = 0;
            for (int i = 0; i < 16; i++)
            {
                if (valid[i])
                {
                    min = Math.Min(i, min);
                    max = Math.Max(i, max);
                }
            }

            if (min != max) result += String.Format("{0}-{1}", min, max);
            else result += String.Format(" {0}", min);

            return result;
        }

        public void set(int iv)
        {
            valid[iv] = true;
        }

        public void reset(int iv)
        {
            valid[iv] = false;
        }

        public Boolean get(int iv)
        {
            return valid[iv];
        }

    }
}
