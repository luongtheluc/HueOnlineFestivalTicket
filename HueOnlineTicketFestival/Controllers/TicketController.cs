using HueOnlineTicketFestival.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;
    private readonly ILogger<TicketController> _logger;


    public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
    {
        _ticketService = ticketService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        _logger.LogInformation("get");
        try
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return tickets == null ? BadRequest() : Ok(tickets);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddTicket(Ticket ticket)
    {
        _logger.LogInformation("Creating a new ticket");

        try
        {
            await _ticketService.AddTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.TicketId }, ticket);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket ticket)
    {

        _logger.LogInformation("update a ticket");

        if (id != ticket.TicketId)
        {
            return NotFound();
        }

        try
        {
            await _ticketService.UpdateTicketAsync(id, ticket);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.TicketId }, ticket);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        await _ticketService.DeleteTicketAsync(id);
        return NoContent();
    }
}
