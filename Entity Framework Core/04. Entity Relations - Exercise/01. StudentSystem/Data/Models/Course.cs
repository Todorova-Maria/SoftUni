using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.StudentsEnrolled = new HashSet<Student>();
            this.Resources = new HashSet<Resource>(); 
        }
        public int CourseId { get; set; } 

        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<Student> StudentsEnrolled { get; set; }
        public ICollection<Resource> Resources { get; set; }

    }
}
