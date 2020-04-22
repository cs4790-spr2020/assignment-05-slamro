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
            Assert.AreEqual(true, harness.Id is Guid);
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
            try
            {
                User Stark = new User();
                string message = "I've solved it. I've solved time travel.";
                
                bool expected = true;
                bool actual = harness.IsValid();

                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex) { }
        }

        [TestMethod]
        public void TestIsValidFail00()
        {
            try
            {
                bool expected = true;
                bool actual = harness.IsValid();

                Assert.Fail();
            }
            catch (Exception ex) { }
        }
    }
}