using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Model;

namespace MovieWebApi.Interface
{
    public interface IMovieRepository
    {
        Movie Get(int movieId);
        IEnumerable<Movie> GetAll();
        Movie Post(Movie newMovie);
        Movie Put(Movie updatedMovie);
        Movie Delete(int movieId);

    }
}
