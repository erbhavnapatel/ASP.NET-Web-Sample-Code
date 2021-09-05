using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerOrderWebApplication.Models;

namespace CustomerOrderWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly modelContext _context;

        public AgentsController(modelContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        private async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Agents/5
        [HttpGet("{AgentCode}")]
        public async Task<ActionResult<Agent>> GetAgent(string AgentCode)
        {
            var agent = await _context.Agent.FindAsync(AgentCode);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostAgent(Customer customer)
        {
            _context.Customer.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustExists(customer.CustCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { id = customer.CustCode }, customer);
        }

        // PUT: api/Agents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{AgentCode}")]
        public async Task<IActionResult> PutAgent(string AgentCode, Agent agent)
        {
            if (AgentCode != agent.AgentCode)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(AgentCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Agents/5
        [HttpDelete("{AgentCode}")]
        public async Task<ActionResult<Agent>> DeleteAgent(string AgentCode)
        {
            var agent = await _context.Agent.FindAsync(AgentCode);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agent.Remove(agent);
            await _context.SaveChangesAsync();

            return agent;
        }

        private bool AgentExists(string id)
        {
            return _context.Agent.Any(e => e.AgentCode == id);
        }

        private bool CustExists(string id)
        {
            return _context.Customer.Any(e => e.CustCode == id);
        }
    }
}
