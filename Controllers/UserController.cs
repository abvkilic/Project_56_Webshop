using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopMeisterBE_MASTER.Models;
using System.Linq;

namespace ShopMeisterBE_MASTER.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ShopMeister_Context _context;

        public UserController(ShopMeister_Context context)
        {
            _context = context;

            if (_context.User.Count() == 0)
            {
                _context.User.Add(new User { Id = 1 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _context.User.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.User.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var user = _context.User.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = item.FirstName;
            user.LastName = item.LastName;

            _context.User.Update(user);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var newuser = _context.User.FirstOrDefault(t => t.Id == id);
            if (newuser == null)
            {
                return NotFound();
            }

            _context.User.Remove(newuser);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}