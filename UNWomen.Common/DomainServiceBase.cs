#region

using System.Data.Entity;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Common
{
    public abstract class DomainServiceBase<T>
        where T : DbContext, IDataContext, new()
    {
        #region Readonly & Static Fields

        private readonly T _dbContext;

        #endregion

        #region C'tors

        protected DomainServiceBase(T dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Instance Properties

        protected T DbContext
        {
            get { return _dbContext; }
        }

        #endregion

        #region Instance Methods

        protected void Save()
        {
            DbContext.Commit();
        }

        #endregion
    }
}