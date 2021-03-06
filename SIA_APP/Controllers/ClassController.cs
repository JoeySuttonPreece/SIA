﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIA_APP;
using SIA_APP.Models;

namespace SIA_APP.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly SignInContext _context;

        public ClassController(SignInContext context)
        {
            _context = context;
        }

        [HttpGet("~/api/classes")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses([FromQuery] string secret)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            return await _context.Class
                .Include(c => c.Cluster)
                .ToListAsync();
        }

        [HttpGet("~/classes")]
        public async Task<ActionResult<ClassesMap>> GetClassesQuindance()
        {
            List<Class> results = _context.Class
                .Include(c => c.Cluster)
                .Include(c => c.Labels)
                .ToList();

            return new ClassesMap() {
                Classes = results.Select(@class =>
                    new ClassMap()
                    {
                        ClassId = @class.ClassID,
                        Day = @class.Day,
                        StartTime = @class.StartTime,
                        EndTime = @class.EndTime,
                        Name = @class.Cluster.Name,
                        Labels = @class.Labels.Select(label => label.Name).ToList()
                    }
                ).ToList()
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            var @class = await _context.Class
                .Include(c => c.Cluster)
                .Include(c => c.Enrollments)
                .Include(c => c.Labels)
                .Include(c => c.Scans)
                .FirstAsync(c => c.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass([FromQuery] string secret, int id, Class @class)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            if (id != @class.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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
        public async Task<ActionResult<Class>> PostClass([FromQuery] string secret, Class @class)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            _context.Class.Add(@class);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.ClassID }, @class);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClass([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            var @class = await _context.Class.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();

            return @class;
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.ClassID == id);
        }
    }
}
