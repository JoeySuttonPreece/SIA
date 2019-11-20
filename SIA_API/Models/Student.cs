using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_API.Models
{
    public class Student
    {
        //CREATE TABLE [dbo].[Student]
        //(
	       // [Barcode] NVARCHAR(11) NOT NULL,
	       // [Number] NVARCHAR(12) NOT NULL,
	       // [FirstName] NVARCHAR(50) NOT NULL,
	       // [LastName] NVARCHAR(100) NOT NULL,
	       // PRIMARY KEY (Barcode)
        //)

        public string Barcode { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Class Class { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Scan> Scans { get; set; }
    }
}
