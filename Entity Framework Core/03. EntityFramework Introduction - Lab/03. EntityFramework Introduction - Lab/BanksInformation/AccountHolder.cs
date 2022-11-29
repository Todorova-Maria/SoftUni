using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.BanksInformation
{
    public partial class AccountHolder
    {
        public AccountHolder()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Ssn { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
