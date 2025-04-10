using BookStoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    public IActionResult Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // TODO: Save to mock store
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // TODO: Issue token or set fake identity
        return Ok("Login successful.");
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult GetProfile()
    {
        return Ok(new { Username = "testuser", Role = "Admin" });
    }
}