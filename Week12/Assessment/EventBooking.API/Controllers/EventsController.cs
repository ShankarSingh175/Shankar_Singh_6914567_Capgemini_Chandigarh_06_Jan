using Microsoft.AspNetCore.Mvc;
using EventBooking.API.Data;
using AutoMapper;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EventsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEvents()
    {
        return Ok(_mapper.Map<List<EventDto>>(_context.Events.ToList()));
    }
}