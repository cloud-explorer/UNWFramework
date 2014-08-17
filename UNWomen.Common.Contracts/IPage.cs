namespace UNWomen.Common.Contracts
{
    public interface IPage
    {
        #region Instance Properties

        int PageNumber { get; set; }
        int PageSize { get; set; }
        int Skip { get; }

        #endregion
    }
}