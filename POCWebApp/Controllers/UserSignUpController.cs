using Microsoft.AspNetCore.Mvc;
using POCWebApp.DataLayer;
using POCWebApp.Models;

namespace POCWebApp.Controllers
{
    public class UserSignUpController : Controller
    {
        private ApplicationDBContext _db;

        public UserSignUpController(ApplicationDBContext dbContext) {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            var sessionUserName = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(sessionUserName))
            {
                return View();
            }
            else
            {
                TempData["ErrorMessage"] = "Please Login";
                return RedirectToAction("LoginTest", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(Users obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Users.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                }
            }
            return View("Index",obj);

            
        }
    }
}
