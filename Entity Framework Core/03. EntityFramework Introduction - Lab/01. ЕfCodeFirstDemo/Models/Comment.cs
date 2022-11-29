using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._ЕfCodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "IX_QuestionId123")]
    public class Comment
    {
        public  int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public  string Content { get; set; }

        public int MyProperty { get; set; }

        public int QuestionId { get; set; }

        public Question Question  { get; set; }
        public string Author { get; set; }
        public int number { get; set; }
    }
}
