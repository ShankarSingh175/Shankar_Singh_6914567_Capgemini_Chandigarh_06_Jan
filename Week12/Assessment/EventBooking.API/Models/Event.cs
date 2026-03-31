using System.ComponentModel.DataAnnotations;

public class Event
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [FutureDate]
    public DateTime Date { get; set; }

    public string Location { get; set; }

    [Range(1, 1000)]
    public int AvailableSeats { get; set; }
}