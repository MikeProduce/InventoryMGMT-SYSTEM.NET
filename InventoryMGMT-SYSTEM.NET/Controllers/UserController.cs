using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryMGMT_SYSTEM.NET.Data;
using InventoryMGMT_SYSTEM.NET.Models;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly InventoryMGMTDbContext _context;

    public UserController(InventoryMGMTDbContext context)
    {
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // POST: api/User
    [HttpPost]
    public IActionResult PostUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public IActionResult PutUser(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}