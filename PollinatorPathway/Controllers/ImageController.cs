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
         public ImageController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<string> Upload([FromForm] UploadedImage obj){
            if(obj.File.Length > 0)
            {
                try
                {
                    if(!Directory.Exists(_webHost.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHost.WebRootPath + "\\Images\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHost.WebRootPath + "\\Images\\" + obj.File.FileName))
                    {
                        obj.File.CopyTo(filestream);
                        filestream.Flush();
                        return "\\Images\\" + obj.File.FileName;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
