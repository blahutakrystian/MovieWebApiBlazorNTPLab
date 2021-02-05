using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Context;
using MovieWebApi.Interface;
using MovieWebApi.Model;

namespace MovieWebApi.Service
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieWebApiMsSqlContext _context;

        public MovieRepository(MovieWebApiMsSqlContext context)
        {
            _context = context;
        }

        public  Movie Get(int movieId)
        {
            return  _context.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public Movie Post(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return newMovie;
        }

        public Movie Put(Movie updatedMovie)
        {
            var movie = _context.Movies.Attach(updatedMovie);
            movie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedMovie;
        }

        public Movie Delete(int movieId)
        {
            Movie movie = _context.Movies.Find(movieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return movie;

        }
    }
}
