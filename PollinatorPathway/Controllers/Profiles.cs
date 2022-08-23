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

            if (id > 0)
            {
                UserProfile? user = _appDbContext.UserProfiles.SingleOrDefault(u => u.Id == id);

                if (user != null)
                {
                    return Ok(user);

                }
                else

                {
                    return Problem("No Such User");
                }
            }
            else return Problem("Invalid ID: Id's must be greater than 0");
        }

        // POST api/<UserProfileAPI>
        [HttpPost]
        public async void Post([FromBody] UserProfile user)
        {

            _appDbContext.UserProfiles.Add(user);
            _appDbContext.SaveChanges();

        }

        // PUT api/<UserProfileAPI>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UserProfile user)
        {
            if (id > 0)
            {

                UserProfile update = _appDbContext.UserProfiles.Find(id);

                if (update != null)
                {

                    update.FirstName = user.FirstName != null ? user.FirstName : update.FirstName;
                    update.LastName = user.LastName != null ? user.LastName : update.LastName;
                    update.EmailAddress = user.EmailAddress != null ? user.EmailAddress : update.EmailAddress;
                    update.Phone = user.Phone != null ? user.Phone : update.Phone;
                    update.TeamContact = user.TeamContact != null ? user.TeamContact : update.TeamContact;
                    update.DateJoined = user.DateJoined != null ? user.DateJoined : update.DateJoined;
                    update.Password = user.Password != null ? user.Password : update.Password;
                    update.OrganizationName = user.OrganizationName != null ? user.OrganizationName : update.OrganizationName;
                    update.OrganizationEmail = user.OrganizationEmail != null ? user.OrganizationEmail : update.OrganizationEmail;
                    update.OrganizationType = user.OrganizationType != null ? user.OrganizationType : update.OrganizationType;
                    update.WebsiteLink = user.WebsiteLink != null ? user.WebsiteLink : update.WebsiteLink;
                    update.SocialMedia = user.SocialMedia != null ? user.SocialMedia : update.SocialMedia;
                    update.IsPrivate = user.IsPrivate != null ? user.IsPrivate : update.IsPrivate;
                    update.Address = user.Address != null ? user.Address : update.Address;
                    update.GPS = user.GPS != null ? user.GPS : update.GPS;
                    update.PlantName = user.PlantName != null ? user.PlantName : update.PlantName;
                    update.PlantDesc = user.PlantDesc != null ? user.PlantDesc : update.PlantDesc;
                    update.Image1 = user.Image1 != null ? user.Image1 : update.Image1;
                    update.Image2 = user.Image2 != null ? user.Image2 : update.Image2;
                    update.Image3 = user.Image3 != null ? user.Image3 : update.Image3;

                    _appDbContext.UserProfiles.Update(update);
                    _appDbContext.SaveChanges();
                }
            }

        }

        // DELETE api/<UserProfileAPI>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id > 0)
            {
                UserProfile toDelete = _appDbContext.UserProfiles.Find(id);

                if (toDelete != null)
                {
                    _appDbContext.UserProfiles.Remove(toDelete);
                    _appDbContext.SaveChanges();
                }
            }
        }
    }
}
