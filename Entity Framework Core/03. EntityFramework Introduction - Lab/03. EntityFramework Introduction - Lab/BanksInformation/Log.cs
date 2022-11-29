using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.BanksInformation
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int? AccountId { get; set; }
        public decimal? OldSum { get; set; }
        public decimal? NewSum { get; set; }

        public virtual Account? Account { get; set; }
    }
}
