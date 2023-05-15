using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotoTrackerGps.Data;
using MotoTrackerGps.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MotoTrackerGps")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ITrackerService, TrackerService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "tracker",
    pattern: "Tracker/{action}/{id?}",
    defaults: new { controller = "TrackerGPS", action = "Index" });
app.MapControllerRoute(
    name: "trackerView",
    pattern: "Tracker/{id}",
    defaults: new { controller = "TrackerGPS", action = "TrackerView" }
);
app.MapRazorPages();

app.Run();

