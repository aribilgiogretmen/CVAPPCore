using CVAPP.Data;
using CVAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CVAPP.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {
            return View(_context.User.ToList());
        }

        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {

            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

            }

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();

            }


            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {

            try
            {
                _context.User.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

            }

            return View(user);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {

            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
               _context.User.Remove(user);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}
