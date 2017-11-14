using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

using TimeTracker_ng4.Data;
using TimeTracker_ng4.Models;

namespace TimeTracker_ng4.Controllers.Api
{
    public class ToDosController : ApiController
    {
        private ToDoContext db = new ToDoContext();

        // GET: api/ToDos
        public IEnumerable GetToDos()
        {
            return db.ToDos.Where(p => !p.IsCompleted).OrderBy(p => p.Priority).ToList();
        }

        [Route("api/todos/all")]
        public IEnumerable GetAll()
        {
            var completed = db.ToDos.Where(p => p.IsCompleted).OrderBy(p => p.EndDate).ToList();
            var notDone = db.ToDos.Where(p => !p.IsCompleted).OrderBy(p => p.Priority).ToList();

            return notDone.Concat(completed).ToList();
        }
        // GET: api/ToDos/5
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult GetToDo(int id)
        {
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        // PUT: api/ToDos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDo(int id, ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.Id)
            {
                return BadRequest();
            }
            if (toDo.IsCompleted)
            {
                toDo.EndDate = DateTime.Now;
            }
            db.Entry(toDo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
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


        [HttpPut]
        [Route("api/todos/start")]
        [ResponseType(typeof(void))]
        public IHttpActionResult StartToDo(int id, ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var todo = db.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();

            }
            todo.StartDate = DateTime.Now;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
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


        // POST: api/ToDos
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult PostToDo(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDos.Add(toDo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDo.Id }, toDo);
        }

        // DELETE: api/ToDos/5
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult DeleteToDo(int id)
        {
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            db.ToDos.Remove(toDo);
            db.SaveChanges();

            return Ok(toDo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoExists(int id)
        {
            return db.ToDos.Count(e => e.Id == id) > 0;
        }
    }
}