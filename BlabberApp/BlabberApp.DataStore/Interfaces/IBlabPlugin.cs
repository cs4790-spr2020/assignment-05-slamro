using System.Collections;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Interfaces
{
    public interface IBlabPlugin : IPlugin
    {
        IEnumerable ReadByUserId(string Id);
        IEntity ReadByUserIdMessage(IEntity obj);
    }
}