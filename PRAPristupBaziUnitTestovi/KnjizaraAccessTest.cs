using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjizaraAccess;
using PRAPristupBazi.Exceptions;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class KnjizaraAccessTest
    {
        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DohvatiPodatkeOKnjizari()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiPodatkeOKnjizari();

            Assert.IsNotNull(t);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_DodajPodatkeOKnjizari()
        {
            var db = DBConnectionPool.GetDBConnection();

            Knjizara knjizara = new Knjizara();

            bool exc = false;
            try
            {
                db.DodajPodatkeOKnjizari(knjizara);
            }
            catch (KnjizaraCreateException)
            {
                exc = true;
            }

            Assert.IsTrue(exc);
        }

        /***************************************************************************************************************************************************************/

        [TestMethod]
        public void TestDBOperation_AzurirajPodatkeOKnjizari()
        {
            var db = DBConnectionPool.GetDBConnection();

            Knjizara knjizara = db.DohvatiPodatkeOKnjizari();
            knjizara.Naziv = "TestKnizaraUpdate";
            db.AzurirajPodatkeOKnjizari(knjizara);

            var t = db.DohvatiPodatkeOKnjizari().Naziv;
            var expected_naziv = "TestKnizaraUpdate";
            Assert.AreEqual(t, expected_naziv);
        }

        /***************************************************************************************************************************************************************/
    }
}
