using System.Diagnostics;
using GA.XYZ.LeT.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace GA.XYZ.LeT.Site.Controllers {

    public class HomeController : Controller{

        public IActionResult Index(){
            return View();
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
