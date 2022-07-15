using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollinatorPathway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileAPI : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserProfileAPI(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> UserProfiles = _appDbContext.UserProfiles
                .Where(u => u.Id != 0)
                .Select(u => u.FirstName).ToList();


            return Ok(UserProfiles);
        }

        // GET api/<UserProfileAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
