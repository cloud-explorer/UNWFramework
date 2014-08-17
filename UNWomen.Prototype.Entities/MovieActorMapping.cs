#region

using UNWomen.Common;

#endregion

namespace UNWomen.Prototype.Entities
{
    public class MovieActorMapping : EntityBase
    {
        #region Instance Properties

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
        public int ActorId { get; set; }
        public int MovieActorMappingID { get; set; }
        public int MovieId { get; set; }

        #endregion
    }
}