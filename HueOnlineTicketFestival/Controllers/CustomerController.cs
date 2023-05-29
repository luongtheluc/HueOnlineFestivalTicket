using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _custumerService;
    private readonly ILogger<CustomerController> _logger;


    public CustomerController(ICustomerService custumerService, ILogger<CustomerController> logger)
    {
        _custumerService = custumerService;
        _logger = logger;
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllCustumer()
    {
        _logger.LogInformation("get");
        try
        {
            var tickets = await _custumerService.GetAllCustomersAsync();
            return tickets == null ? BadRequest() : Ok(tickets);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}"), Authorize(Roles = "User")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var ticket = await _custumerService.GetCustomerByIdAsync(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
        _logger.LogInformation("Creating a new ticket");

        try
        {
            await _custumerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }

    }

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {

        _logger.LogInformation("update a ticket");

        if (id != customer.CustomerId)
        {
            return NotFound();
        }

        try
        {
            await _custumerService.UpdateCustomerAsync(id, customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        await _custumerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}
