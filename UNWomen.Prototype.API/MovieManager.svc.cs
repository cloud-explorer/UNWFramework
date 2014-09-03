#region

using System.Collections.Generic;
using UNWomen.Prototype.Contracts.DomainServices;
using UNWomen.Prototype.Contracts.Managers;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.API
{
    public class MovieManager : ManagerBase, IMovieManager
    {
        #region Readonly & Static Fields

        private readonly IMovieService _movieService;

        #endregion

        #region C'tors

        public MovieManager(IMovieService movieService)
        {
            _movieService = movieService;
        }

        #endregion

        #region IMovieManager Members

        public Movie GetMovie(int movieId)
        {
            return ExecuteFaultHandledOperation(
                () => _movieService.GetMovie(movieId)
                );

            //return ExecuteFaultHandledOperation(
            //    () =>
            //    {
            //        Movie movie = _movieService.GetMovie(movieId);
            //        return new Movie
            //        {
            //            Title = movie.Title,
            //            MovieId = movie.MovieId,
            //            ImdbId = movie.ImdbId
            //        };
            //    }
            //    );
        }

        public void AddMovie(Movie movie)
        {
            ExecuteFaultHandledOperation(
                () => _movieService.CreateMovie(movie)
                );
        }

        public IEnumerable<Actor> GetActorsForMovie(Movie movie)
        {
            return ExecuteFaultHandledOperation(
                () => _movieService.GetActorsForMovie(movie)
                );
        }

        #endregion
    }
}