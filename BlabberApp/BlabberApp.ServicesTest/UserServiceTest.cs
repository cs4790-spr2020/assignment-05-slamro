using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserServiceFactory _userServiceFactory = new UserServiceFactory();

        [TestMethod]
        public void TestCanary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmptyTest()
        {
            //Arrange
            UserService userService = _userServiceFactory.CreateUserService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = userService.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewUserSuccessTest()
        {
            //Arrange
            string email = "user@example.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            User actual = userService.FindUser(email);
            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
        }

        [TestMethod]
        public void AddNewUserSuccessTest01()
        {
            //Arrange
            string email = "Saka@SthrnWtrTrb.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            User actual = userService.FindUser(email);
            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
        }

        [TestMethod]
        public void AddNewUserFailTest01()
        {
            //Arrange
            string email = "Saka@SthrnWtrTrb.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User test = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            var expected = "Email already exists.";
            var ex = Assert.ThrowsException<Exception>(() => userService.AddNewUser(email));
            //Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void TestUserUpdate()
        {
            UserService userService = _userServiceFactory.CreateUserService();
            User test = userService.CreateUser("MyEmail@tester.com");
            userService.AddNewUser("MyEmail@tester.com");
            test.ChangeEmail("MyNewEmail@tester.com");
            userService.Update(test);

            User expected = userService.FindUser(test);            

            User actual = userService.FindUser("MyNewEmail@tester.com");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveUserTest()
        {
            string email = "NowYoureAllGonnaDie@covid19.com";
            UserService userService = _userServiceFactory.CreateUserService();
            User test = userService.CreateUser(email);
            userService.AddNewUser(email);
            var expected = "Not Found";

            userService.RemoveUser(test);
            var actual = Assert.ThrowsException<Exception>(() => userService.FindUser(test));
            Assert.AreNotEqual(expected, actual.Message.ToString());
        }

        [TestMethod]
        public void RemoveAllTest()
        {
            //var expected = " ";
            UserService userService = _userServiceFactory.CreateUserService();
            userService.RemoveAll();
            // var actual = Assert.ThrowsException<Exception>(() => userService.RemoveAll());
            // Assert.AreNotEqual(expected, actual.Message.ToString());
        }

        [TestMethod]
        public void FindUserFailTest()
        {
            string email = "NowYoureAllGonnaDie@covid19.com";
            UserService userService = _userServiceFactory.CreateUserService();
            var expected = "Not found";

            var ex = Assert.ThrowsException<Exception>(() => userService.FindUser(email));
            Assert.AreEqual(expected, ex.Message.ToString());
        }

        [TestMethod]
        public void ChangeEmailTestFail01()
        {
            //Arrange
            string email = "Saka@SthrnWtrTrb.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User test = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            var expected = "Email is invalid";
            var ex = Assert.ThrowsException<FormatException>(() => test.ChangeEmail(null));
            Assert.AreEqual(expected, ex.Message.ToString());
            
        }

        [TestMethod]
        public void ChangeEmailTestFail02()
        {
            //Arrange
            string email = "Saka@SthrnWtrTrb.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User test2 = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            var expected = "foobar.example is invalid";
            var ex = Assert.ThrowsException<FormatException>(() => test2.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
    }
}