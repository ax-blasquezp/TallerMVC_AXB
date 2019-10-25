using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactenosItemsController : ControllerBase
    {
        private readonly ContactenosContext _context;

        public ContactenosItemsController(ContactenosContext context)
        {
            _context = context;
        }

        // GET: api/ContactenosItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactenosItem>>> GetContactenosItem()
        {
            return await _context.ContactenosItems.ToListAsync();
        }

        // GET: api/ContactenosItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactenosItem>> GetContactenosItem(long id)
        {
            var contactenosItem = await _context.ContactenosItems.FindAsync(id);

            if (contactenosItem == null)
            {
                return NotFound();
            }

            return contactenosItem;
        }

        // PUT: api/ContactenosItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactenosItem(long id, ContactenosItem contactenosItem)
        {
            if (id != contactenosItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactenosItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactenosItemExists(id))
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

        // POST: api/ContactenosItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ContactenosItem>> PostContactenosItem(ContactenosItem contactenosItem)
        {
            _context.ContactenosItems.Add(contactenosItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetContactenosItem", new { id = contactenosItem.Id }, contactenosItem);
            return CreatedAtAction(nameof(GetContactenosItem), new { id = contactenosItem.Id }, contactenosItem);
        }

        // DELETE: api/ContactenosItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactenosItem>> DeleteContactenosItem(long id)
        {
            var contactenosItem = await _context.ContactenosItems.FindAsync(id);
            if (contactenosItem == null)
            {
                return NotFound();
            }

            _context.ContactenosItems.Remove(contactenosItem);
            await _context.SaveChangesAsync();

            return contactenosItem;
        }

        private bool ContactenosItemExists(long id)
        {
            return _context.ContactenosItems.Any(e => e.Id == id);
        }
    }
}
