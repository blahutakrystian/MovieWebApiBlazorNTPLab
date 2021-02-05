using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Model;

namespace MovieWebApi.Interface
{
    public interface IReviewRepository
    {
        Review Get(int reviewId);
        IEnumerable<Review> GetAll();
        Review Post(Review newReview);
        Review Put(Review updatedReview);
        Review Delete(int reviewId);

    }
}
