#region

using System.Data.Entity;
using UNWomen.Common.CastleWindsor;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Common
{
    public class DataContextFactory<T> : Disposable, IDataContextFactory<T>
        where T : DbContext, IDataContext, new()
    {
        #region Fields

        private T _dataContext;

        #endregion

        #region Instance Methods

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }

        #endregion

        #region IDataContextFactory<T> Members

        /// <summary>
        ///     Gets or resolves the database.
        /// </summary>
        /// <returns>T.</returns>
        public T GetDataContext()
        {
            return _dataContext ?? (_dataContext = IoC.Resolve<T>());
        }

        #endregion
    }
}