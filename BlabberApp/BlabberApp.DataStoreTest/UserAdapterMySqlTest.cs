using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        private User _user;
        private UserAdapter _harness;
        private readonly string _email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            _user = new User(_email);
            _harness = new UserAdapter(new MySqlUser());
            _harness.RemoveAll();
        }
        
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            User actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddUserExists()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            var expected = "Email already exists.";
            var ex = Assert.ThrowsException<UserAdapterDuplicateException>(() => _harness.Add(_user));
            
            //Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void RemoveUserTest()
        {
            _harness.Add(_user);
            var expected = _harness.GetById(_user.Id);
            _harness.Remove(_user);
            var actual = Assert.ThrowsException<UserAdapterNotFoundException>(() => _harness.GetById(_user.Id));

            Assert.AreNotEqual(expected, actual.Message.ToString());
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UserAdapter harness = new UserAdapter(new MySqlUser());
            
            User test = new User("TestEmail@tester.com");
            harness.Add(test);
            string email = "TesterEmail@tester.com";
            test.ChangeEmail(email);
            harness.Update(test);

            User expected = harness.GetByEmail("TesterEmail@tester.com");
            User actual = harness.GetById(test.Id);
            //var actual = Assert.ThrowsException<UserAdapterNotFoundException>(() => _harness.Remove(_user));

            Assert.AreEqual(expected.Email, actual.Email);
        }

        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            //Act
            ArrayList users = (ArrayList)_harness.GetAll();
            User actual = (User)users[0];
            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }

        [TestCleanup]
        public void TearDown()
        {
            //User user = new User(_email);
            _harness.RemoveAll();
        }
    }
}