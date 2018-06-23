using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopMeisterBE_MASTER.Models;
using System.Linq;

namespace ShopMeisterBE_MASTER.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ShopMeister_Context _context;

        public ProductController(ShopMeister_Context context)
        {
            _context = context;

            if (_context.Product.Count() == 0)
            {
                _context.Product.Add(new Product { Id  = 1 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.Product.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Product.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Product item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var newproduct = _context.Product.FirstOrDefault(t => t.Id == id);
            if (newproduct == null)
            {
                return NotFound();
            }

            newproduct.Title = item.Title;
            newproduct.Id = item.Id;
            newproduct.categorie = item.categorie;
            newproduct.ImgLink = item.ImgLink;
            newproduct.Info = item.Info;
            newproduct.Price = item.Price;

            _context.Product.Update(newproduct);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var newproduct = _context.Product.FirstOrDefault(t => t.Id == id);
            if (newproduct == null)
            {
                return NotFound();
            }

            _context.Product.Remove(newproduct);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult CreateOne(Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            item.Id= 10 ;
            item.Info = "NEW";
            item.Price = 300;
            item.Title = "test";
            _context.Product.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = item.Id }, item);
        }

    }
}