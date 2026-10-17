
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                ShortDescription = "A laptop for work, study and everyday use.",
                Description = "Suitable for studying, browsing the internet and office work.",
                Price = 45000,
                Category = "Electronics",
                Stock = 10,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSaZzY4HOjzBwiROTqIdQsG8G-Yne6q2iJRQNJl3iunZg&s=10"
            },
            new Product
            {
                Id = 2,
                Name = "Headphones",
                ShortDescription = "Headphones for music and everyday listening.",
                Description = "Useful for music, online classes and phone calls.",
                Price = 1500,
                Category = "Accessories",
                Stock = 25,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSsuHAJCW-qz5sZZQS8fORe9zNEXzjZm9WTJerrJwOx1A&s=10"
            },
            new Product
            {
                Id = 3,
                Name = "Notebook",
                ShortDescription = "A notebook for notes and writing.",
                Description = "Useful for lecture notes, lists and everyday writing.",
                Price = 100,
                Category = "Stationery",
                Stock = 50,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqv-2YaSjH9FXJDAYmBeFwLnfDHWI9vmfHBzQ_wH8PlNCyVuzOYT8OVhM&s=10"
            }
        };

        private static int nextId = 4;

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            product.Id = nextId++;
            products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(updatedProduct);

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.ShortDescription = updatedProduct.ShortDescription;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Category = updatedProduct.Category;
            product.Stock = updatedProduct.Stock;
            product.ImageUrl = updatedProduct.ImageUrl;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
