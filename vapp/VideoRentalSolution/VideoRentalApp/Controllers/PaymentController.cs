using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;

namespace VideoRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]

    public class PaymentController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly ILogger<MovieController> _logger;

        public PaymentController(MovieContext context, ILogger<MovieController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Payment
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            try
            {
                if (_context.Payments == null)
                {
                    return NotFound();
                }

                return await _context.Payments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving payments");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            try
            {
                if (_context.Payments == null)
                {
                    return NotFound();
                }

                var payment = await _context.Payments.FindAsync(id);

                if (payment == null)
                {
                    return NotFound();
                }

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving payment");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            try
            {
                if (_context.Payments == null)
                {
                    return Problem("Payments is null.");
                }

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPayment", new { id = payment.PaymentId }, payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing payment creation");
                return StatusCode(500, "Internal Server Error");
            }
        }


        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }
    }
}
