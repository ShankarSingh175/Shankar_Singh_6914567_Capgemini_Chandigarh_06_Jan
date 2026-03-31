using System.ComponentModel.DataAnnotations;

public class Booking
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string UserId { get; set; }

    [Range(1, 10)]
    public int SeatsBooked { get; set; }

    public Event Event { get; set; }
}