using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StanjeKnjigeAccess;


namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class StanjeKnjigeAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiStanjeKnjige()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t1 = db.DohvatiStanjeKnjige("Nova");
            var t2 = db.DohvatiStanjeKnjige("Rabljena");

            Assert.IsNotNull(t1);
            Assert.IsNotNull(t2);
        }
    }
}
