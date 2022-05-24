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
       
        [HttpPost]
        public IActionResult Post(IFormFile img,long id)
        {
            if (ModelState.IsValid)
            {
              
                var UploadedImage = new UploadedImage();

                using (MemoryStream ms = new MemoryStream())

                { // copy the file to memory stream 
                    img.CopyTo(ms);

                    // set the byte array 
                    UploadedImage.File = ms.ToArray();
                    UploadedImage.Name = img.FileName;
                    UploadedImage.Uploader = _appDbContext.UserProfiles.FirstOrDefault(p => p.Id == id);

                }
                if (UploadedImage.Uploader != null)
                {
                    _appDbContext.UploadedImages.Add(UploadedImage);
                    _appDbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("The uploader Id do not exist.");
                }
            }
            else
            {
                return BadRequest("Upload Failed");
            }
           
        }
    }
}
