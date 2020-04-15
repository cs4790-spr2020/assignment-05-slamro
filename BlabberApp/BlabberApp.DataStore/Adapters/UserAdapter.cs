using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class UserAdapter
    {
        private IUserPlugin plugin;

        public UserAdapter(IUserPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void Add(User user)
        {
            User existingUser = GetByEmail(user.Email.ToString());
            if (existingUser != null)
            {
                throw new NullReferenceException(": UserAdapter: Email already tied to another user");
            }
            try
            {
                this.plugin.Create(user);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.ToString() + ": UserAdapter: Email already tied to another user");
            }

        }

        public void Remove(User user)
        {
            try
            {
                this.plugin.Delete(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public void Update(User user)
        {
            try
            {
                this.plugin.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable GetAll()
        {
            try
            {
                return this.plugin.ReadAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public User GetById(Guid Id)
        {
            try
            {
                User user = (User)this.plugin.ReadById(Id);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public User GetByEmail(string email)
        {
            try
            {
                User user = (User)this.plugin.ReadByUserEmail(email);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}