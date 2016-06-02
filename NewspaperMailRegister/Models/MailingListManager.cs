using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewspaperMailRegister.Models
{
    public class MailingListManager
    {
        public static List<MailingList> GetAll()
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                var mails = context.Mails.ToList();
                return mails;
            }
        }

        public static MailingList GetByID(int? id)
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                var mail = context.Mails.Where(x => x.ID == id).First();
                return mail;
            }
        }

        public static void Add(string name, string email)
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                var mail = new MailingList()
                {
                    Name = name,
                    Email = email
                };

                context.Mails.Add(mail);
                context.SaveChanges();
            }
        }

        public static void Add(MailingList mailingList)
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                context.Mails.Add(mailingList);
                context.SaveChanges();
            }
        }

        public static void Edit(int id, string name, string email)
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                var mail = context.Mails.Where(x => x.ID == id).First();
                mail.Name = name;
                mail.Email = email;

                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (MailingListEntities context = new MailingListEntities())
            {
                var mail = context.Mails.Where(x => x.ID == id).First();
                context.Mails.Remove(mail);
                context.SaveChanges();
            }
        }
    }
}