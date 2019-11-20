using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_API.Models
{
    public class Label
    {
        //CREATE TABLE [dbo].[Label]
        //(
	       // [ClassID] INT NOT NULL,
	       // [Name] NVARCHAR(50),

	       // PRIMARY KEY (ClassID, Name),
	       // FOREIGN KEY (ClassID) REFERENCES [Class]
        //)

        public int ClassID { get; set; }
        public string Name { get; set; }

        public virtual Class Class { get; set; }
    }
}
