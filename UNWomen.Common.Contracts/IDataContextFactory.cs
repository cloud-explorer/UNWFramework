#region

using System;
using System.Data.Entity;

#endregion

namespace UNWomen.Common.Contracts
{
    public interface IDataContextFactory<T> : IDisposable
        where T : DbContext, IDataContext, new()
    {
        #region Instance Methods

        T GetDataContext();

        #endregion
    }
}