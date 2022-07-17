using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StavkaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class StavkaAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiSveStavkeRacunaPoKorisniku()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(38);
            var t = db.DohvatiSveStavkeRacunaPoKorisniku(korisnik);

            Assert.IsNotNull(t);
        }
    }
}
