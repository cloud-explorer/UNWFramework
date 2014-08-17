#region

using System;
using System.Data.Entity;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UNWomen.Common;
using UNWomen.Common.Contracts;
using UNWomen.Prototype.Contracts.DomainServices;
using UNWomen.Prototype.Contracts.Managers;
using UNWomen.Prototype.Data;
using UNWomen.Prototype.DomainServices;

#endregion

namespace UNWomen.Prototype.API
{
    public class ServerComponentsInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero)
                .Register(
                    Component.For<PrototypeContext>()
                        .ImplementedBy<PrototypeContext>()
                        .LifestylePerWebRequest(),
                    Component.For<IMovieManager>()
                        .ImplementedBy<MovieManager>()
                        .LifestyleTransient(),
                    Component.For<IMovieService>()
                        .ImplementedBy<MovieService>()
                        .LifestyleTransient(),
                    Component.For(typeof (IDataContextFactory<>))
                        .ImplementedBy(typeof (DataContextFactory<>))
                        .LifestylePerWebRequest(),
                    Component.For(typeof (IDbSet<>))
                        .ImplementedBy(typeof (DbSet))
                        .LifestyleTransient()
                );
        }

        #endregion
    }
}