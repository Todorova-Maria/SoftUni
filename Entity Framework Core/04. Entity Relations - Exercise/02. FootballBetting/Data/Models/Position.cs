using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>(); 
        }
        public int PositionId { get; set; }

        public string PositionName { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
