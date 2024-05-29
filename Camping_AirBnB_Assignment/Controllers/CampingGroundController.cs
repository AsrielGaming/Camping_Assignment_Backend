using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampingGroundController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampingGroundController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new camping ground
        [HttpPost]
        public ActionResult Post(CampingGround campingGround)
        {
            // Call the data context to add the camping ground
            _data.AddCampingGround(campingGround);
            return Ok("Camping ground created");
        }

        // Method to update an existing camping ground
        [HttpPut("{id}")]
        public ActionResult UpdateCampingGround(int id, CampingGround updatedCampingGround)
        {
            // Call the data context to update the camping ground
            _data.UpdateCampingGround(id, updatedCampingGround);
            return Ok("Camping ground updated");
        }

        // Method to delete a camping ground by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteCampingGround(int id)
        {
            // Call the data context to delete the camping ground by ID
            _data.DeleteCampingGround(id);
            return Ok("Camping ground deleted");
        }

        // Method to retrieve all camping grounds
        [HttpGet]
        public ActionResult<IEnumerable<CampingGround>> GetCampingGrounds()
        {
            // Call the data context to retrieve all camping grounds
            return Ok(_data.GetCampingGrounds());
        }

        // Method to retrieve the name of a camping ground by ID
        [HttpGet("{id}/name")]
        public ActionResult<string> GetName(int id)
        {
            // Call the data context to retrieve the name of the camping ground by ID
            return Ok(_data.GetName(id));
        }

        // Method to retrieve the amount of camping spots in a camping ground by ID
        [HttpGet("{id}/amountOfCampingSpots")]
        public ActionResult<int> GetAmountOfCampingSpots(int id)
        {
            // Call the data context to retrieve the amount of camping spots in the camping ground by ID
            return Ok(_data.GetAmountOfCampingSpots(id));
        }

        // Method to retrieve the location of a camping ground by ID
        [HttpGet("{id}/location")]
        public ActionResult<string> GetLocation(int id)
        {
            // Call the data context to retrieve the location of the camping ground by ID
            return Ok(_data.GetLocation(id));
        }

        // Method to retrieve whether a camping ground is pet-friendly by ID
        [HttpGet("{id}/isPetFriendly")]
        public ActionResult<bool> GetIsPetFriendly(int id)
        {
            // Call the data context to retrieve whether the camping ground is pet-friendly by ID
            return Ok(_data.GetIsPetFriendly(id));
        }
    }
}