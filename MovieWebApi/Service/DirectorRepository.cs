using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Context;
using MovieWebApi.Interface;
using MovieWebApi.Model;

namespace MovieWebApi.Service
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieWebApiMsSqlContext _context;
        public DirectorRepository(MovieWebApiMsSqlContext context)
        {
            _context = context;
        }
        public Director Delete(int directorId)
        {
            Director director = _context.Directors.Find(directorId);
            if (director != null)
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
            return director;
        }
        public Director Get(int directorId)
        {
            return _context.Directors.Find(directorId);
        }
        public IEnumerable<Director> GetAll()
        {
            return _context.Directors;
        }
        public Director Post(Director newDirector)
        {
            _context.Directors.Add(newDirector);
            _context.SaveChanges();
            return newDirector;
        }
        public Director Put(Director updatedDirector)
        {
            var director = _context.Directors.Attach(updatedDirector);
            director.State = Microsoft
                .EntityFrameworkCore
                .EntityState
                .Modified;
            _context.SaveChanges();
            return updatedDirector;
        }

    }
}
