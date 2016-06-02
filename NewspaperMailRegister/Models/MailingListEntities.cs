using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewspaperMailRegister.Models
{
    public class MailingListEntities : DbContext
    {
        public DbSet<MailingList> Mails { get; set; }
    }
}