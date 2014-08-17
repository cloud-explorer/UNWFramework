#region

using UNWomen.Common.CastleWindsor;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Common
{
    public class DomainServiceFactory : IDomainServiceFactory
    {
        #region IDomainServiceFactory Members

        public T GetService<T>() where T : IDomainServiceContract
        {
            return IoC.Resolve<T>();
        }

        #endregion
    }
}