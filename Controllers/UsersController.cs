using BankingAPI.Data;
using BankingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly BankingDbContext _context;

    public UsersController(BankingDbContext context)
    {
        _context = context;
    }

    // READ (all)
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users.ToList());
    }

    // READ (one)
    [HttpGet("{id:int}")]
    public IActionResult GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    // CREATE
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // UPDATE
    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, UpdateUserRequest request)
    {
        var user = _context.Users.Find(id);
        if (user is null)
            return NotFound();

        user.Name = request.Name;
        user.Email = request.Email;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user is null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
