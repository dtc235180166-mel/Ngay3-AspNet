using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay3_PhamTienThanh.Models;
namespace Ngay3_PhamTienThanh.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category(){id=1, name="Category1"},
            new Category(){id=1, name="Category2"},
            new Category(){id=1, name="Category3"},
        };
        // GET: HomeController1
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var _category = categories.FirstOrDefault(c => c.id == id);
            if (_category==null)
            {
                return NotFound();
            }
            return View(_category);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                int newId = categories.Any() ? categories.Max(c => c.id) + 1 : 1;
                categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = categories.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var ifExistingCategory = categories.FirstOrDefault(c => c.id == category.id);
            if (ifExistingCategory == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                ifExistingCategory.name = category.name;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete([FromForm]int id)
        {
            var category = categories.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        
        // POST: HomeController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var category = categories.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
