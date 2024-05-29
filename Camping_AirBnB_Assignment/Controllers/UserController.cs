using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public UserController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to retrieve all users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            // Call the data context to retrieve all users
            return Ok(_data.GetUsers());
        }

        // Method to create a new user
        [HttpPost]
        public ActionResult Post(User user)
        {
            // Call the data context to add the user
            _data.AddUser(user);
            return Ok("User created");
        }

        // Method to retrieve a user by ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            // Call the data context to retrieve the user by ID
            var user = _data.GetUserById(id);
            if (user == null)
            {
                // If user is not found, return 404 Not Found
                return NotFound();
            }
            return Ok(user);
        }

        // Method to update username for a user
        [HttpPut("{id}/username")]
        public ActionResult UpdateUsername(int id, string newUsername)
        {
            // Call the data context to update the username
            _data.UpdateUsername(id, newUsername);
            return Ok("Username updated");
        }

        // Method to update password for a user
        [HttpPut("{id}/password")]
        public ActionResult UpdatePassword(int id, string newPassword)
        {
            // Call the data context to update the password
            _data.UpdatePassword(id, newPassword);
            return Ok("Password updated");
        }

        // Method to update email for a user
        [HttpPut("{id}/email")]
        public ActionResult UpdateEmail(int id, string newEmail)
        {
            // Call the data context to update the email
            _data.UpdateEmail(id, newEmail);
            return Ok("Email updated");
        }

        // Method to delete a user by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            // Call the data context to delete the user by ID
            _data.DeleteUser(id);
            return Ok("User deleted");
        }
    }
}