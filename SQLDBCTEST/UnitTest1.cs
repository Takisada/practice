using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary5;


namespace SQLDBCTEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            int expected = 1;
            int actual = Class1.Login(1, "Soqleg5", "Mark020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoginTest2()
        {
            int expected = 1;
            int actual = Class1.Login(2, "1011", "");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoginTest_WrongType()
        {
            Assert.ThrowsException<Exception>(() => Class1.Login(100, "Soqleg5", "Mark020"));
        }
        [TestMethod]
        public void LoginTest_WrongLogin() 
        {
            int expected = 2;
            int actual = Class1.Login(2, "Login", "Mark020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QueryExecutor()
        {
            int expected = 1;
            int actual = Class1.SQLcommand("SELECT * FROM DRIVERS;");
            Assert.AreEqual(expected, actual);
        }
    }
}
