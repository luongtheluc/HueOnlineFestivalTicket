using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;
    private readonly ILogger<UserController> _logger;


    public UserController(IUserService UserService, ILogger<UserController> logger)
    {
        _UserService = UserService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        _logger.LogInformation("get");
        try
        {
            var users = await _UserService.GetAllUsersAsync();
            return users == null ? BadRequest() : Ok(users);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var user = await _UserService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {
        _logger.LogInformation("Creating a new User");

        try
        {
            await _UserService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {

        _logger.LogInformation("update a User");

        if (id != user.UserId)
        {
            return NotFound();
        }

        try
        {
            await _UserService.UpdateUserAsync(id, user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _UserService.DeleteUserAsync(id);
        return NoContent();
    }
}
