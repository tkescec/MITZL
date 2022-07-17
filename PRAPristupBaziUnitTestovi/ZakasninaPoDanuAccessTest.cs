using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.ZakasninaPoDanuAccess;


namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class ZakasninaPoDanuAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiZakasninuPoDanu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiZakasninuPoDanu(1);

            Assert.IsNotNull(t);
        }
    }
}
