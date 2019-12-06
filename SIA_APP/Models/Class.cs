using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public int ClusterID { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Cluster Cluster { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Label> Labels { get; set; }
        public ICollection<Scan> Scans { get; set; }
    }
}
