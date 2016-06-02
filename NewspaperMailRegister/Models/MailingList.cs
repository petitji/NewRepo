using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewspaperMailRegister.Models
{
    public class MailingList
    {
        public int ID { get; set; }

        [DisplayName("Name: ")]
        public string Name { get; set; }

        [DisplayName("Email Address: ")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

    }
}