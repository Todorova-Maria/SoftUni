﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>(); 
        }
        public int CountryId { get; set; } 
        public string CountryName { get; set; }
        public ICollection<Town> Towns { get; set; }
    }
}
