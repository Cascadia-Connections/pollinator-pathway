using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PollinatorPathway.Areas.Identity.Data;
using PollinatorPathway.Data;
using PollinatorPathway.Model;
using PollinatorPathway.ViewModels;

namespace PollinatorPathway.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppIdentityDbContext _identityDbContext;
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<PollinatorPathwayUser> _manager;
    public HomeController(ILogger<HomeController> logger, AppIdentityDbContext identityDbContext, AppDbContext appDbContext, UserManager<PollinatorPathwayUser> manager)
    {
        _logger = logger;
        _identityDbContext = identityDbContext;
        _appDbContext = appDbContext;
        _manager = manager;
    }

   
   
    public IActionResult AdminPortal()
    {
        var userId=  _manager.GetUserId(HttpContext.User);
        PollinatorPathwayUser user =_identityDbContext.Users.FirstOrDefault (u=> u.Id==userId);
       
        return View(user);
    }
    
    [HttpGet]
    public IActionResult CreateProfile()
    {
       
        return View(new ProfileViewModel());
    }

    [HttpPost]
    public IActionResult CreateProfile(ProfileViewModel userProVM)
    {

        if (ModelState.IsValid)
        {
            UserProfile up = new UserProfile
            {
                FirstName = userProVM.FirstName,
                LastName = userProVM.LastName,
                EmailAddress = userProVM.EmailAddress,
                Password = userProVM.Password,
                Phone = userProVM.Phone,
                TeamContact = userProVM.TeamContact,
                DateJoined = userProVM.DateJoined,
                OrganizationName = userProVM.OrganizationName,
                OrganizationEmail = userProVM.OrganizationEmail,
                OrganizationType = userProVM.OrganizationType,
                Address = userProVM.Address,
                GPS = userProVM.GPS,
                PlantName = userProVM.PlantName,
                PlantDesc = userProVM.PlantDesc,
                Image1 = userProVM.Image1,
                Image2 = userProVM.Image2,
                Image3 = userProVM.Image3

            };
           
           _appDbContext.Add(up);
           _appDbContext.SaveChanges();
        }

            return RedirectToAction("AdminPortal");
    }

    [HttpGet]
    public IActionResult getUsers()
    {
        IEnumerable<UserProfile> users = _appDbContext.UserProfiles;
        return View("UsersList",users);
    }

    
    [HttpPost]
    public IActionResult UpdateProfile(ProfileViewModel userProVM,long Id)
    {

        
            UserProfile up = new UserProfile
            {
                Id=Id,
                FirstName = userProVM.FirstName,
                LastName = userProVM.LastName,
                EmailAddress = userProVM.EmailAddress,
                Password = userProVM.Password,
                Phone = userProVM.Phone,
                TeamContact = userProVM.TeamContact,
                DateJoined = userProVM.DateJoined,
                OrganizationName = userProVM.OrganizationName,
                OrganizationEmail = userProVM.OrganizationEmail,
                OrganizationType = userProVM.OrganizationType,
                Address = userProVM.Address,
                GPS = userProVM.GPS,
                PlantName = userProVM.PlantName,
                PlantDesc = userProVM.PlantDesc,
                Image1 = userProVM.Image1,
                Image2 = userProVM.Image2,
                Image3 = userProVM.Image3

            };

            _appDbContext.Update(up);
            _appDbContext.SaveChanges();
        

        return RedirectToAction("getUsers");
    }
    [HttpGet]
    public IActionResult UpdateProfile(long id)
    {
        var user = _appDbContext.UserProfiles.FirstOrDefault (u=>u.Id==id);
        ProfileViewModel profileVM = new ProfileViewModel
        {
            UserId = id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailAddress = user.EmailAddress,
            Phone = user.Phone,
            Password = user.Password
        };

        return View("UpdateProfile", profileVM);

    }

    [HttpGet]
    public IActionResult DeleteProfile(long id)
    {
        _appDbContext.Remove(new UserProfile { Id = id });
        _appDbContext.SaveChanges();
        return RedirectToAction("getUsers");
    }

    [HttpGet]
    public IActionResult ImageApproval()
    {
        IEnumerable<UploadedImage> images = _appDbContext.UploadedImages.Where(img=> img.IsApproved==false).ToList();
        return View(images);
    }

    [HttpGet]
    public IActionResult RemoveImage(long id)
    {
        _appDbContext.Remove(new UploadedImage { Id = id });
        _appDbContext.SaveChanges();
        return RedirectToAction("ImageApproval");
    }
    [HttpGet]
    public IActionResult ApproveImage(long id)
    {
        var image= _appDbContext.UploadedImages.FirstOrDefault(img=>img.Id==id);
        UploadedImage imageModel = image;
        imageModel.IsApproved = true;
        _appDbContext.Update(imageModel);
        _appDbContext.SaveChanges();
        return RedirectToAction("ImageApproval");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}

