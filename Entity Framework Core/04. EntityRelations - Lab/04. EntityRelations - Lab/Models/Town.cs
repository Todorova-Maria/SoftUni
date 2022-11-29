using System;
using System.Collections.Generic;
using System.Text;

namespace _04._EntityRelations___Lab.Models
{
    public class Town
    {
        public Town()
        {
            this.NativeCitizens = new HashSet<Employee>();
            this.WorkplaceCitizens = new HashSet<Employee>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> NativeCitizens { get; set; }
        public ICollection<Employee> WorkplaceCitizens { get; set; }

    }
}
