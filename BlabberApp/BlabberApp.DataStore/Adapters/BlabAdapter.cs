using System;
using System.Collections;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class BlabAdapter
    {
        private IBlabPlugin plugin;

        public BlabAdapter(IBlabPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void Add(Blab blab)
        {
            try
            {
                plugin.Create(blab);
                return;
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.Message.ToString());
            }
        }

        public void Remove(Blab blab)
        {
            try
            {
                plugin.Delete(blab);
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.Message.ToString());
            }
        }
        public void RemoveAll()
        {
            plugin.DeleteAll();
        }

        public void Update(Blab blab)
        {
            try
            {
                plugin.Update(blab);
                return;
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.Message.ToString());
            }
        }

        public IEnumerable GetAll()
        {
            try
            {
                return plugin.ReadAll();
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.ToString());
            }
        }

        public Blab GetById(Guid Id)
        {
            try
            {
                Blab blab = (Blab)plugin.ReadById(Id);
                return blab;
            }
            catch (Exception ex)
            {
                throw new BlabAdapterNotFoundException(ex.Message.ToString());
            }
        }
        public IEnumerable GetByUserId(string Id)
        {
            try
            {
                return plugin.ReadByUserId(Id);
            }
            catch (Exception ex)
            {
                throw new UserAdapterNotFoundException(ex.Message.ToString());
            }
        }
        public Blab GetByUserMessage(Blab blab)
        {
            try
            {
                Blab test = (Blab)plugin.ReadByUserIdMessage(blab);
                return test;
            }
            catch (Exception ex)
            {
                throw new UserAdapterNotFoundException(ex.Message.ToString());
            }
        }
    }
}