using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Model;

namespace MovieWebApi.Interface
{
    public interface IDirectorRepository
    {
        Director Get(int directorId);
        IEnumerable<Director> GetAll();
        Director Post(Director newDirector);
        Director Put(Director updatedDirector);
        Director Delete(int directorId);

    }
}
