using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public OwnerController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to retrieve all owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> GetOwners()
        {
            // Call the data context to retrieve all owners
            return Ok(_data.GetOwners());
        }

        // Method to create a new owner
        [HttpPost]
        public ActionResult Post(Owner owner)
        {
            // Check if the provided owner model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the data context to add the owner
            _data.AddOwner(owner);
            return Ok("Owner created");
        }

        // Method to retrieve an owner by ID
        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwner(int id)
        {
            // Call the data context to retrieve the owner by ID
            var owner = _data.GetOwnerById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // Method to delete an owner by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteOwner(int id)
        {
            // Call the data context to delete the owner by ID
            _data.DeleteOwner(id);
            return Ok("Owner deleted");
        }

        // Method to update the name of an owner by ID
        [HttpPut("{id}/name")]
        public ActionResult UpdateOwnerName(int id, string newName)
        {
            // Call the data context to update the name of the owner by ID
            _data.UpdateOwnerName(id, newName);
            return Ok("Owner name updated");
        }

        // Method to update the email of an owner by ID
        [HttpPut("{id}/email")]
        public ActionResult UpdateOwnerEmail(int id, string newEmail)
        {
            // Call the data context to update the email of the owner by ID
            _data.UpdateOwnerEmail(id, newEmail);
            return Ok("Owner email updated");
        }

        // Method to update the password of an owner by ID
        [HttpPut("{id}/password")]
        public ActionResult UpdateOwnerPassword(int id, string newPassword)
        {
            // Call the data context to update the password of the owner by ID
            _data.UpdateOwnerPassword(id, newPassword);
            return Ok("Owner password updated");
        }

        // Method to update the phone number of an owner by ID
        [HttpPut("{id}/phone")]
        public ActionResult UpdateOwnerPhoneNumber(int id, string newPhoneNumber)
        {
            // Call the data context to update the phone number of the owner by ID
            _data.UpdateOwnerPhoneNumber(id, newPhoneNumber);
            return Ok("Owner phone number updated");
        }
    }
}