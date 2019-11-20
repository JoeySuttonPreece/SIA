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
        public async Task<ActionResult<IEnumerable<Cluster>>> GetCluster()
        {
            return await _context.Cluster
                .Include(i => i.Units)
                .ToListAsync();
        }

        // GET: api/Clusters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cluster>> GetCluster(int id)
        {
            var cluster = await _context.Cluster.FindAsync(id);

            if (cluster == null)
            {
                return NotFound();
            }

            return cluster;
        }

        // PUT: api/Clusters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCluster(int id, Cluster cluster)
        {
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

        // POST: api/Clusters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cluster>> PostCluster(Cluster cluster)
        {
            _context.Cluster.Add(cluster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCluster", new { id = cluster.ClusterID }, cluster);
        }

        // DELETE: api/Clusters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cluster>> DeleteCluster(int id)
        {
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
