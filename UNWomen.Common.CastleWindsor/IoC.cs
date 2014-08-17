#region

using System;
using System.Collections;
using Castle.Windsor;

#endregion

namespace UNWomen.Common.CastleWindsor
{
    /// <summary>
    ///     Class IoC. This class cannot be inherited.
    /// </summary>
    public sealed class IoC
    {
        #region Class Properties

        /// <summary>
        ///     Gets the container.
        /// </summary>
        /// <value>The container.</value>
        /// <exception cref="System.InvalidOperationException">
        ///     The container has not been initialized! Please call
        ///     IoC.Initialize(container) before using it.
        /// </exception>
        public static IWindsorContainer Container
        {
            get
            {
                if (GlobalContainer == null)
                    throw new InvalidOperationException(
                        "The container has not been initialized! Please call IoC.Initialize(container) before using it.");
                return GlobalContainer;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
        public static bool IsInitialized
        {
            get { return GlobalContainer != null; }
        }

        /// <summary>
        ///     Gets or sets the global container.
        /// </summary>
        /// <value>The global container.</value>
        internal static IWindsorContainer GlobalContainer { get; set; }

        #endregion

        #region Class Methods

        /// <summary>
        ///     Initializes the specified windsor container.
        /// </summary>
        /// <param name="windsorContainer">The windsor container.</param>
        public static void Initialize(IWindsorContainer windsorContainer)
        {
            GlobalContainer = windsorContainer;
        }

        /// <summary>
        ///     Resets the specified container.
        /// </summary>
        /// <param name="containerToReset">The container to reset.</param>
        public static void Reset(IWindsorContainer containerToReset)
        {
            if (containerToReset == null)
                return;
            if (ReferenceEquals(GlobalContainer, containerToReset))
            {
                GlobalContainer = null;
            }
        }

        /// <summary>
        ///     Resets this instance.
        /// </summary>
        public static void Reset()
        {
            Reset(GlobalContainer);
        }

        /// <summary>
        ///     Resolves the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>System.Object.</returns>
        public static object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        /// <summary>
        ///     Resolves the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>System.Object.</returns>
        public static object Resolve(Type serviceType, string serviceName)
        {
            return Container.Resolve(serviceName, serviceType);
        }

        /// <summary>
        ///     Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        ///     Resolves the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public static T Resolve<T>(string name)
        {
            return Container.Resolve<T>(name);
        }

        /// <summary>
        ///     Resolves the specified arguments as anonymous type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentsAsAnonymousType">Type of the arguments as anonymous.</param>
        /// <returns>T.</returns>
        public static T Resolve<T>(object argumentsAsAnonymousType)
        {
            return Container.Resolve<T>(argumentsAsAnonymousType);
        }


        /// <summary>
        ///     Resolves the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>T.</returns>
        public static T Resolve<T>(IDictionary parameters)
        {
            return Container.Resolve<T>(parameters);
        }

        /// <summary>
        ///     Resolves all services by type.
        /// </summary>
        /// <param name="service">The service to resolve.</param>
        /// <returns>Array.</returns>
        public static Array ResolveAll(Type service)
        {
            return Container.ResolveAll(service);
        }

        /// <summary>
        ///     Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T[].</returns>
        public static T[] ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }

        /// <summary>
        ///     Tries to resolve the component, but return null
        ///     instead of throwing if it is not there.
        ///     Useful for optional dependencies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TryResolve<T>()
        {
            return TryResolve(default(T));
        }

        /// <summary>
        ///     Tries to resolve the compoennt, but return the default
        ///     value if could not find it, instead of throwing.
        ///     Useful for optional dependencies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static T TryResolve<T>(T defaultValue)
        {
            if (Container.Kernel.HasComponent(typeof (T)) == false)
                return defaultValue;
            return Container.Resolve<T>();
        }

        #endregion
    }
}