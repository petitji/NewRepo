using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace NewspaperMailRegister.Models
{
    public class MailingListViewModel
    {
        //Converted to IPagedList which supports paging in mvc
        public IPagedList<NewspaperMailRegister.Models.MailingList> MailingLists { get; set; }
    }
}