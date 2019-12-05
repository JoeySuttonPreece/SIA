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
    [Route("api/cluster")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        private readonly SignInContext _context;

        public ClusterController(SignInContext context)
        {
            _context = context;
        }

        [HttpGet("~/api/clusters")]
        public async Task<ActionResult<IEnumerable<Cluster>>> GetCluster([FromQuery] string secret)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            return await _context.Cluster
                .ToListAsync();
            
            //return results.ConvertAll(result => new { result.ClusterID, result.Name });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cluster>> GetCluster([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            var cluster = await _context.Cluster
                .Include(c => c.Units)
                .Include(c => c.Classes)
                .FirstAsync(c => c.ClusterID == id);

            if (cluster == null)
            {
                return NotFound();
            }

            return cluster;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCluster([FromQuery] string secret, int id, Cluster cluster)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            if (id != cluster.ClusterID)
            {
                return BadRequest();
            }

            _context.Entry(cluster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClusterExists(id))
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
        public async Task<ActionResult<Cluster>> PostCluster([FromQuery] string secret, Cluster cluster)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            _context.Cluster.Add(cluster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCluster", new { id = cluster.ClusterID }, cluster);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cluster>> DeleteCluster([FromQuery] string secret, int id)
        {
            if (!AuthHelper.validate(secret))
            {
                return Unauthorized();
            }

            var cluster = await _context.Cluster.FindAsync(id);
            if (cluster == null)
            {
                return NotFound();
            }

            _context.Cluster.Remove(cluster);
            await _context.SaveChangesAsync();

            return cluster;
        }

        private bool ClusterExists(int id)
        {
            return _context.Cluster.Any(e => e.ClusterID == id);
        }
    }
}
