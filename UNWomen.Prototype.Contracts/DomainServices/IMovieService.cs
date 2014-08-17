#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UNWomen.Common.Contracts;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.Contracts.DomainServices
{
    public interface IMovieService : IDomainServiceContract
    {
        #region Instance Methods

        void CreateMovie(Movie movie);
        void DeleteMovie(Expression<Func<Movie, bool>> where);
        void DeleteMovie(Movie movie);
        IEnumerable<Actor> GetActorsForMovie(Movie movie);
        Movie GetMovie(int movieId);
        IEnumerable<Movie> GetMovies();
        IEnumerable<Movie> GetMovies(Expression<Func<Movie, bool>> where);
        IEnumerable<Movie> GetMoviesByActor(Actor actor);
        void UpdateMovie(Movie movie);

        #endregion
    }
}