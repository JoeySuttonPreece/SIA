using System;
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
        public async Task<ActionResult<IEnumerable<Scan>>> GetScans([FromQuery] string secret)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            return await _context.Scan
                .Include(s => s.Class)
                .Include(s => s.Student)
                .ToListAsync();
        }

        [HttpGet("~/api/scans/class/{id}")]
        public async Task<ActionResult<IEnumerable<ScanOutMap>>> GetScansForClass([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            List<Scan> results = _context.Scan
                .Include(s => s.Student)
                .Where(s => s.ClassID == id)
                .ToList();

            List<ScanOutMap> scanOutMaps = new List<ScanOutMap>();

            for (int i = 0; i < results.Count(); i++)
            {
                scanOutMaps.Add(new ScanOutMap() {
                    Barcode = results[i].Barcode,
                    Class = results[i].Class,
                    ClassID = results[i].ClassID,
                    Lat = results[i].Lat,
                    Long = results[i].Long,
                    Time = results[i].Time,
                    Student = results[i].Student,
                    Status = "SignedIn"
                });
            }

            return scanOutMaps;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scan>> GetScan([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

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
        public async Task<IActionResult> PutScan([FromQuery] string secret, int id, Scan scan)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

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
        [HttpPost("~/attendance")]
        public async Task<ActionResult<ScanResponse>> PostScan(ScanInMap attendance)
        {

            Scan scan = new Scan() {
                Barcode = attendance.Barcode,
                Time = attendance.Time,
                ClassID = attendance.ClassId,
                Lat = attendance.Location.Latitude,
                Long = attendance.Location.Longitude
            };

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

            return new ScanResponse() { ActionPerformed = "SignedIn", FirstName = "Joey" /*scan.Student.FirstName*/ };
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scan>> DeleteScan([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

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
