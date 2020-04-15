using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            Blab harness = new Blab(); 
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."; 
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetUserID()
        {
            // Arrange
            Blab harness = new Blab(); 
            string expected = "foobar@example.com";
            harness.UserID = "foobar@example.com";
            // Act
            string actual = harness.UserID;
            // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [TestMethod]
        public void TestGetSysId()
        {
            // Arrange
            Blab harness = new Blab();
            string expected = harness.getSysId();
            // Act
            string actual = harness.getSysId();
            // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, harness.getSysId() is string);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}