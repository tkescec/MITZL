using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PRAPristupBazi.Models;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess;

namespace PRAPristupBaziUnitTestovi
{
    [TestClass]
    public class AutorAccessTest
    {
        [TestMethod]
        public void TestDBOperation_DohvatiAutora()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutora("TestIme1", "TestPrezime1");

            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiAutorePoImenu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutorePoImenu("Test");

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiAutorePoImenuPartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutorePoImenu("Test", 20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiAutorePoPrezimenu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutorePoPrezimenu("Test");

            Assert.IsNotNull(t);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiAutorePoPrezimenuPartial()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutorePoPrezimenu("Test", 20, 20);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount == 20);
        }

        [TestMethod]
        public void TestDBOperation_DohvatiAutorePoImenuIPrezimenu()
        {
            var db = DBConnectionPool.GetDBConnection();

            var t = db.DohvatiAutorePoImenuIPrezimenu("TestIme", "TestPrezime");

            Assert.IsNotNull(t);

            var actual_elementCount = t.Count();
            Assert.IsTrue(actual_elementCount > 0);
        }
    }
}
