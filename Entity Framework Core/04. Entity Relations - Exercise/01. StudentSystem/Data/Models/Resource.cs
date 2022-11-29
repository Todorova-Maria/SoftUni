using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId{ get; set; }

        [MaxLength(50)]
        [Required]
        public string Name{ get; set; }

        [Column(TypeName = "varchar(2048)")]
        [Required]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
