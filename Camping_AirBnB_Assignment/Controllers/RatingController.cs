using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public RatingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new rating
        [HttpPost]
        public ActionResult Post(Rating rating)
        {
            // Call the data context to add the rating
            _data.AddRating(rating);
            return Ok("Rating created");
        }

        // Method to retrieve all ratings
        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetRatings()
        {
            // Call the data context to retrieve all ratings
            return Ok(_data.GetRatings());
        }

        // Method to retrieve ratings by camping spot ID
        [HttpGet("byCampingSpot/{campingSpotId}")]
        public ActionResult<IEnumerable<Rating>> GetRatingsByCampingSpot(int campingSpotId)
        {
            // Call the data context to retrieve ratings by camping spot ID
            return Ok(_data.GetRatingsByCampingSpot(campingSpotId));
        }

        // Method to retrieve ratings by user ID
        [HttpGet("byUser/{userId}")]
        public ActionResult<IEnumerable<Rating>> GetRatingsByUser(int userId)
        {
            // Call the data context to retrieve ratings by user ID
            return Ok(_data.GetRatingsByUser(userId));
        }

        // Method to delete a rating by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteRating(int id)
        {
            // Call the data context to delete the rating by ID
            _data.DeleteRating(id);
            return Ok("Rating deleted");
        }

        // Method to update a rating by ID
        [HttpPut("{id}")]
        public ActionResult UpdateRating(int id, Rating updatedRating)
        {
            // Call the data context to update the rating by ID
            _data.UpdateRating(id, updatedRating);
            return Ok("Rating updated");
        }

        // Method to retrieve the score of a rating by ID
        [HttpGet("{id}/score")]
        public ActionResult<int> GetRatingScore(int id)
        {
            // Call the data context to retrieve the score of the rating by ID
            return Ok(_data.GetRatingScore(id));
        }
    }
}