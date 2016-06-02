using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewspaperMailRegister.Models;
using PagedList;

namespace NewspaperMailRegister.Controllers
{
    public class MailingListsController : Controller
    {
        private const int PAGE_SIZE = 10;

        [HttpGet]
        public ActionResult List(int? page, string sortOrder, string searchString)
        {
            MailingListViewModel model = new MailingListViewModel();

            //Paging the list of mailing lists.
            int pageSize = PAGE_SIZE;
            int pageNumber = (page ?? 1);
            var mails = MailingListManager.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                mails = mails.Where(s => s.Email.Contains(searchString)).ToList();
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : String.Empty;
            ViewBag.EmailSortParam = sortOrder == "Email" ? "email_desc" : "Email";

            switch (sortOrder)
            {
                case "name_desc":
                    mails = mails.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Email":
                    mails = mails.OrderBy(s => s.Email).ToList();
                    break;
                case "email_desc":
                    mails = mails.OrderByDescending(s => s.Email).ToList();
                    break;
                default:
                    mails = mails.OrderBy(s => s.Name).ToList();
                    break;
            }

            model.MailingLists = mails.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MailingList mailingList = MailingListManager.GetByID(id);
            if (mailingList == null)
            {
                return HttpNotFound();
            }

            return View(mailingList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email")] MailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                MailingListManager.Add(mailingList);
                return RedirectToAction("CreateDone");
            }

            return View(mailingList);
        }

        [HttpGet]
        public ActionResult CreateDone()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MailingList mailingList = MailingListManager.GetByID(id);

            if (mailingList == null)
            {
                return HttpNotFound();
            }

            return View(mailingList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email")] MailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                MailingListManager.Edit(mailingList.ID, mailingList.Name, mailingList.Email);
                return RedirectToAction("List");
            }

            return View(mailingList);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MailingList mailingList = MailingListManager.GetByID(id);

            if (mailingList == null)
            {
                return HttpNotFound();
            }

            return View(mailingList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailingListManager.Delete(id);
            return RedirectToAction("List");
        }

    }
}
