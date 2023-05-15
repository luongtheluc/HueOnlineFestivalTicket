using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.Prototypes;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;
    private readonly ILogger<UserController> _logger;

    private readonly IConfiguration _configuration;

    public UserController(IUserService UserService, ILogger<UserController> logger, IConfiguration configuration)
    {
        this._configuration = configuration;
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
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Register success",
                Data = CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user)
            });
        }
        catch (System.Exception e)
        {

            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Register fail: " + e.GetBaseException(),
                Data = null,
            });
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

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (!await _UserService.CheckUserName(username))
        {
            return NotFound("username not found");
        }
        var user = await _UserService.GetUserByUsernamePasswordAsync(username, password);
        if (user != null)
        {
            string token = CreateToken(user);

            return Ok(new ApiResponse
            {
                Message = "Login success",
                Data = token,
                Success = true,

            });
        }
        else
        {
            return NotFound("password wrong");
        }

    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;

    }


}
