using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestNewUserWithEmail()
        {
            string email = "foobar@example.com";
            User harness = new User(email);
            Assert.AreEqual(harness, harness);
        }
       
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");
            // Act
            string actual = harness.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail00()
        {
            // Arrange
            User harness = new User(); 
            var expected = "Foobar is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            // Arrange
            User harness = new User(); 
            var expected = "example.com is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail02()
        {
            // Arrange
            User harness = new User(); 
            var expected = "foobar.example is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail03()
        {
            // Arrange
            User harness = new User(); 
            var expected = "Email is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail(null));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail04()
        {
            // Arrange
            User harness = new User(); 
            var expected = "Email is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail(""));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
        
        [TestMethod]
        public void TestId()
        {
            // Arrange
            User harness = new User();
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            //Assert.AreEqual(true, harness.Id is Guid);
        }

        [TestMethod]
        public void TestSetGetRegisterDTTM()
        {
            User harness = new User();
            harness.RegisterDTTM = DateTime.Now;
            DateTime expected = harness.RegisterDTTM;

            // Act
            string actual = expected.ToString(); // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());

        }

        [TestMethod]
        public void TestSetGetLastLoginDTTM()
        {
            User harness = new User();
            harness.LastLoginDTTM = DateTime.Now;
            DateTime expected = harness.LastLoginDTTM;

            // Act
            string actual = expected.ToString(); // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [TestMethod]
        public void TestIsValid()
        {
            User harness = new User();
            harness.ChangeEmail("foobar@example.com");
            bool expected = true;
            bool actual = harness.IsValid();

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        public void TestIsValidFail00()
        {
            User harness = new User();
            bool expected = false;
            bool actual = harness.IsValid();

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [TestMethod]
        public void TestIsValidFailNullEmail()
        {
            // Arrange
            User harness = new User(); 
            //harness.ChangeEmail("foobar@test.com");
            var expected = "Value cannot be null.";
            // Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.IsValid());
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestIsValidFailBlankId()
        {
            // Arrange
            User harness = new User(); 
            Guid test = Guid.Empty;
            harness.Id = test;
            //harness.ChangeEmail("foobar@test.com");
            var expected = "Value cannot be null.";
            // Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.IsValid());
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

    }
}