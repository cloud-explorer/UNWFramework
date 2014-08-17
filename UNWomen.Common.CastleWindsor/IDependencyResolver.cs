#region

using System.Collections.Generic;

#endregion

namespace UNWomen.Common.CastleWindsor
{
    /// <summary>
    ///     Interface IDependencyResolver
    /// </summary>
    public interface IDependencyResolver
    {
        #region Instance Methods

        /// <summary>
        ///     Resolves the specified args.
        /// </summary>
        /// <typeparam name="T" />
        /// <param name="args">The args.</param>
        /// <returns>
        ///     ``0.
        /// </returns>
        T Resolve<T>(IDictionary<string, object> args = null);

        /// <summary>
        ///     Resolves all.
        /// </summary>
        /// <typeparam name="T" />
        /// <returns>
        ///     IEnumerable{``0}.
        /// </returns>
        IEnumerable<T> ResolveAll<T>();

        #endregion
    }
}