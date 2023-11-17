using Megasave.Application;
using Megasave.Application.Contracts;
using Megasave.Identity;
using Megasave.Identity.Models;
using Megasave.Persistence;
using Megasave.Web.Claims;
using Megasave.Web.Middleware;
using Megasave.Web.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
//builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<MopaneIdentityDbContext>()
    .AddClaimsPrincipalFactory<CustomClaimsFactory>();
//builder.Services.AddScoped<IUserClaimsPrincipalFactory<Users>, CustomClaimsFactory>();
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseHttpLogging();
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomExceptionHandler();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
