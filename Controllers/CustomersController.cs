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
    public class CustomersController : ControllerBase
    {
        private readonly modelContext _context;

        public CustomersController(modelContext context)
        {
            _context = context;
        }

        // GET: api/Customers/5
        [HttpGet("{CustomerCode}")]
        public async Task<ActionResult<Customer>> GetCustomer(string CustomerCode)
        {
            var customer = await _context.Customer.FindAsync(CustomerCode);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // GET: api/Orders/5
        [HttpGet("{OrderNo}")]
        public async Task<ActionResult<Order>> GetOrders(string OrderNo)
        {
            var order = await _context.Order.FindAsync(OrderNo);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CustomerCode}")]
        public async Task<IActionResult> PutCustomer(string CustomerCode, Customer customer)
        {
            if (CustomerCode != customer.CustCode)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(CustomerCode))
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

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CustCode == id);
        }
    }
}
