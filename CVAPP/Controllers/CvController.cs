using CVAPP.Data;
using CVAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVAPP.Controllers
{
    [Authorize]
    public class CvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CvController(ApplicationDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {
            return View(_context.Cv.Include(r=>r.User).ToList());
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Create()
        {
            ViewData["Users"] = _context.User.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Cv cv)
        {
            try
            {
                _context.Cv.Add(cv);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
               
            }

          return View(cv);
        }

        
        public IActionResult Edit(int id)
        {

            var cv=_context.Cv.FirstOrDefault(r=>r.Id== id);
            if (cv==null)
            {
                return NotFound();

            }
            ViewData["Users"] = _context.User.ToList();
            return View(cv);
        }

        [HttpPost]
        public IActionResult Êdit(Cv cv)
        {
            try
            {
                _context.Cv.Update(cv);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;

            }

            return View(cv);

           
        }
     

        public IActionResult Detail(int id)
        {
            
            var cv=_context.Cv.Include(r=>r.User).Include(r=>r.Experience).Include(r=>r.Education).FirstOrDefault(e=>e.Id==id);

            if (cv==null)
            {
                return NotFound();
            }

            return View(cv);
        }

      
    }
}
