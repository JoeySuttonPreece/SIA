﻿using System;
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
    [Route("api/scan")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly SignInContext _context;

        public ScanController(SignInContext context)
        {
            _context = context;
        }

        [HttpGet("~/api/scans")]
        public async Task<ActionResult<IEnumerable<Scan>>> GetScan()
        {
            return await _context.Scan
                .Include(s => s.Class)
                .Include(s => s.Student)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scan>> GetScan(int id)
        {
            var scan = await _context.Scan.FindAsync(id);

            if (scan == null)
            {
                return NotFound();
            }

            return scan;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScan(int id, Scan scan)
        {
            if (id != scan.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(scan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScanExists(id))
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
        public async Task<ActionResult<Scan>> PostScan(Scan scan)
        {
            _context.Scan.Add(scan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScanExists(scan.ClassID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScan", new { id = scan.ClassID }, scan);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scan>> DeleteScan(int id)
        {
            var scan = await _context.Scan.FindAsync(id);
            if (scan == null)
            {
                return NotFound();
            }

            _context.Scan.Remove(scan);
            await _context.SaveChangesAsync();

            return scan;
        }

        private bool ScanExists(int id)
        {
            return _context.Scan.Any(e => e.ClassID == id);
        }
    }
}
