using Microsoft.AspNetCore.Mvc;
using POCWebApp.DataLayer;
using POCWebApp.Models;

namespace POCWebApp.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDBContext _db;

        public LoginController(ApplicationDBContext dbContext)
        {
            _db = dbContext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


        public IActionResult LoginTest()
        {
            return View();
        }

        public IActionResult UserSignUp()
        {
            return View();
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
                    TempData["ErrorMessage"] = "User Created Successfully, Please Login";
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                return View("UserSignUp", obj);
            }

            return RedirectToAction("LoginTest", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserLogin(Users obj) {
            if (!string.IsNullOrEmpty(obj.Email) && !string.IsNullOrEmpty(obj.Password)) {
                Users? user = _db.Users.Where(x => x.Email == obj.Email && x.Password == obj.Password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", user.Email);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    TempData["ErrorMessage"] = "Login Failed, Please enter valid details";
                    return View("LoginTest", obj);
                }
                
            }
            TempData["ErrorMessage"] = "Login Failed, Please enter valid details";
            return View("LoginTest", obj);
        }
    }
}
