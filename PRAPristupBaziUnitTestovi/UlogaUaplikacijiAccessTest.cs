using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.UlogaUaplikacijiAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class UlogaUaplikacijiAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiUloguUAplikaciji()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiUloguUAplikaciji("Klijent");
            var t2 = db.DohvatiUloguUAplikaciji("Zaposlenik");

            Assert.IsNotNull(t1);
            Assert.IsNotNull(t2);
        }
    }
}
