using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Interface;
using MovieWebApi.Model;

namespace MovieWebApi.Controller
{
    [Route(("api/[controller]"))]
    public class ReviewController: ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Review> reviews = _reviewRepository.GetAll();
            if (reviews == null)
            {
                return NoContent();
            }

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        public IActionResult Get(int reviewId)
        {
            Review review = _reviewRepository.Get(reviewId);
            if (review == null)
            {
                return NoContent();
            }

            return Ok(review);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newReview = _reviewRepository.Post(review);
            return CreatedAtAction(nameof(Get), new {reviewId = newReview.ReviewId}, newReview);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedReview = _reviewRepository.Put(review);
            return Ok(updatedReview);
        }

        [HttpDelete("{reviewId}")]
        public IActionResult Delete(int reviewId)
        {
            var deletedReview = _reviewRepository.Delete(reviewId);
            if (deletedReview == null)
            {
                return NoContent();
            }

            return Ok(deletedReview);
        }
    }
}
