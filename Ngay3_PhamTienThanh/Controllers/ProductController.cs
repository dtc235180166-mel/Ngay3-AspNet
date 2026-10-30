using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay3_PhamTienThanh.Models;
namespace Ngay3_PhamTienThanh.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(){id=1, name="T-Shirt", price=100, description="With cat picture on it!!", categoryId=1},
            new Product(){id=2, name="Jeans", price=200, description="Old Classical Jeans!!", categoryId=2},
            new Product(){id=3, name="Sneakers", price=200, description="Overated kind of shoe", categoryId=3},
        };
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var _product = products.FirstOrDefault(p => p.id == id);
            if (_product == null)
            {
                return NotFound();
            }
            return View(_product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                int newId = products.Any() ? products.Max(c => c.id) + 1 : 1;
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute]int id)
        {
            var product = products.FirstOrDefault(c => c.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            var ifExistingCategory = products.FirstOrDefault(c => c.id == product.id);
            if (ifExistingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ifExistingCategory.name = product.name;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete([FromForm]int id)
        {
            var product = products.FirstOrDefault(c => c.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
            public ActionResult ConfirmDelete(int id)
        {
            var product = products.FirstOrDefault(c => c.id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}