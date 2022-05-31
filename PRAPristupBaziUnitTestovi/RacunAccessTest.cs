using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.RacunAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using System.Collections.Generic;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class RacunAccessTest
    {
        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DohvatiSveRacunePoKorisniku()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.Korisniks.Where(x => x.Racuns.Count() != 0).FirstOrDefault();
            var t = db.DohvatiSveRacunePoKorisniku(korisnik);

            Assert.IsNotNull(t);
            Assert.IsTrue(t.Count() > 0);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DodajRacun()
        {
            var db = DBConnectionPool.GetDBConnection();

            Korisnik korisnik = db.DohvatiJednogKorisnika(35);
            Racun racun = new Racun();
            racun.Korisnik = korisnik;
            IEnumerable<Knjiga> knjige = db.DohvatiSveKnjige();
            racun.Stavkas = new List<Stavka>();
            racun.Stavkas.Add(new Stavka { Knjiga = knjige.ElementAt(21) });
            racun.Stavkas.Add(new Stavka { Knjiga = knjige.ElementAt(22) });

            db.DodajRacun(racun);

            var t = db.DohvatiSveRacunePoKorisniku(korisnik);
            var r = t.Contains(racun);

            Assert.IsTrue(r);
        }

        /***************************************************************************************************************************************************************/
    }
}
