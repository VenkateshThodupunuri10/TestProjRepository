using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POCWebApp.DataLayer;
using POCWebApp.Models;
using System.Diagnostics;

namespace POCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public IActionResult Index()
        {
            List<FBResult> fbResult = new List<FBResult>();
            try
            {
                var sessionUserName = HttpContext.Session.GetString("UserName");
                

                if (!string.IsNullOrEmpty(sessionUserName))
                {
                    fbResult = _db.FBResults.ToList();
                    if (fbResult == null || fbResult.Count == 0)
                    {
                        TempData["ErrorMessage"] = "No Records to show";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Please Login";
                    return RedirectToAction("LoginTest", "Login");
                }
            }catch(Exception ex) { }
            return View(fbResult);

        }
        public IActionResult Privacy()
        {
            List<FBResult> fbResult = new List<FBResult>();
            var sessionUserName = HttpContext.Session.GetString("UserName");
            try
            {
                if (!string.IsNullOrEmpty(sessionUserName))
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:81/");
                        //HTTP GET
                        var responseTask = client.GetAsync("testresult");
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            if (!string.IsNullOrEmpty(readTask.Result))
                            {
                                fbResult = JsonConvert.DeserializeObject<List<FBResult>>(readTask.Result);
                            }
                            else //web api sent error response 
                            {
                                TempData["ErrorMessage"] = "No Records to show";
                            }
                        }
                        else //web api sent error response 
                        {
                            TempData["ErrorMessage"] = "No Records to show";
                        }
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Please Login";
                    return RedirectToAction("LoginTest", "Login");
                }
            }
            catch (Exception ex)
            {
            }
            return View(fbResult);
        }

        public IActionResult Logout() {
            try
            {
                TempData["ErrorMessage"] = "Logged out Successfully";
                HttpContext.Session.SetString("UserName", string.Empty);
            }
            catch (Exception ex) { }
            return RedirectToAction("LoginTest", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}