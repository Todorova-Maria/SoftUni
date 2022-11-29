using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.BanksInformation
{
    public partial class Account
    {
        public Account()
        {
            Logs = new HashSet<Log>();
            NotificationEmails = new HashSet<NotificationEmail>();
        }

        public int Id { get; set; }
        public int AccountHolderId { get; set; }
        public decimal? Balance { get; set; }

        public virtual AccountHolder AccountHolder { get; set; } = null!;
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<NotificationEmail> NotificationEmails { get; set; }
    }
}
