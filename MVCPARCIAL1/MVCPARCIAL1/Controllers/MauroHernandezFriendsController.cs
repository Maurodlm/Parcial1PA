using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPARCIAL1.Models;

namespace MVCPARCIAL1.Controllers
{
    public class MauroHernandezFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: MauroHernandezFriends
        public ActionResult Index()
        {
            return View(db.MauroHernandezFriends.ToList());
        }

        // GET: MauroHernandezFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            if (mauroHernandezFriend == null)
            {
                return HttpNotFound();
            }
            return View(mauroHernandezFriend);
        }

        // GET: MauroHernandezFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MauroHernandezFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,FullName,TypeFriend,Nickname,DateTime,Friend")] MauroHernandezFriend mauroHernandezFriend)
        {
            if (ModelState.IsValid)
            {
                db.MauroHernandezFriends.Add(mauroHernandezFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mauroHernandezFriend);
        }

        // GET: MauroHernandezFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            if (mauroHernandezFriend == null)
            {
                return HttpNotFound();
            }
            return View(mauroHernandezFriend);
        }

        // POST: MauroHernandezFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,FullName,TypeFriend,Nickname,DateTime,Friend")] MauroHernandezFriend mauroHernandezFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mauroHernandezFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mauroHernandezFriend);
        }

        // GET: MauroHernandezFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            if (mauroHernandezFriend == null)
            {
                return HttpNotFound();
            }
            return View(mauroHernandezFriend);
        }

        // POST: MauroHernandezFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            db.MauroHernandezFriends.Remove(mauroHernandezFriend);
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
