namespace UNWomen.Common.Contracts
{
    public interface IDomainServiceFactory
    {
        #region Instance Methods

        T GetService<T>() where T : IDomainServiceContract;

        #endregion
    }
}