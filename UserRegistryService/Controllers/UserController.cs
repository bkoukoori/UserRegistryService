using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistryService.DBContext;

namespace UserRegistryService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly UserDbContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(UserDbContext context, ILogger<UserController> logger)
    {
        _context = context;
        _logger = logger;

    }

    [HttpGet("validate")]
    public async Task<IActionResult> ValidateUsername([FromQuery] string username)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 6 || username.Length > 30 || !Regex.IsMatch(username, "^[a-zA-Z0-9]+$"))
            return BadRequest("Invalid username format.");

        var exists = await _context.Users.AnyAsync(u => u.Username == username);
        return exists ? Conflict("Username already exists.") : Ok("Username is valid.");
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateUser([FromBody] UserProfile user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usernameTaken = await _context.Users.AnyAsync(u => u.Username == user.Username);
        if (usernameTaken)
            return Conflict("Username is already taken.");

        var existingUser = await _context.Users.FindAsync(user.AccountId);
        if (existingUser != null)
            _context.Users.Remove(existingUser);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User added or updated.");
    }


}

