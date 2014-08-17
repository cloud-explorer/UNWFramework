#region

using System.Data.Entity.ModelConfiguration;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.Data.Configuration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        #region C'tors

        public MovieConfiguration()
        {
            Property(c => c.Title).HasMaxLength(250).IsRequired();
            Property(c => c.ReleaseYear).IsRequired();
            Property(c => c.ImdbId).HasMaxLength(20).IsOptional();
        }

        #endregion
    }
}