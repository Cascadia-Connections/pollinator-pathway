using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Data;
using PollinatorPathway.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollinatorPathway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Profiles : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public Profiles(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserProfile> users = _appDbContext.UserProfiles;

            return Ok(users);
        }

        // GET api/<UserProfileAPI>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserProfile? user = _appDbContext.UserProfiles.SingleOrDefault(u => u.Id == id);
            return Ok(user);
        }

        // POST api/<UserProfileAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserProfileAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserProfileAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
