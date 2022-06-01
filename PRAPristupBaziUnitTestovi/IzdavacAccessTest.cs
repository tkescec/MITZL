using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.IzdavacAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class IzdavacAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiIzdavaca()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiIzdavaca("TestNaziv1");

            Assert.IsNotNull(t);
        }
    }
}
