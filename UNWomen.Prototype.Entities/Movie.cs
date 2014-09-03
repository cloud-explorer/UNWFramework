#region

using System.Collections.Generic;
using System.Runtime.Serialization;
using UNWomen.Common;

#endregion

namespace UNWomen.Prototype.Entities
{
    [DataContract]
    public class Movie : EntityBase
    {
        #region Instance Properties
        [IgnoreDataMember]
        public virtual IEnumerable<MovieActorMapping> MovieActors { get; set; }

        [DataMember]
        public string ImdbId { get; set; }

        [DataMember]
        public int MovieId { get; set; }

        [DataMember]
        public int ReleaseYear { get; set; }

        [DataMember]
        public string Title { get; set; }

        #endregion
    }
}