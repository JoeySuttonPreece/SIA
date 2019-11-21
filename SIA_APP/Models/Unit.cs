using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Unit
    {
        //CREATE TABLE [dbo].[Unit]
        //(
	       // [ClusterID] INT NOT NULL,
	       // [Code] NVARCHAR(100) NOT NULL,
	       // PRIMARY KEY (ClusterID, Code),
	       // FOREIGN KEY (ClusterID) REFERENCES Cluster
        //)

        public int ClusterID { get; set; }
        public string Code { get; set; }

        public virtual Cluster Cluster { get; set; }
    }
}
