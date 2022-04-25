using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Areas.Identity.Data;
using PollinatorPathway.Data;
using PollinatorPathway.Model;
using PollinatorPathway.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PollinatorPathway.Controllers
{
    public class ImageController : Controller
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly AppDbContext _context;
            private IHostingEnvironment _hostingEnvironment;
            public UserController(AppDbContext context, IHostingEnvironment environment)
            {
                _context = context;
                _hostingEnvironment = environment ?? throw new ArgumentNullException(nameof(environment));
            }

            // Post: api/User/UpdateUserData
            [HttpPost]
            public async Task<IActionResult> UpdateUserData([FromForm] UploadedImage imageData)
            {
                Dictionary<string, string> resp = new Dictionary<string, string>();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    //getting user from the database
                    var userobj = await _context.UploadedImages.FindAsync(imageData.Id);
                    if (userobj != null)
                    {
                        //Get the complete folder path for storing the profile image inside it.  
                        var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/");

                        //checking if "images" folder exist or not exist then create it
                        if ((!Directory.Exists(path)))
                        {
                            Directory.CreateDirectory(path);
                        }
                        //getting file name and combine with path and save it
                        string filename = imageData.ImageUrl;
                        using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                        {
                            await imageData.File.CopyToAsync(fileStream);
                        }
                        //save folder path 
                        userobj.ImageUrl = "images/" + filename;
                        await _context.SaveChangesAsync();
                        //return api with response
                        resp.Add("status ", "success");
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(resp);
            }
        }

    }
}
