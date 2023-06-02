using FileSharing.Data;
using FileSharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FileSharing.Controllers
{
    [Authorize]
    public class UploadsController : Controller

    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment env;

        public UploadsController(AppDbContext context,IWebHostEnvironment env)
        {
            this._db = context;
            this.env = env;
        }
        private string Userid
        { get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
        [HttpGet]
        public IActionResult Index()
        {

            var res = _db.Uploads.Where(u => u.UserId == Userid).Select(u => new UploadVm
            {
                Originalname=u.Originalname,
                Size=u.Size,
                UploadDate=u.UploadDate,
                ContentType=u.ContentType,
            });
            return View("IndexUploads",res);
        }

        [HttpGet]
       public IActionResult Creat()
        {
            return View("Uploads");
        }

        [HttpPost]
        public async Task<IActionResult> Creat(InputUpload inputupload)
        {
            if (ModelState.IsValid)
            {
                var  uniqename = Guid.NewGuid().ToString();
                var extentionfile = Path.GetExtension(inputupload.File.FileName);
                var filename = string.Concat(uniqename, extentionfile);
                var root = env.WebRootPath;
                var path=Path.Combine(root, "UserFiles", filename);

                using (var fs=System.IO.File.Create(path))
                {
                    await inputupload.File.CopyToAsync(fs);
                }
                await _db.Uploads.AddAsync(new Uploads
                {    
                    Originalname=inputupload.File.FileName,
                FileName = filename,
                Size=inputupload.File.Length,
                ContentType =inputupload.File.ContentType,
                UserId= Userid,
                UploadDate = DateTime.Now,



                });
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
                //var uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UserFiles");
                //var stream= new FileStream(uploadpath, FileMode.Open,FileAccess.Read);
                //inputupload.File.CopyToAsync(stream);
            }
           
            return View("Uploads", inputupload);
        }



    }
}
