using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize] // 🔐 Apply at controller level
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TransactionsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        // ✅ Safe extraction of User ID
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            return Unauthorized("Invalid token");

        int userId = int.Parse(userIdClaim.Value);

        // ✅ Async + efficient query
        var transactions = await _context.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Date)
            .ToListAsync();

        // ✅ Map to DTO
        var result = _mapper.Map<List<TransactionDto>>(transactions);

        return Ok(result);
    }
}