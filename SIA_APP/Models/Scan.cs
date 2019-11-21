using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIA_APP.Models
{
    public class Scan
    {
        //CREATE TABLE [dbo].[Scan]
        //(
	       // [Barcode] NVARCHAR(11) NOT NULL,
	       // [DateTime] DATETIME NOT NULL,
	       // [ClassID] INT NOT NULL,
	       // [Lat] DECIMAL(9, 6) NOT NULL,
	       // [Long] DECIMAL(9, 6) NOT NULL,
	       // PRIMARY KEY (Barcode, DateTime),
	       // FOREIGN KEY (ClassID) REFERENCES [Class],
	       // FOREIGN KEY (Barcode) REFERENCES Student
        //)

        public string Barcode { get; set; }
        [Column("DateTime")]
        public DateTime Time { get; set; }
        public int ClassID { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
