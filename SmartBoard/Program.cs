using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.WebUI.Data;
using SmartBoard.WebUI.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

//services.AddControllersWithViews();
builder.Services.Configure<SmartSettings>(builder.Configuration.GetSection(SmartSettings.SectionName));

// Note: This line is for demonstration purposes only, I would not recommend using this as a shorthand approach for accessing settings
// While having to type '.Value' everywhere is driving me nuts (>_<), using this method means reloaded appSettings.json from disk will not work
builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});


builder.Services.AddMvc(o =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    o.Filters.Add(new AuthorizeFilter(policy));

});

builder.Services.AddDbContext<SmartBoardContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("SmartBoardConnection")
                )

            );

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(
       builder.Configuration.GetConnectionString("SmartBoardConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddMvc();

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

//app.MapControllerRoute(
//    name: "default",    
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        //pattern: "{controller=AspNetCore}/{action=Welcome}"
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapRazorPages();
});

app.Run();
// esto es una prueba del push de git
// 2