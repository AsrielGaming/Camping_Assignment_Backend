using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CommentController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new comment
        [HttpPost]
        public ActionResult Post(Comment comment)
        {
            // Call the data context to add the comment
            _data.AddComment(comment);
            return Ok("Comment created");
        }

        // Method to retrieve all comments
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            // Call the data context to retrieve all comments
            return Ok(_data.GetComments());
        }

        // Method to retrieve comments by camping spot ID
        [HttpGet("byCampingSpot/{campingSpotId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByCampingSpot(int campingSpotId)
        {
            // Call the data context to retrieve comments by camping spot ID
            return Ok(_data.GetCommentsByCampingSpot(campingSpotId));
        }

        // Method to retrieve comments by user ID
        [HttpGet("byUser/{userId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByUser(int userId)
        {
            // Call the data context to retrieve comments by user ID
            return Ok(_data.GetCommentsByUser(userId));
        }

        // Method to delete a comment by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            // Call the data context to delete the comment by ID
            _data.DeleteComment(id);
            return Ok("Comment deleted");
        }

        // Method to update a comment by ID
        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, Comment updatedComment)
        {
            // Call the data context to update the comment by ID
            _data.UpdateComment(id, updatedComment);
            return Ok("Comment updated");
        }

        // Method to retrieve the text of a comment by ID
        [HttpGet("{id}/text")]
        public ActionResult<string> GetCommentText(int id)
        {
            // Call the data context to retrieve the text of the comment by ID
            return Ok(_data.GetCommentText(id));
        }
    }
}