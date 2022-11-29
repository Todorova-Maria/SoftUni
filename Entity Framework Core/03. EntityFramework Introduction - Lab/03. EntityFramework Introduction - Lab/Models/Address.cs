﻿using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.Models
{
    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }
        public string AddressText { get; set; } = null!;
        public int? TownId { get; set; }

        public virtual Town? Town { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
