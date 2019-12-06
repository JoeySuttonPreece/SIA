using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Unit
    {
        public int ClusterID { get; set; }
        public string Code { get; set; }

        public Cluster Cluster { get; set; }
    }
}
