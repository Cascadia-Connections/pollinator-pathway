﻿using System.Diagnostics;
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
    public IActionResult AdminList()
    {
        IEnumerable<PollinatorPathwayUser> admins = _identityDbContext.Users;
        return View(admins);
    }
   
    [HttpGet]
    public async Task<IActionResult> DeleteAdmin(string id)
    {
        PollinatorPathwayUser user = await _manager.FindByIdAsync(id);
        if (user != null)
        {
            IdentityResult result = await _manager.DeleteAsync(user);
            return RedirectToAction("AdminList");
           
        }
        else
            ModelState.AddModelError("", "User Not Found");
        return View("Index", _manager.Users);
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateAdmin(string id)
    {
        PollinatorPathwayUser user = await _manager.FindByIdAsync(id);

        AdminViewModel adminVM = new AdminViewModel
        {
            AdminId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.PhoneNumber,
            EmailAddress = user.Email
        };
        return View(adminVM);
     

    }
    [HttpPost]
    public async Task<IActionResult> UpdateAdmin(AdminViewModel adminVM)
    {
        PollinatorPathwayUser user = await _manager.FindByEmailAsync(adminVM.EmailAddress);
        
            if (!string.IsNullOrEmpty(adminVM.FirstName))
                user.FirstName = adminVM.FirstName;
           if (!string.IsNullOrEmpty(adminVM.LastName))
                user.LastName = adminVM.LastName;
            if (!string.IsNullOrEmpty(adminVM.EmailAddress))
                user.Email = adminVM.EmailAddress;
            if (!string.IsNullOrEmpty(adminVM.Phone))
                user.PhoneNumber = adminVM.Phone; ModelState.AddModelError("", "Phone number cannot be empty");
         
        var result = await _manager.UpdateAsync(user);
            if (result.Succeeded)
                return RedirectToAction("AdminList");
            else
                return Error();
       

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
                IsPrivate = userProVM.IsPrivate,
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
        else
        {
            return RedirectToAction("CreateProfile", new { id = userProVM.UserId });
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
    public IActionResult SearchForProfileByFirstName(string fName)
    {
        string number = Request.Form["number"];

        IEnumerable<UserProfile> users = _appDbContext.UserProfiles.Where(u => u.FirstName.StartsWith(fName));
        return View("UsersList", users);
    }
    [HttpPost]
    public IActionResult SearchForAdminBy(string searchValue)
    {
        string seachType = Request.Form["searchType"];
        IEnumerable<PollinatorPathwayUser> admins = (IEnumerable<PollinatorPathwayUser>)_manager.Users;
        switch (seachType)
        {
            case "LastName": admins = admins.Where(u => u.LastName.StartsWith(searchValue));
                break;
            case "Email": admins = admins.Where(u => u.Email.Equals(searchValue));
                break;

        }
        return View("AdminList", admins);
    }

    [HttpPost]
    public IActionResult UpdateProfile(ProfileViewModel userProVM,long Id)
    {
        UserProfile up = new UserProfile
        {
            Id = Id,
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
            IsPrivate = userProVM.IsPrivate,
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
            Password = user.Password,
            TeamContact = user.TeamContact,
            DateJoined = user.DateJoined,
            OrganizationName = user.OrganizationName,
            OrganizationEmail = user.OrganizationEmail,
            OrganizationType = user.OrganizationType,
            IsPrivate = user.IsPrivate,
            Address = user.Address,
            GPS = user.GPS,
            PlantName = user.PlantName,
            PlantDesc = user.PlantDesc,
            Image1 = user.Image1,
            Image2 = user.Image2,
            Image3 = user.Image3
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

