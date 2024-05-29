using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampTypeController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampTypeController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new camp type
        [HttpPost]
        public ActionResult Post(Camptype campType)
        {
            // Call the data context to add the camp type
            _data.AddCampType(campType);
            return Ok("Camp type created");
        }

        // Method to update an existing camp type
        [HttpPut("{id}")]
        public ActionResult UpdateCampType(int id, Camptype updatedCampType)
        {
            // Call the data context to update the camp type
            _data.UpdateCampType(id, updatedCampType);
            return Ok("Camp type updated");
        }

        // Method to delete a camp type by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteCampType(int id)
        {
            // Call the data context to delete the camp type by ID
            _data.DeleteCampType(id);
            return Ok("Camp type deleted");
        }

        // Method to retrieve all camp types
        [HttpGet]
        public ActionResult<IEnumerable<Camptype>> GetCampTypes()
        {
            // Call the data context to retrieve all camp types
            return Ok(_data.GetCampTypes());
        }
    }
}