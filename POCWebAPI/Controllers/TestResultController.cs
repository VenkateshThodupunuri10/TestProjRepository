using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POCWebAPI.DBConnectionLayer;
using POCWebAPI.Models;

namespace POCWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestResultController : ControllerBase
    {
        private ApplicationDBContext _db;
        public TestResultController(ApplicationDBContext dbContext) {
            _db = dbContext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet(Name = "GetAllResultSets")]
        public IActionResult GetAllResultSets() {
            List<FBResult> fbResult = new List<FBResult>();
            fbResult = _db.FBResults.ToList();
            //if (fbResult == null || fbResult.Count == 0)
            //{
            //    TempData["ErrorMessage"] = "No Records to show";
            //}
            return Ok(fbResult);
        }
    }
}
