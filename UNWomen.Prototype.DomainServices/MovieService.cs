#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UNWomen.Common;
using UNWomen.Prototype.Contracts.DomainServices;
using UNWomen.Prototype.Data;
using UNWomen.Prototype.Entities;

#endregion

namespace UNWomen.Prototype.DomainServices
{
    public class MovieService : DomainServiceBase, IMovieService
    {
        #region Readonly & Static Fields

        private readonly DbSet<Actor> _actors;
        private readonly DbSet<Movie> _movies;

        #endregion

        #region C'tors

        public MovieService(PrototypeContext dbContext) : base(dbContext)
        {
            _movies = DbContext.Movies;
            _actors = DbContext.Actors;
        }

        #endregion

        #region IMovieService Members

        public IEnumerable<Movie> GetMovies()
        {
            IEnumerable<Movie> movies = _movies.ToList();
            return movies;
        }

        public IEnumerable<Movie> GetMovies(Expression<Func<Movie, bool>> where)
        {
            IEnumerable<Movie> movies = _movies.Where(where).ToList();
            ;
            return movies;
        }

        public IEnumerable<Movie> GetMoviesByActor(Actor actor)
        {
            IEnumerable<Movie> movies = _movies.Where(c => c.MovieActors.Any(a => a.ActorId == actor.ActorId));
            return movies;
        }

        public IEnumerable<Actor> GetActorsForMovie(Movie movie)
        {
            var mov = _movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
            if (mov == null) return null;
            IEnumerable<int> actorIds = mov
                .MovieActors
                .Where(m => m.MovieId == movie.MovieId)
                .Select(m => m.ActorId).ToList(); //ToList was performed to avoid multiple enumeration
            if (!actorIds.Any()) return null;
            IEnumerable<Actor> actors = actorIds.Select(actorId => _actors.Find(actorId));
            return actors;
        }

        public Movie GetMovie(int movieId)
        {
            Movie movie = _movies.FirstOrDefault(m => m.MovieId == movieId);
            return movie;
        }

        public void CreateMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("movie");
            _movies.Add(movie);
            DbContext.SaveChanges();
        }

        public void DeleteMovie(Expression<Func<Movie, bool>> where)
        {
            IEnumerable<Movie> objects = _movies.Where(where).AsEnumerable();
            foreach (Movie obj in objects)
                _movies.Remove(obj);
            DbContext.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("movie");
            _movies.Remove(movie);
            DbContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("movie");
            _movies.Attach(movie);
            DbContext.Entry(movie).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        #endregion
    }
}