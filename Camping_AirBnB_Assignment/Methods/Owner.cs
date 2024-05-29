using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class Owner
{
    public int Id { get; set; }
    public required string OwnerName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }

}
