using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.DrzavaAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class DrzavaAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiDrzavu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiDrzavu("TestNaziv1");

            Assert.IsNotNull(t);
        }
    }
}
