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
    public class PokemonTests
    {
        [TestMethod()]
        public void updateTest()
        {
            Pokemon pokemon = new Pokemon();

            pokemon.BaseStats = new Stats(50, 65, 64, 43, 44, 48);
            pokemon.IV = new Stats(15, 15, 15, 15, 15, 15);
            pokemon.update();
            
            Assert.AreEqual(pokemon.Stats.Atk, 13);
            Assert.AreEqual(pokemon.Stats.Def, 12);
            Assert.AreEqual(pokemon.Stats.Spd, 10);
            Assert.AreEqual(pokemon.Stats.SpAtk, 10);
            Assert.AreEqual(pokemon.Stats.SpDef, 11);

            Assert.AreEqual(pokemon.Level, 5);

            pokemon.ExpPoint += Enemy.getExpPoint(Enemy.Name.Chikorita);

            Assert.AreEqual(pokemon.Level, 5);


        }
    }
}