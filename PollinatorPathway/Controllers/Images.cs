using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollinatorPathway.Data;
using PollinatorPathway.Model;

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
            IEnumerable<UploadedImage> userImages = _appDbContext.UploadedImages.Include(u => u.Uploader)
                .Where(u => u.Uploader.Id == id);

            return Ok(userImages);
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
