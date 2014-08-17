#region

using System.Collections.Generic;
using System.Runtime.Serialization;
using UNWomen.Common;

#endregion

namespace UNWomen.Prototype.Entities
{
    [DataContract]
    public class Actor : EntityBase
    {
        #region Instance Properties

        public virtual ICollection<MovieActorMapping> ActorMovies { get; set; }

        [DataMember]
        public int ActorId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string ImdbId { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        #endregion
    }
}