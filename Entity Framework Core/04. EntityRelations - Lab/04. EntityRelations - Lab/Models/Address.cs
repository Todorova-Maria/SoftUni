using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _04._EntityRelations___Lab.Models
{
    public class Address
    {
        public int Id{ get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set;}
    }
}
