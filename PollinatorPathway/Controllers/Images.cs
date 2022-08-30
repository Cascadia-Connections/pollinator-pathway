using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollinatorPathway.Data;
using PollinatorPathway.Model;
using PollinatorPathway.Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollinatorPathway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Images : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public Images(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UploadedImage> images = _appDbContext.UploadedImages.Include(u => u.Uploader);
            return Ok(images);
        }


        // GET: ImageAPI/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id > 0)
            {
                IEnumerable<UploadedImage> userImages = _appDbContext.UploadedImages.Include(u => u.Uploader)
                    .Where(u => u.Uploader.Id == id);

                if (userImages.Any())
                {
                    return Ok(userImages);
                }

                else return Problem("No Such Image");


            }
            else return Problem("Invalid Id: Id's must be greater than 0");
        }


        // POST api/<Images>
        [HttpPost]
        public void Post([FromBody] object image) //does pass a string argument in JSON FORMATTING (object obtain) ---! The JSON object from the body is not being passed to the method
        {
            //Deserializing is required due to lack of internal support for Byte[].

            string img = image.ToString(); //Successfully converts the image object to a JSON string with markup
            UploadedImage addDB = (UploadedImage)JSONDeserializer.Deserialize<UploadedImage>(img); // Successfully converts JSON String to Uploaded Image object.

            UserProfile associatedUser = _appDbContext.UserProfiles.Find(addDB.Uploader.Id); // Successfully locates Uploader record in UserProfile table and sets associatedUser to that object.

            addDB.Uploader = associatedUser;


            //Look into Lazy Loading -- 

            _appDbContext.UploadedImages.Add(addDB);//issue with setting uploaderid -- need identity_insert set to enabled
            _appDbContext.SaveChanges();

        }

        // PUT api/<Images>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] object image)
        {
            if (id > 0)
            {
                string img = image.ToString(); //Successfully converts the image object to a JSON string with markup
                UploadedImage update = (UploadedImage)JSONDeserializer.Deserialize<UploadedImage>(img); // Successfully converts JSON String to Uploaded Image object.

                UploadedImage currentImage = _appDbContext.UploadedImages.Find(id);
                if (update != null)
                {
                    currentImage.IsApproved = update.IsApproved != null ? (Boolean)update.IsApproved : currentImage.IsApproved;
                    currentImage.File = update.File != null ? (Byte[])update.File : currentImage.File;
                    currentImage.Name = update.Name != null ? update.Name : currentImage.Name;
                    currentImage.Uploader = update.Uploader != null ? (UserProfile)update.Uploader : currentImage.Uploader;
                }

                _appDbContext.UploadedImages.Update(currentImage);
                _appDbContext.SaveChanges();
            }
        }

        // DELETE api/<Images>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id > 0)
            {
                UploadedImage delete = _appDbContext.UploadedImages.Find(id);

                if (delete != null)
                {

                    _appDbContext.UploadedImages.Remove(delete);
                    _appDbContext.SaveChanges();
                }
            }
        }
    }
}
