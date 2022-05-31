using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class KnjigaAccessTest
    {
        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DohvatiSveKnjige()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSveKnjige();

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiSveKnjigePartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSveKnjige(20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiIzbrisaneKnjige()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiIzbrisaneKnjige();

            foreach (var knjiga in t)
            {
                Assert.IsNotNull(knjiga.DatumBrisanja);
            }
        }

        [TestMethod]
        public void TestDBOperation_DohvatiIzbrisaneKnjigePartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiIzbrisaneKnjige(20, 20);

            foreach (var knjiga in t)
            {
                Assert.IsNotNull(knjiga.DatumBrisanja);
            }
        }

        [TestMethod]
        public void TestDBOperation_DohvatiKnjigePoNaslovu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiKnjigePoNaslovu("Test");

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);

            var expected_naslovContains = "Test";
            foreach (var knjiga in t)
            {
                Assert.IsTrue(knjiga.Naslov.Contains(expected_naslovContains));
            }
        }

        [TestMethod]
        public void TestDBOperation_DohvatiKnjigePoNaslovuPartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiKnjigePoNaslovu("Test", 20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);

            var expected_naslovContains = "Test";
            foreach (var knjiga in t)
            {
                Assert.IsTrue(knjiga.Naslov.Contains(expected_naslovContains));
            }
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DodajKnjigu()
        {
            var db = DBConnectionPool.GetDBConnection();

            Knjiga k = new Knjiga();
            k.Naslov = "INSERTTEST_KNJIGA_NASLOV";
            k.Autor = new Autor();
            k.Autor.Ime = "INSERTTEST_AUTOR_IME";
            k.Izdavac = new Izdavac();
            k.Izdavac.Naziv = "INSERTTEST_IZDAVAC_NAZIV";
            k.StanjeKnjige = new StanjeKnjige();
            k.StanjeKnjige.Stanje = "INST_S";

            db.DodajKnjigu(k);


            var t = db.DohvatiKnjigePoNaslovu("INSERTTEST_KNJIGA_NASLOV");

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);

            var expected_knjigaNaziv = "INSERTTEST_KNJIGA_NASLOV";
            var actual_knjigaNaziv = t.ToList().FirstOrDefault().Naslov;
            Assert.AreEqual(expected_knjigaNaziv, actual_knjigaNaziv);

            var expected_autorIme = "INSERTTEST_AUTOR_IME";
            var actual_autorIme = t.ToList().FirstOrDefault().Autor.Ime;
            Assert.AreEqual(expected_autorIme, actual_autorIme);

            var expected_izdavacNaziv = "INSERTTEST_IZDAVAC_NAZIV";
            var actual_izdavacNaziv = t.ToList().FirstOrDefault().Izdavac.Naziv;
            Assert.AreEqual(expected_izdavacNaziv, actual_izdavacNaziv);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_AzurirajKnjigu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiSveKnjige();
            var k1 = t1.ToList().FirstOrDefault();

            k1.Naslov = "UPDATETEST_KNJIGA_NASLOV";
            db.AzurirajKnjigu(k1);

            var t2 = db.DohvatiKnjigePoNaslovu("UPDATETEST_KNJIGA_NASLOV");
            var k2 = t2.ToList().FirstOrDefault();

            var expected_knjigaNaziv = "UPDATETEST_KNJIGA_NASLOV";
            var actual_knjigaNaziv = k2.Naslov;
            Assert.AreEqual(expected_knjigaNaziv, actual_knjigaNaziv);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_IzbrisiKnjigu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiSveKnjige();
            var k1 = t1.ToList().FirstOrDefault();

            db.IzbrisiKnjigu(k1);

            var t2 = db.DohvatiSveKnjige();
            var k2 = t2.ToList().FirstOrDefault();

            Assert.IsNotNull(k2.DatumBrisanja);
        }

        [TestMethod]
        public void TestDBOperation_PovratiKnjigu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiSveKnjige();
            var k1 = t1.ToList().FirstOrDefault();

            db.PovratiKnjigu(k1);

            var t2 = db.DohvatiSveKnjige();
            var k2 = t2.ToList().FirstOrDefault();

            Assert.IsNull(k2.DatumBrisanja);
        }

        /***************************************************************************************************************************************************************/
    }
}