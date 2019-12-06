using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Cluster
    {
        public int ClusterID { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
