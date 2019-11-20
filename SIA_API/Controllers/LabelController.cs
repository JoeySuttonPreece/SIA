using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIA_API;
using SIA_API.Models;

namespace SIA_API.Controllers
{
    [Route("api/label")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly SignInContext _context;

        public LabelController(SignInContext context)
        {
            _context = context;
        }

        [HttpGet("labels")]
        public async Task<ActionResult<IEnumerable<Label>>> GetLabel()
        {
            return await _context.Label
                .Include(l => l.Class)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Label>> GetLabel(int id)
        {
            var label = await _context.Label.FindAsync(id);

            if (label == null)
            {
                return NotFound();
            }

            return label;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabel(int id, Label label)
        {
            if (id != label.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(label).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabelExists(id))
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Label>> PostLabel(Label label)
        {
            _context.Label.Add(label);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LabelExists(label.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLabel", new { id = label.ClassID }, label);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Label>> DeleteLabel(int id)
        {
            var label = await _context.Label.FindAsync(id);
            if (label == null)
            {
                return NotFound();
            }

            _context.Label.Remove(label);
            await _context.SaveChangesAsync();

            return label;
        }

        private bool LabelExists(int id)
        {
            return _context.Label.Any(e => e.ClassID == id);
        }
    }
}
