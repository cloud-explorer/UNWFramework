#region

using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Runtime.Serialization;
using UNWomen.Common.Contracts;
using UNWomen.Prototype.Data.Configuration;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.Data
{
    public interface IPrototypeContext : IDataContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<MovieActorMapping> MovieActorMappings { get; set; }
        DbSet<Movie> Movies { get; set; }
    }

    public class PrototypeContext : DbContext, IPrototypeContext
    {
        #region C'tors

        public PrototypeContext()
            : base("name=PrototypeContext")
        {
            Database.SetInitializer<PrototypeContext>(null);
        }

        #endregion

        #region Instance Properties

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<MovieActorMapping> MovieActorMappings { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        #endregion

        #region Instance Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();

            modelBuilder.Configurations.Add(new ActorConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
        }

        #endregion

        #region IDataContext Members

        public virtual void Commit()
        {
            SaveChanges();
        }

        #endregion
    }
}