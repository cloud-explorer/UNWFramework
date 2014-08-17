#region

using System.Linq;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Common
{
    public class Page
    {
        #region C'tors

        public Page()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public Page(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        #endregion

        #region Instance Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Skip
        {
            get { return (PageNumber - 1)*PageSize; }
        }

        #endregion
    }

    public static class PagingExtensions
    {
        #region Class Methods

        /// <summary>
        ///     Extend IQueryable to simplify access to skip and take methods
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <returns>IQueryable with Skip and Take having been performed</returns>
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, IPage page)
        {
            return queryable.Skip(page.Skip).Take(page.PageSize);
        }

        #endregion
    }
}