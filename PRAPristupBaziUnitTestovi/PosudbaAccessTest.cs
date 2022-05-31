using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.ZakasninaPoDanuAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class PosudbaAccessTest
    {
        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DohvatiSvePosudbe()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSvePosudbe();

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiSvePosudbePartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSvePosudbe(20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiSvePosudbePoKorisniku()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(25);
            var t = db.DohvatiSvePosudbePoKorisniku(korisnik);

            Assert.IsNotNull(t);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DodajPosudbu()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(25);
            Knjiga knjiga = db.DohvatiKnjigePoNaslovu("25").FirstOrDefault();
            ZakasninaPoDanu zakasninaPoDanu = db.DohvatiZakasninuPoDanu(1);

            Posudba posudba = new Posudba();
            posudba.Korisnik = korisnik;
            posudba.Knjiga = knjiga;
            posudba.ZakasninaPoDanu = zakasninaPoDanu;
            db.DodajPosudbu(posudba);

            var t = db.DohvatiSvePosudbePoKorisniku(korisnik);
            var p = t.Where(x => x.Knjiga.Naslov == knjiga.Naslov && x.ZakasninaPoDanu.Zakasnina == zakasninaPoDanu.Zakasnina);
            Assert.IsNotNull(p);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_AzurirajPosudbu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiSvePosudbe().FirstOrDefault();
            t1.Kupljeno = true;
            db.AzurirajPosudbu(t1);

            var t2 = db.DohvatiSvePosudbe().FirstOrDefault();
            Assert.IsTrue(t2.Kupljeno);
        }

        /***************************************************************************************************************************************************************/
    }
}
