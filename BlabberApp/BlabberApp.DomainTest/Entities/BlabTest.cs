using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {
        private Blab harness;
        private string _message = "Join me on the dark side and we will rule this galaxy as Father and Son.";

        public BlabTest()
        {
            harness = new Blab();
        }

        [TestMethod]
        public void TestNewBlabWithMessage()
        {
            Blab expected = new Blab(_message);

            Blab actual = expected;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestNewBlabWithUser()
        {
            User Bob = new User();
            Blab expected = new Blab(Bob);

            Blab actual = expected;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestNewBlabWithMessageAndUser()
        {
            User Stark = new User();
            string message = "I've solved it. I've solved time travel.";
            Blab expected = new Blab(message, Stark);

            Blab actual = expected;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            
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

        [TestMethod]
        public void TestUserGetSet()
        {
            User Shannara = new User();
            User expected = Shannara;

            harness.User = Shannara;
            User actual = harness.User;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestIsValid()
        {
            Blab harness = new Blab();
            bool expected = true;
            bool actual = harness.IsValid();

            Assert.AreEqual(actual.ToString(), expected.ToString());
            
        }

        [TestMethod]
        public void TestIsValidFail00()
        {
            User test = new User();
            Blab Stark = new Blab(test);
            Stark.Id = Guid.Empty;
            var expected = "Value cannot be null.";
            
            var actual = Assert.ThrowsException<ArgumentNullException>(() => Stark.IsValid());

            Assert.AreEqual(expected, actual.Message.ToString());
        }
        [TestMethod]
        public void TestIsValidFailNullMessage()
        {
            // Arrange
            Blab harness = new Blab(); 
            harness.Message = null;
            var expected = "Value cannot be null.";
            // Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.IsValid());
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
    }
}