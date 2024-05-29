using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenityController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public AmenityController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new amenity
        [HttpPost]
        public ActionResult Post(Amenity amenity)
        {
            // Call the data context to add the amenity
            _data.AddAmenity(amenity);
            return Ok("Amenity created");
        }

        // Method to update an existing amenity
        [HttpPut("{id}")]
        public ActionResult UpdateAmenity(int id, Amenity updatedAmenity)
        {
            // Call the data context to update the amenity
            _data.UpdateAmenity(id, updatedAmenity);
            return Ok("Amenity updated");
        }

        // Method to delete an amenity by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteAmenity(int id)
        {
            // Call the data context to delete the amenity by ID
            _data.DeleteAmenity(id);
            return Ok("Amenity deleted");
        }

        // Method to retrieve all amenities
        [HttpGet]
        public ActionResult<IEnumerable<Amenity>> GetAmenities()
        {
            // Call the data context to retrieve all amenities
            return Ok(_data.GetAmenities());
        }
    }
}