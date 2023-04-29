using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.API.Data;
using Tickets.Shared.Entities;

namespace Tickets.API.Controllers
{
	[ApiController]
    [Route("/api/ticket")]
    public class TicketController : ControllerBase
	{
        private readonly DataContext _context;

        public TicketController(DataContext context)
		{
			_context = context;
		}

        [HttpGet]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.Ticket.Take(100).ToListAsync());
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetAsync(string ticketId)
        {
            var ticket = await _context.Ticket.FirstOrDefaultAsync(x => x.TicketId == ticketId);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Ticket ticket)
        {
            try
            {
                _context.Update(ticket);

                await _context.SaveChangesAsync();

                return Ok(ticket);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

