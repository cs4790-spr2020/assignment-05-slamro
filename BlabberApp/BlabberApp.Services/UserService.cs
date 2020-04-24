using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserAdapter _adapter;
        public UserService(UserAdapter adapter)
        {
            _adapter = adapter;
        }

        public void AddNewUser(string email)
        {
            try
            {
                _adapter.Add(CreateUser(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public User CreateUser(string email)
        {
            User tester = new User();
            tester.ChangeEmail(email);
            return tester;
        }

        public void RemoveUser(User user)
        {
            try
            {
                _adapter.Remove(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void RemoveAll()
        {
            try
            {
                _adapter.RemoveAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Update(User user)
        {
            try
            {
                _adapter.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public IEnumerable GetAll()
        {
            return _adapter.GetAll();
        }



        public User FindUser(string email)
        {
            try
            {
            return _adapter.GetByEmail(email);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public User FindUser(User user)
        {
            try{
            return _adapter.GetById(user.Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}