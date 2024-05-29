using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public BookingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Method to create a new booking
        [HttpPost]
        public ActionResult Post(Booking booking)
        {
            // Call the data context to add the booking
            _data.AddBooking(booking);
            return Ok("Booking created");
        }

        // Method to retrieve all bookings
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            // Call the data context to retrieve all bookings
            return Ok(_data.GetBookings());
        }

        // Method to retrieve bookings by user ID
        [HttpGet("ByUserId/{userId}")]
        public ActionResult<IEnumerable<Booking>> GetBookingsByUserId(int userId)
        {
            // Call the data context to retrieve bookings by user ID
            return Ok(_data.GetBookingsByUserId(userId));
        }

        // Method to retrieve bookings by spot ID
        [HttpGet("BySpotId/{spotId}")]
        public ActionResult<IEnumerable<Booking>> GetBookingsBySpotId(int spotId)
        {
            // Call the data context to retrieve bookings by spot ID
            return Ok(_data.GetBookingsBySpotId(spotId));
        }

        // Method to retrieve a booking by ID
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            // Call the data context to retrieve the booking by ID
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // Method to update a booking
        [HttpPut("{id}")]
        public ActionResult UpdateBooking(int id, Booking updatedBooking)
        {
            // Call the data context to update the booking
            _data.UpdateBooking(id, updatedBooking);
            return Ok("Booking updated");
        }

        // Method to delete a booking by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            // Call the data context to delete the booking by ID
            _data.DeleteBooking(id);
            return Ok("Booking deleted");
        }

        // Method to retrieve the booking date by ID
        [HttpGet("{id}/BookingDate")]
        public ActionResult<DateTime> GetBookingDate(int id)
        {
            // Call the data context to retrieve the booking by ID
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking.BookingDate);
        }

        // Method to retrieve the check-in and check-out dates by ID
        [HttpGet("{id}/CheckInOutDates")]
        public ActionResult<Tuple<string, string>> GetCheckInOutDates(int id)
        {
            // Call the data context to retrieve the booking by ID
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(Tuple.Create(booking.CheckInDate, booking.CheckOutDate));
        }

        // Method to retrieve the total price of a booking by ID
        [HttpGet("{id}/TotalPrice")]
        public ActionResult<decimal> GetTotalPrice(int id)
        {
            // Call the data context to retrieve the booking by ID
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking.TotalPrice);
        }
    }
}