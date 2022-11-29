using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._ЕfCodeFirstDemo.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(400)]
        public string Content { get; set; }

        public DateTime CreateOn { get; set; }

        public string Author { get; set; }
        public int  Number { get; set; }

    }
}
