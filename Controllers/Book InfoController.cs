using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOOK_LIBRARY.Models;

namespace BOOK_LIBRARY.Controllers
{
    public class Book_InfoController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: Book_Info
        public ActionResult Index(string searchString)
        {
            var book_Infos = from c in db.Book_Infos
                             select c;


            if (!String.IsNullOrEmpty(searchString))
            {
                book_Infos = book_Infos.Where(s => s.Title.Contains(searchString));

            }
            
            return View(db.Book_Infos.ToList());
        }

        // GET: Book_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Info book_Info = db.Book_Infos.Find(id);
            if (book_Info == null)
            {
                return HttpNotFound();
            }
            return View(book_Info);
        }

        // GET: Book_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,genre,Plot,page,Rating")] Book_Info book_Info)
        {
            if (ModelState.IsValid)
            {
                db.Book_Infos.Add(book_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book_Info);
        }

        // GET: Book_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Info book_Info = db.Book_Infos.Find(id);
            if (book_Info == null)
            {
                return HttpNotFound();
            }
            return View(book_Info);
        }

        // POST: Book_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,genre,Plot,page,Rating")] Book_Info book_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book_Info);
        }

        // GET: Book_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Info book_Info = db.Book_Infos.Find(id);
            if (book_Info == null)
            {
                return HttpNotFound();
            }
            return View(book_Info);
        }

        // POST: Book_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Info book_Info = db.Book_Infos.Find(id);
            db.Book_Infos.Remove(book_Info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
