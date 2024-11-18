using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pasjans;

namespace TestPasjans1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKonstruktorKarta()
        {
            Kolor kl = Kolor.Clubs;
            Rank rk = Rank.n2;

            Karta kt = new Karta(kl, rk);

            Kolor kl_a = kt.Kolor;
            Rank rk_a = kt.Rank;

            Assert.AreEqual(kl_a, kl, "Niezgodny kolor");
            Assert.AreEqual(rk_a, rk, "Niezgodne starszeństwo");
        }
        [TestMethod]
        public void TestToString()
        {
            Kolor kl = Kolor.Clubs;
            Rank rk = Rank.n2;

            Karta kt = new Karta(kl, rk);

            string nieodkryta = "##";
            string odkryta = "♣2";

            Assert.AreEqual(nieodkryta, kt.ToString(), "Błąd przy zakrytej karcie");
            kt.Odkryj();
            Assert.AreEqual(odkryta, kt.ToString(), "Błąd przy odkrytej karcie");
        }
        [TestMethod]
        public void TestBarwa()
        {
            Kolor kb = Kolor.Clubs;
            Kolor kr = Kolor.Diamonds;
            Rank rk = Rank.n2;

            Karta ktb = new Karta(kb, rk);
            Karta ktr = new Karta(kr, rk);


            Assert.AreEqual(true, ktb.Barwa(), "Błąd przy czarnej karcie");
            Assert.AreEqual(false, ktr.Barwa(), "Błąd przy czerwonej karcie");
        }
    }
}
