using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Exceptions
{
    public class UserAdapterNotFoundException :Exception
    {
        public UserAdapterNotFoundException(string message) :base(message)
        {

        }
        public UserAdapterNotFoundException(string message, Exception inner) :base(message, inner)
        {

        }


    }