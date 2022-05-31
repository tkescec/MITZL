using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.Exceptions;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class KorisnikAccessTest
    {
        /***************************************************************************************************************************************************************/
        [TestMethod]
        public void TestDBOperation_DohvatiSveKorisnike()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSveKorisnike();

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiSveKorisnikePartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiSveKorisnike(20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiJednogKorisnika()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiJednogKorisnika(1);

            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestDBOperation_AutentificirajKorisnika()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.AutentificirajKorisnika("TestEmail1", "lozinka");

            Assert.IsNotNull(t);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DodajKorisnika_Success()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = new Korisnik();
            korisnik.Lozinka = "lozinka";
            korisnik.Osoba = new Osoba();
            korisnik.Osoba.Email = "TestKorisnikInsertMail";

            try
            {
                db.DodajKorisnika(korisnik);
            }
            catch (System.Exception)
            {
            }

            var t = db.AutentificirajKorisnika("TestKorisnikInsertMail", "lozinka");

            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestDBOperation_DodajKorisnika_Fail()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = new Korisnik();
            korisnik.Lozinka = "lozinka";
            korisnik.Osoba = new Osoba();
            korisnik.Osoba.Email = "TestEmail10";

            bool exc = false;
            try
            {
                db.DodajKorisnika(korisnik);
            }
            catch (KorisnikCreateException)
            {
                exc = true;
            }
            
            Assert.IsTrue(exc);
        }

        /***************************************************************************************************************************************************************/

        
        [TestMethod]
        public void TestDBOperation_AzurirajKorisnika_PasswordChanged()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(5);
            korisnik.Lozinka = "lozinka2";
            db.AzurirajKorisnika(korisnik, true);

            var t = db.AutentificirajKorisnika("TestEmail5", "lozinka2");
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestDBOperation_AzurirajKorisnika_PasswordUnchanged()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(10);
            korisnik.Aktiviran = true;
            korisnik.Osoba.Adresa = "UpdatedUserAddress";
            db.AzurirajKorisnika(korisnik, false);

            var t = db.DohvatiJednogKorisnika(10);
            var expected_Aktiviran = true;
            var expected_OsobaAdresa = "UpdatedUserAddress";
            Assert.AreEqual(expected_Aktiviran, t.Aktiviran);
            Assert.AreEqual(expected_OsobaAdresa, t.Osoba.Adresa);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_IzbrisiKorisnika()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(15);
            db.IzbrisiKorisnika(korisnik);

            bool exc = false;
            try
            {
                var t = db.AutentificirajKorisnika("TestEmail15", "lozinka");
            }
            catch (System.InvalidOperationException)
            {
                exc = true;
            }

            Assert.IsTrue(exc);
        }

        /***************************************************************************************************************************************************************/
    }
}
