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
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly SignInContext _context;

        public EnrollmentController(SignInContext context)
        {
            _context = context;
        }

        [HttpGet("~/api/enrollments")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollment()
        {
            return await _context.Enrollment
                .Include(e => e.Class)
                .Include(e => e.Student)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, Enrollment enrollment)
        {
            if (id != enrollment.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
            _context.Enrollment.Add(enrollment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnrollmentExists(enrollment.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnrollment", new { id = enrollment.ClassID }, enrollment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Enrollment>> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.ClassID == id);
        }
    }
}
