using _04._EntityRelations___Lab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _04._EntityRelations___Lab
{
    public class Employee
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(35)]
        public string LastName { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public decimal? Salary{ get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Address")]
        public  int? AddressId { get; set; }
        public Address Address { get; set; }
        public int? BirthTownId { get; set; }

        [InverseProperty(nameof(Town.NativeCitizens))]

        public Town BirthTown { get; set; }

        public int? WorkplaceTownId { get; set; }

        [InverseProperty(nameof(Town.WorkplaceCitizens))]
        public Town WorkplaceTown { get; set; }



    }
}
