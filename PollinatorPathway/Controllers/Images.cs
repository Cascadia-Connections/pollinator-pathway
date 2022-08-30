using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollinatorPathway.Data;
using PollinatorPathway.Model;

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
        public void Post([FromBody] UploadedImage image) //does pass a string argument in JSON FORMATTING (object obtain)
        {

            //    "errors": {
            //        "image": [
            //            "The image field is required."
            //],
            //"$.File": [
            //    "The JSON value could not be converted to System.Byte[]. Path: $.File | LineNumber: 2 | BytePositionInLine: 22."
            //]



            //string splitPattern = @"\,";
            //Regex test = new(splitPattern);

            //string[] returnedArray = test.Split(image.ToString()); //Succesfully separated into array, comma removed.

            //foreach (string s in returnedArray)
            //{
            //    System.Diagnostics.Debug.WriteLine(s);
            //} Regex option if all else fails

        }

        // PUT api/<Images>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UploadedImage image)
        {
            if (id > 0)
            {
                UploadedImage update = image;
                UploadedImage currentImage = _appDbContext.UploadedImages.Find(id);


                if (update != null)
                {
                    update.IsApproved = update.IsApproved != null ? (Boolean)update.IsApproved : currentImage.IsApproved;
                    update.File = update.File != null ? (Byte[])update.File : currentImage.File;
                    update.Name = update.Name != null ? update.Name : currentImage.Name;
                    update.Uploader = update.Uploader != null ? (UserProfile)update.Uploader : currentImage.Uploader;
                }
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
