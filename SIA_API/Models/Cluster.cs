using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_API.Models
{
    public class Cluster
    {
        //CREATE TABLE[dbo].[Cluster]
        //(

        //   [ClusterID] INT NOT NULL,
	       // [Name] NVARCHAR(100) NOT NULL,
        //    PRIMARY KEY(ClusterID)
        //)

        public int ClusterID { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
