using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Data;
using PollinatorPathway.Model;

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
            List<long> UserIds = _appDbContext.UserProfiles
                .Where<UserProfile>(u => u.Id != 0)
                .Select(u => u.Id).ToList<long>();


            List<UserProfile> users = new List<UserProfile>();

            foreach (var id in UserIds)
            {
                users.Add(new UserProfile()
                {
                    Id = id,
                    FirstName = _appDbContext.UserProfiles.Find(id).FirstName,
                    LastName = _appDbContext.UserProfiles.Find(id).LastName,
                    EmailAddress = _appDbContext.UserProfiles.Find(id).EmailAddress,
                    Phone = _appDbContext.UserProfiles.Find(id).Phone,
                    TeamContact = _appDbContext.UserProfiles.Find(id).TeamContact,
                    DateJoined = _appDbContext.UserProfiles.Find(id).DateJoined,
                    Password = _appDbContext.UserProfiles.Find(id).Password,
                    OrganizationName = _appDbContext.UserProfiles.Find(id).OrganizationName,
                    OrganizationEmail = _appDbContext.UserProfiles.Find(id).OrganizationEmail,
                    OrganizationType = _appDbContext.UserProfiles.Find(id).OrganizationType,
                    WebsiteLink = _appDbContext.UserProfiles.Find(id).WebsiteLink,
                    SocialMedia = _appDbContext.UserProfiles.Find(id).SocialMedia,
                    IsPrivate = _appDbContext.UserProfiles.Find(id).IsPrivate,
                    Address = _appDbContext.UserProfiles.Find(id).Address,
                    GPS = _appDbContext.UserProfiles.Find(id).GPS,
                    PlantName = _appDbContext.UserProfiles.Find(id).PlantName,
                    PlantDesc = _appDbContext.UserProfiles.Find(id).PlantDesc,
                    Image1 = _appDbContext.UserProfiles.Find(id).Image1,
                    Image2 = _appDbContext.UserProfiles.Find(id).Image2,
                    Image3 = _appDbContext.UserProfiles.Find(id).Image3,


                });


            }

            return Ok(users);
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
