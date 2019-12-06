using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP.Models
{
    public class Label
    {
        public int ClassID { get; set; }
        public string Name { get; set; }

        public Class Class { get; set; }
    }
}
