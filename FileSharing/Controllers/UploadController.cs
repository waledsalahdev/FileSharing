using FileSharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileSharing.Controllers
{
    [Authorize]
    public class UploadsController : Controller
    {

        [HttpGet]
       public IActionResult Creat()
        {
            return View("Uploads");
        }

        [HttpPost]
        public IActionResult Creat(UploadsVM model)
        {
           
            return View("Uploads",model);
        }



    }
}
