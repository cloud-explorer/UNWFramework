#region

using System.Data.Entity.ModelConfiguration;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.Data.Configuration
{
    public class ActorConfiguration : EntityTypeConfiguration<Actor>
    {
        #region C'tors

        public ActorConfiguration()
        {
            Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            Property(c => c.LastName).HasMaxLength(50).IsRequired();
            Property(c => c.MiddleName).HasMaxLength(50).IsOptional();
            Property(c => c.ImdbId).HasMaxLength(20).IsOptional();
        }

        #endregion
    }
}