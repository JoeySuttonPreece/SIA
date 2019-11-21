using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Enrollment
    {
        //   [ClassID] INT NOT NULL,
	       // [Barcode] NVARCHAR(11),

	       // PRIMARY KEY(ClassID, Barcode),
	       // FOREIGN KEY(ClassID) REFERENCES[Class],
	       // FOREIGN KEY(Barcode) REFERENCES Student
        //)

        public int ClassID { get; set; }
        public string Barcode { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
