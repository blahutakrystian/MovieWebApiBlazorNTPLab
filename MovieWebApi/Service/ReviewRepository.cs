using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApi.Context;
using MovieWebApi.Interface;
using MovieWebApi.Model;

namespace MovieWebApi.Service
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MovieWebApiMsSqlContext _context;
        public ReviewRepository(MovieWebApiMsSqlContext context)
        {
            _context = context;
        }
        public Review Delete(int reviewId)
        {
            Review review = _context.Reviews.Find(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
            return review;
        }
        public Review Get(int reviewId)
        {
            return _context.Reviews.Find(reviewId);
        }
        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews;
        }
        public Review Post(Review newReview)
        {
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return newReview;
        }
        public Review Put(Review updatedReview)
        {
            var review = _context.Reviews.Attach(updatedReview);
            review.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedReview;
        }

    }
}
