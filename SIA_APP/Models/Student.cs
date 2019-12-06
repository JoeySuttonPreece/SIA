using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Student
    {
        public string Barcode { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Scan> Scans { get; set; }
    }
}
