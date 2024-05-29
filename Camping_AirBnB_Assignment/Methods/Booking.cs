using System;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SpotId { get; set; }
    public DateTime BookingDate { get; set; }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }

    // Constructor to initialize times to default values
    public Booking()
    {
        CheckInDate = "12:00"; // Default check-in time at 12:00 PM
        CheckOutDate = "12:00"; // Default check-out time at 12:00 PM
    }

    // Helper methods to get check-in and check-out times
    public string GetCheckInTimeString()
    {
        return CheckInDate;
    }

    public string GetCheckOutTimeString()
    {
        return CheckOutDate;
    }

    // Helper method to parse string "hh:mm" to TimeSpan
    public static string ParseTimeString(string timeString)
    {
        // Optionally, you can add validation here to ensure proper format
        return timeString;
    }
}
