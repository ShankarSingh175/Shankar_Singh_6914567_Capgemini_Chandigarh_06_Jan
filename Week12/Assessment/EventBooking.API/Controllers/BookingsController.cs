using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventBooking.API.Data;
using EventBooking.API.Models;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    // =========================
    // ✅ CREATE BOOKING
    // =========================
    [HttpPost]
    public IActionResult Book([FromBody] BookingDto dto)
    {
        var username = User.Identity.Name;

        var ev = _context.Events.Find(dto.EventId);

        if (ev == null)
            return NotFound("Event not found");

        if (ev.AvailableSeats < dto.SeatsBooked)
            return BadRequest("Not enough seats available");

        ev.AvailableSeats -= dto.SeatsBooked;

        var booking = new Booking
        {
            EventId = dto.EventId,
            SeatsBooked = dto.SeatsBooked,
            UserId = username // ✅ FIXED (from JWT)
        };

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return Ok(new { message = "Booked Successfully" });
    }

    // =========================
    // ✅ READ (GET USER BOOKINGS)
    // =========================
    [HttpGet]
    public IActionResult GetBookings()
    {
        var username = User.Identity.Name;

        var bookings = _context.Bookings
            .Where(b => b.UserId == username)
            .ToList();

        return Ok(bookings);
    }

    // =========================
    // ✅ UPDATE BOOKING
    // =========================
    [HttpPut("{id}")]
    public IActionResult UpdateBooking(int id, [FromBody] BookingDto dto)
    {
        var username = User.Identity.Name;

        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id && b.UserId == username);

        if (booking == null)
            return NotFound("Booking not found");

        var ev = _context.Events.Find(booking.EventId);

        if (ev == null)
            return NotFound("Event not found");

        // Restore previous seats
        ev.AvailableSeats += booking.SeatsBooked;

        // Check new seats availability
        if (ev.AvailableSeats < dto.SeatsBooked)
            return BadRequest("Not enough seats available");

        // Update booking
        booking.SeatsBooked = dto.SeatsBooked;
        ev.AvailableSeats -= dto.SeatsBooked;

        _context.SaveChanges();

        return Ok(new { message = "Booking updated" });
    }

    // =========================
    // ✅ DELETE BOOKING
    // =========================
    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var username = User.Identity.Name;

        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id && b.UserId == username);

        if (booking == null)
            return NotFound("Booking not found");

        var ev = _context.Events.Find(booking.EventId);

        if (ev != null)
        {
            // Restore seats when deleting
            ev.AvailableSeats += booking.SeatsBooked;
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();

        return Ok(new { message = "Booking deleted" });
    }
}