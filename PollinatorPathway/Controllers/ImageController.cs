using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PollinatorPathway.Areas.Identity.Data;
using PollinatorPathway.Data;
using PollinatorPathway.Model;
using PollinatorPathway.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PollinatorPathway.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class ImageController : ControllerBase
    {
        private static IWebHostEnvironment _webHost;
        private readonly AppDbContext _appDbContext;
        public ImageController(IWebHostEnvironment webHost, AppDbContext appDbContext)
        {
            _webHost = webHost;
            _appDbContext = appDbContext;
        }
        //[HttpPost]
        //[Route("upload")]
        //public async Task<string> Upload([FromForm] UploadedImage obj){
        //    if(obj.File.Length > 0)
        //    {
        //        try
        //        {
        //            if(!Directory.Exists(_webHost.WebRootPath + "\\Images\\"))
        //            {
        //                Directory.CreateDirectory(_webHost.WebRootPath + "\\Images\\");
        //            }
        //            using (FileStream filestream = System.IO.File.Create(_webHost.WebRootPath + "\\Images\\" + obj.File.FileName))
        //            {
        //                obj.File.CopyTo(filestream);
        //                filestream.Flush();
        //                return "\\Images\\" + obj.File.FileName;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    else
        //    {
        //        return "Upload Failed";
        //    }
        //}
        [HttpPost]
        public IActionResult Post(IFormFile img)
        {
            if (ModelState.IsValid)
            {
              
                var UploadedImage = new UploadedImage();

                using (MemoryStream ms = new MemoryStream())

                { // copy the file to memory stream 
                    img.CopyToAsync(ms);

                    // set the byte array 
                    UploadedImage.File = ms.ToArray();
                    UploadedImage.Name = img.FileName;

                }
                _appDbContext.UploadedImages.Add(UploadedImage);
                _appDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Hi User");
            }
           
        }
    }
}
