using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string name { get; set; }
    }
}
