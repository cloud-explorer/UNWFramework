#region

using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using UNWomen.Common.CastleWindsor;
using UNWomen.Prototype.API;
using WebActivatorEx;

#endregion

[assembly: PostApplicationStartMethod(typeof (CastleWindsorBootstrapper), "Start")]

namespace UNWomen.Prototype.API
{
    public static class CastleWindsorBootstrapper
    {
        #region Class Methods

        public static void Start()
        {
            //create the resolver
            var resolver = DependencyResolver.CreateStandardResolver();
            IWindsorContainer container = resolver.Container;
            List<IWindsorInstaller> installers = new List<IWindsorInstaller>
            {
                //TODO: Write installer
                new ServerComponentsInstaller()
            };

            IWindsorContainer windsorContainer = container.Install(installers.ToArray());
            if (IoC.IsInitialized) IoC.Reset();
            IoC.Initialize(windsorContainer);
        }

        #endregion
    }
}