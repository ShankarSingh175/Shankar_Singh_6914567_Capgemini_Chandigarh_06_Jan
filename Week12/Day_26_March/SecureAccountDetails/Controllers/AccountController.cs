using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAccountDetails.DTOs;
using SecureAccountDetails.Models;

namespace SecureAccountDetails.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private static List<Accounts> accounts = new List<Accounts>();

    public AccountController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // Create Account (any authenticated user)
    [HttpPost("create")]
    [Authorize]
    public IActionResult CreateAccount([FromBody] AccountDetailsDto dto)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var account = new Accounts
        {
            Id = accounts.Count + 1,
            AccountHolderName = dto.AccountHolderName,
            AccountNumber = dto.MaskedAccountNumber, // store full number for Admin
            Balance = 0,
            UserId = userId
        };

        accounts.Add(account);
        return Ok("Account created successfully.");
    }

    // Get all accounts (role-based)
    [HttpGet("details")]
    [Authorize]
    public IActionResult GetAccounts()
    {
        var role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

        if (role == "Admin")
        {
            // Admin sees full info
            var adminList = accounts.Select(a => new AccountDetailsDto
            {
                AccountHolderName = a.AccountHolderName,
                MaskedAccountNumber = a.AccountNumber, // full account number for Admin
                Balance = a.Balance
            }).ToList();
            return Ok(adminList);
        }
        else
        {
            // User sees masked info
            var userList = _mapper.Map<List<AccountDetailsDto>>(accounts);
            return Ok(userList);
        }
    }

    // API specifically for masked accounts
    [HttpGet("masked")]
    [Authorize]
    public IActionResult GetMaskedAccounts()
    {
        var maskedList = _mapper.Map<List<AccountDetailsDto>>(accounts);
        return Ok(maskedList);
    }
}