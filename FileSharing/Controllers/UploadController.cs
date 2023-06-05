using FileSharing.Data;
using FileSharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Security.Claims;

namespace FileSharing.Controllers
{
    [Authorize]
    public class UploadsController : Controller

    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment env;
        private readonly IToastNotification _notify;

        public UploadsController(AppDbContext context,IWebHostEnvironment env, IToastNotification Notify)
        {
            this._db = context;
            this.env = env;
            _notify = Notify;
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

            var res = _db.Uploads.Where(u => u.UserId == Userid).OrderBy(u=>u.UploadDate).Select(u => new UploadVm
            {
                FileName = u.FileName,
                Originalname = u.Originalname,
                Size = u.Size,
                UploadDate = u.UploadDate,
                ContentType = u.ContentType,
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
                // herw we find path of wwwwroot
                var root = env.WebRootPath;
                // here Compine  path + userfiles + filename  
                var path =Path.Combine(root, "UserFiles", filename);

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
                _notify.AddSuccessToastMessage("File Added Sucessfuly");
                return RedirectToAction("Index");
                //var uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UserFiles");
                //var stream= new FileStream(uploadpath, FileMode.Open,FileAccess.Read);
                //inputupload.File.CopyToAsync(stream);
            }
           
            return View("Uploads", inputupload);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string? id) 
        {
            if (id != null)
            {
                var res = await _db.Uploads.SingleOrDefaultAsync(s=>s.FileName==id);
             if (res is not null)
                {
                   _db.Uploads.Remove(res);
                    await _db.SaveChangesAsync();
                    var root = env.WebRootPath;
                    var path = Path.Combine(root, "UserFiles", id);
                    var fi =new FileInfo(path);
                    if (fi.Exists)
                    {
                        System.IO.File.Delete(path);

                    }
                    _notify?.AddSuccessToastMessage("File Deleted Sucsessfuly");
                    return Ok();

                }
                else
                    return NotFound();

            }



             return NotFound();


        }




    }
}
