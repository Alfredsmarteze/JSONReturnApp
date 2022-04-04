using JSONReturnApp.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System.Diagnostics;

namespace JSONReturnApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sample()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUsersDetail(string usersJson)
        {
            var js = new JavaScriptSerializer();
            UserModel[] user = js.Deserialize<UserModel[]>(usersJson);
            return Json("User Details are updated");
        }

        private List<UserModel> GetUser()
        {
            var usersList = new List<UserModel>
            {
             new UserModel{
             UserId = 1,
             UserName="Smart",
             Company="Smartcode"
             },
             new UserModel{
             UserId = 1,
             UserName="Eze",
             Company="Ezecode"
             },
             new UserModel {
             UserId = 1,
             UserName="SmartEze",
             Company="Smartcode"
             }
           };
            return usersList;
        }
        public JsonResult GetUsersData()
        { 
         var users= GetUser();
            return Json(users);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}