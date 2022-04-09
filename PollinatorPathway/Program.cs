using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PollinatorPathway.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Databases Services to Container.
var DefaultConnectionString = builder.Configuration.GetConnectionString("AppDefault-Mac");
var IdentityConnectionString = builder.Configuration.GetConnectionString("AppIdentity-Mac");
//Enable for use of Sqlite on Mac
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(DefaultConnectionString));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(IdentityConnectionString));

//Enable for use of SqlServer on Windows
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DefaultConnectionString));
//builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(IdentityConnectionString));

// Add Developer, Identity and Controller Services
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=AdminPortal}/{id?}");
app.MapRazorPages();

app.Run();

