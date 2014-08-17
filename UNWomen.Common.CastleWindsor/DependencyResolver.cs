#region

using System.Collections;
using System.Collections.Generic;
using Castle.Windsor;

#endregion

namespace UNWomen.Common.CastleWindsor
{
    /// <summary>
    ///     Class DependencyResolver
    /// </summary>
    public class DependencyResolver : IDependencyResolver
    {
        #region C'tors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DependencyResolver" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public DependencyResolver(IWindsorContainer container)
        {
            Container = container;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        ///     Gets the container.
        /// </summary>
        /// <value>The container.</value>
        public IWindsorContainer Container { get; private set; }

        #endregion

        #region IDependencyResolver Members

        /// <summary>
        ///     Resolves the specified args.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The args.</param>
        /// <returns>``0.</returns>
        public T Resolve<T>(IDictionary<string, object> args = null)
        {
            if (args == null)
                return Container.Resolve<T>();


            return Container.Resolve<T>((IDictionary) args);
        }

        /// <summary>
        ///     Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable{``0}.</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }

        #endregion

        #region Class Methods

        /// <summary>
        ///     Creates the standard resolver.
        /// </summary>
        /// <returns>IDependencyResolver.</returns>
        public static DependencyResolver CreateStandardResolver()
        {
            IWindsorContainer container = new WindsorContainer();
            return new DependencyResolver(container);
        }

        #endregion
    }
}