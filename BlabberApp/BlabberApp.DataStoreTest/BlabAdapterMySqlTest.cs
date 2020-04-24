using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness;

        [TestInitialize]
        public void Setup()
        {
            _harness = new BlabAdapter(new MySqlBlab());
            _harness.RemoveAll();
        }
        
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "fooabar@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void RemoveBlabTest()
        {
            Blab blab = new Blab("This is a test");
            _harness.Add(blab);
            var expected = _harness.GetById(blab.Id);
            _harness.Remove(blab);
            var actual = Assert.ThrowsException<BlabAdapterNotFoundException>(() => _harness.GetById(blab.Id));

            Assert.AreNotEqual(expected, actual.Message.ToString());

        }

        [TestMethod]
        public void UpdateBlabTest()
        {
            User testUser = new User("WarMachineRox@StarkExpo.FUN");
            string message1 = "You are all free... if you weren't already";
            string message2 = "Better clench up Legolas";
            Blab blab = new Blab(message1, testUser);
            _harness.Add(blab);
            blab.Message = message2;
            _harness.Update(blab);

            var expected = _harness.GetByUserMessage(blab);
            var actual = _harness.GetByUserMessage(blab);

            Assert.AreEqual(expected.Message, actual.Message);

        }

        [TestMethod]
        public void AddAndGetAllTest()
        {
            User testUser = new User("WarMachineRox@StarkExpo.FUN");
            string message1 = "You are all free... if you weren't already";
            Blab blab = new Blab(message1, testUser);
            _harness.Add(blab);

            ArrayList blabs = (ArrayList)_harness.GetAll();
            Blab actual = (Blab)blabs[0];

            Assert.AreEqual(blab.Id.ToString(), actual.Id.ToString());
        }

        [TestCleanup]
        public void TearDown()
        {
            _harness.RemoveAll();
        }
    }
}