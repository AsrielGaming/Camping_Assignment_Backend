using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;
using System.Linq;

namespace add_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampingSpotController : ControllerBase
    {
        private readonly IAnonymousCampingDataContext _data;

        public CampingSpotController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new camping spot
        [HttpPost]
        public ActionResult Post(CampingSpot campingSpot)
        {
            // Call the data context to add the camping spot
            _data.AddCampingSpot(campingSpot);
            return Ok("Camping spot created");
        }

        // Method to retrieve all camping spots
        [HttpGet]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpots()
        {
            // Call the data context to retrieve all camping spots
            var campingSpots = _data.GetCampingSpots();

            // Loop through each camping spot
            foreach (var spot in campingSpots)
            {
                // Get camp type ID for each camping spot
                var campType = _data.GetCampTypesForCampingSpot(spot.Id).FirstOrDefault();
                if (campType != null)
                {
                    spot.CampTypeId = campType.Id;
                }

                // Get amenities for each camping spot
                var amenities = _data.GetAmenitiesForCampingSpot(spot.Id).ToList();
                if (amenities.Any())
                {
                    spot.AmenityIds = amenities.Select(a => a.Id).ToList();
                }
            }

            return Ok(campingSpots);
        }

        // Method to update an existing camping spot
        [HttpPut("{id}")]
        public ActionResult UpdateCampingSpot(int id, CampingSpot updatedCampingSpot)
        {
            // Call the data context to update the camping spot
            _data.UpdateCampingSpot(id, updatedCampingSpot);
            return Ok("Camping spot updated");
        }

        // Method to delete a camping spot by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteCampingSpot(int id)
        {
            // Call the data context to delete the camping spot by ID
            _data.DeleteCampingSpot(id);
            return Ok("Camping spot deleted");
        }

        // Method to retrieve camping spots by owner ID
        [HttpGet("byOwner/{ownerId}")]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpotsByOwner(int ownerId)
        {
            // Call the data context to retrieve camping spots by owner ID
            return Ok(_data.GetCampingSpotsByOwner(ownerId));
        }

        // Method to retrieve camping spots by camping ground ID
        [HttpGet("byCampingGround/{campingGroundId}")]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpotsByCampingGround(int campingGroundId)
        {
            // Call the data context to retrieve camping spots by camping ground ID
            return Ok(_data.GetCampingSpotsByCampingGround(campingGroundId));
        }

        // Method to retrieve the name of a camping spot by ID
        [HttpGet("{id}/spotName")]
        public ActionResult<string> GetSpotName(int id)
        {
            // Call the data context to retrieve the name of the camping spot by ID
            return Ok(_data.GetSpotName(id));
        }

        // Method to retrieve the size of a camping spot by ID
        [HttpGet("{id}/size")]
        public ActionResult<int> GetSize(int id)
        {
            // Call the data context to retrieve the size of the camping spot by ID
            return Ok(_data.GetSize(id));
        }

        // Method to retrieve the description of a camping spot by ID
        [HttpGet("{id}/description")]
        public ActionResult<string> GetDescription(int id)
        {
            // Call the data context to retrieve the description of the camping spot by ID
            return Ok(_data.GetDescription(id));
        }

        // Method to retrieve the price of a camping spot by ID
        [HttpGet("{id}/price")]
        public ActionResult<decimal> GetPrice(int id)
        {
            // Call the data context to retrieve the price of the camping spot by ID
            return Ok(_data.GetPrice(id));
        }

        // Method to retrieve whether a camping spot is available by ID
        [HttpGet("{id}/isAvailable")]
        public ActionResult<bool> GetIsAvailable(int id)
        {
            // Call the data context to retrieve whether the camping spot is available by ID
            return Ok(_data.GetIsAvailable(id));
        }

        // Method to update the camp type of a camping spot by ID
        [HttpPut("{id}/campType")]
        public ActionResult UpdateCampingSpotCampType(int id, int campTypeId)
        {
            // Call the data context to update the camp type of the camping spot by ID
            _data.UpdateCampingSpotCampType(id, campTypeId);
            return Ok("Camping spot camp type updated");
        }

        // Method to update the amenities of a camping spot by ID
        [HttpPut("{id}/amenities")]
        public ActionResult UpdateCampingSpotAmenities(int id, List<int> amenityIds)
        {
            // Call the data context to update the amenities of the camping spot by ID
            _data.UpdateCampingSpotAmenities(id, amenityIds);
            return Ok("Camping spot amenities updated");
        }
    }
}