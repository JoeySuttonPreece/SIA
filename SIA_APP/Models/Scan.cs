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
        public string Barcode { get; set; }
        [Column("DateTime")]
        public DateTime Time { get; set; }
        public int ClassID { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public Class Class { get; set; }
        public Student Student { get; set; }
    }
}
