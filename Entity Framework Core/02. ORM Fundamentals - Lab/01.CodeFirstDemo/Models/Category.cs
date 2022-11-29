
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CodeFirstDemo.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
    }
}
