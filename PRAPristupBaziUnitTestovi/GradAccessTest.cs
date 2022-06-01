using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.GradAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class GradAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiGrad()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiGrad("TestNaziv1");

            Assert.IsNotNull(t);
        }
    }
}
