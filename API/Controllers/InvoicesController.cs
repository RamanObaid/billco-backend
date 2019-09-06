using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(string type)
        {
            var invoices = _context.Invoices.AsQueryable();
            if (type == "paid")
            {
               return await invoices.Where(i => i.Status == InvoiceStatus.Paid).OrderByDescending(i => i.DateConfirmed).ToListAsync();
            }
            else if (type == "quoted")
            {
                return await invoices.Where(i => i.Status == InvoiceStatus.Quoted).OrderByDescending(i => i.DateQuoted).ToListAsync();
            }
            else if (type == "cancelled")
            {
                return await  invoices.Where(i => i.Status == InvoiceStatus.Cancelled).OrderByDescending(i => i.DateQuoted).ToListAsync();
            }
            else if (type == "overdue")
            {
                return await invoices.Where(i => DateTime.Now > i.DateDue).OrderBy(i => i.DateDue).ToListAsync();
            }
            else {
                return await invoices.Where(i => i.Status == InvoiceStatus.Confirmed).OrderByDescending(i => i.DateConfirmed).ToListAsync();
            }
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            invoice.Total = invoice.Lines.Sum(l => (l.Quantity * l.UnitPrice));
            invoice.Total = invoice.DiscountIsPercentage ? invoice.Total * (1 - invoice.DiscountAmount) : invoice.Total - invoice.DiscountAmount;
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Invoices/5/confirm
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) {
                return NotFound();
            }
            invoice.DateConfirmed = DateTime.Now;
            invoice.Status = InvoiceStatus.Confirmed;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
