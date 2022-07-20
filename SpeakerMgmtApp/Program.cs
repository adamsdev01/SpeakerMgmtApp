using Microsoft.EntityFrameworkCore;
using SpeakerMgmtApp.Data;
using SpeakerMgmtApp.Models;
using Microsoft.AspNetCore.Identity;
using SpeakerMgmtApp.Models;
using SpeakerMgmtApp.Services;
using AutoMapper;
using SpeakerMgmtApp.Models.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Application Users - Identity
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Speakers Application 
var speakersConnectionString = builder.Configuration.GetConnectionString("SpeakerConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<SpeakersDbContext>(options =>
    options.UseSqlServer(speakersConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

// register services
builder.Services.AddScoped<SpeakerService>();

// Enable runtime compilation for all environments
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// AutoMapper Configuration
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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

// seed user roles
SeedDatabaseAsync();

async Task SeedDatabaseAsync()
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await ContextSeed.SeedRolesAsync(userManager, roleManager);
            await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "An error occurred seeding the DB.");
        }
    }
}
// end seed 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



app.Run();


