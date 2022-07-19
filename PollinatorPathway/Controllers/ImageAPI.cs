using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Data;
using PollinatorPathway.Model;

namespace PollinatorPathway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAPI : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public ImageAPI(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<long> ImageID = _appDbContext.UploadedImages
                .Where<UploadedImage>(u => u.Id != 0)
                .Select(u => u.Id).ToList<long>();



            List<UploadedImage> Images = new List<UploadedImage>();

            foreach (var id in ImageID)
            {

                long UserID = _appDbContext.UploadedImages.Find(id).Uploader.Id; //Issue with this line... Does not want to pull the data out of the DB...?
                UserProfile UploaderPH = new UserProfile()
                {
                    Id = _appDbContext.UserProfiles.Find(UserID).Id,
                };
                Images.Add(new UploadedImage()
                {
                    Id = _appDbContext.UploadedImages.Find(id).Id,
                    IsApproved = _appDbContext.UploadedImages.Find(id).IsApproved,
                    File = _appDbContext.UploadedImages.Find(id).File,
                    Name = _appDbContext.UploadedImages.Find(id).Name,
                    Uploader = UploaderPH
                });

            }
            return Ok(Images);
        }


        // GET: ImageAPI/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // GET: ImageAPI/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: ImageAPI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ImageAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: ImageAPI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ImageAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: ImageAPI/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
