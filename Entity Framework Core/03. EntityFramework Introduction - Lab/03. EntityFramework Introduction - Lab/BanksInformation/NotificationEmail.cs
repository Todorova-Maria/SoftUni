using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.BanksInformation
{
    public partial class NotificationEmail
    {
        public int Id { get; set; }
        public int? Recipient { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public virtual Account? RecipientNavigation { get; set; }
    }
}
