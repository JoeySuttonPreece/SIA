using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Enrollment
    {
        public int ClassID { get; set; }
        public string Barcode { get; set; }

        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
