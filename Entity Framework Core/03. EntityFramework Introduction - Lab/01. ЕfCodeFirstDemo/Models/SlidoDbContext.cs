using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._ЕfCodeFirstDemo.Models
{


    public class SlidoDbContext : DbContext
    {
        public SlidoDbContext()
        {

        }

        public SlidoDbContext(DbContextOptions dbContextOptions) 
            :base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-9EQRASUR\\SQLEXPRESS;Integrated Security=true;Database=Slido");
            }
        }
        public DbSet<Comment> Comment { get; set; } 
        public DbSet<Question> Qusetion{ get; set; } 


    }
}
