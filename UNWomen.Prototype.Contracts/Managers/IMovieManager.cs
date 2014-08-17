#region

using System.Collections.Generic;
using System.ServiceModel;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.Contracts.Managers
{
    [ServiceContract]
    public interface IMovieManager
    {
        #region Instance Methods

        [OperationContract]
        void AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int movieId);

        [OperationContract]
        IEnumerable<Actor> GetActorsForMovie(Movie movie);

        #endregion
    }
}