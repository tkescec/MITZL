using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.OsobaAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class OsobaAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiOsobu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiOsobu("TestEmail20");

            Assert.IsNotNull(t);
        }
    }
}
