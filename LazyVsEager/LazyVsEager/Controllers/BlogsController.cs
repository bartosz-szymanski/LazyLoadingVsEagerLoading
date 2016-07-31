using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LazyVsEager.Models;

namespace LazyVsEager.Controllers
{
    public class BlogsController : ApiController
    {
        private LazyVsEagerContext db = new LazyVsEagerContext();

        // GET: api/Blogs
        public IQueryable<Blog> GetBlogs()
        {
            return db.Blogs
                .Include(b => b.Author);
        }

        // GET: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> GetBlog(long id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            var blogs = db.Blogs.ToList();
            var author = blogs[0].Author;

            return Ok(blog.Author);
        }

        // PUT: api/Blogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBlog(long id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog.Id)
            {
                return BadRequest();
            }

            db.Entry(blog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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

        // POST: api/Blogs
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> PostBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Blogs.Add(blog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = blog.Id }, blog);
        }

        // DELETE: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> DeleteBlog(long id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();

            return Ok(blog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(long id)
        {
            return db.Blogs.Count(e => e.Id == id) > 0;
        }
    }
}