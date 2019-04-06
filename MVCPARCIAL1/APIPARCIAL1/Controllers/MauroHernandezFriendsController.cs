using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIPARCIAL1.Models;

namespace APIPARCIAL1.Controllers
{
    public class MauroHernandezFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/MauroHernandezFriends
        public IQueryable<MauroHernandezFriend> GetMauroHernandezFriends()
        {
            return db.MauroHernandezFriends;
        }

        // GET: api/MauroHernandezFriends/5
        [ResponseType(typeof(MauroHernandezFriend))]
        public IHttpActionResult GetMauroHernandezFriend(int id)
        {
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            if (mauroHernandezFriend == null)
            {
                return NotFound();
            }

            return Ok(mauroHernandezFriend);
        }

        // PUT: api/MauroHernandezFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMauroHernandezFriend(int id, MauroHernandezFriend mauroHernandezFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mauroHernandezFriend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(mauroHernandezFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauroHernandezFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MauroHernandezFriends
        [ResponseType(typeof(MauroHernandezFriend))]
        public IHttpActionResult PostMauroHernandezFriend(MauroHernandezFriend mauroHernandezFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MauroHernandezFriends.Add(mauroHernandezFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mauroHernandezFriend.FriendId }, mauroHernandezFriend);
        }

        // DELETE: api/MauroHernandezFriends/5
        [ResponseType(typeof(MauroHernandezFriend))]
        public IHttpActionResult DeleteMauroHernandezFriend(int id)
        {
            MauroHernandezFriend mauroHernandezFriend = db.MauroHernandezFriends.Find(id);
            if (mauroHernandezFriend == null)
            {
                return NotFound();
            }

            db.MauroHernandezFriends.Remove(mauroHernandezFriend);
            db.SaveChanges();

            return Ok(mauroHernandezFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MauroHernandezFriendExists(int id)
        {
            return db.MauroHernandezFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}