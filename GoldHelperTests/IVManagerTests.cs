using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoldHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldHelper.Tests
{
    [TestClass()]
    public class GoldHelperTests
    {
        [TestMethod()]
        public void updateHPTest()
        {
            var gh = new IVManager();
            IVCand[] ivCands = { gh.Atk, gh.Def, gh.Spd, gh.Spc };

            // 3->1,2->?,1->1,0->0
            for (int iv = 0; iv < 16; iv++)
            {
                if (iv % 2 == 1)
                {
                    gh.Atk.set(iv);
                    gh.Spd.set(iv);
                    gh.Spc.reset(iv);
                }
                else
                {
                    gh.Atk.reset(iv);
                    gh.Spd.reset(iv);
                    gh.Spc.set(iv);
                }
                gh.Def.set(iv);
            }

            gh.updateHP();

            for (int iv = 0; iv < 16; iv++)
            {
                if (iv == 10 || iv == 14)
                    Assert.IsTrue(gh.HP.get(iv));
                else
                    Assert.IsFalse(gh.HP.get(iv));
            }

        }

        [TestMethod()]
        public void updateIVsTest()
        {
            var gh = new IVManager();
            IVCand[] ivCands = { gh.Atk, gh.Def, gh.Spd, gh.Spc };

            for (int iv = 0; iv < 16; iv++)
            {
                gh.HP.reset(iv);
            }
            gh.HP.set(15);
            gh.updateIVs();


            for (int i = 0; i < ivCands.Length; i++)
            {
                var ivCand = ivCands[i];

                for (int iv = 0; iv < 16; iv++)
                {
                    // 偶数なのにbitが立っている
                    if (iv % 2 == 0 && ivCand.get(iv))
                        Assert.Fail();

                    if (iv % 2 == 1 && !ivCand.get(iv))
                        Assert.Fail();

                }

            }

            gh.HP.reset(15);
            gh.HP.set(12);
            gh.HP.set(6);
            gh.updateIVs();
            // atk->?, def->1, spd->?, spc->0

            for (int iv = 0; iv < 16; iv++)
            {
                Assert.IsTrue(gh.Atk.get(iv));
            }

            for (int iv = 0; iv < 16; iv++)
            {
                if (iv % 2 == 1)
                    Assert.IsTrue(gh.Def.get(iv));
                else
                    Assert.IsFalse(gh.Def.get(iv));
            }

            for (int iv = 0; iv < 16; iv++)
            {
                Assert.IsTrue(gh.Spd.get(iv));
            }

            for (int iv = 0; iv < 16; iv++)
            {
                if (iv % 2 == 1)
                    Assert.IsFalse(gh.Spc.get(iv));
                else
                    Assert.IsTrue(gh.Spc.get(iv));
            }


        }
    }
}