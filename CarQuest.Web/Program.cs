using System.Reflection;

using CarQuest.Data;
using CarQuest.Data.Models;
using CarQuest.Services;
using CarQuest.Services.Interfaces;
using CarQuest.Services.Mapping;
using CarQuest.Web.Infrastructure.Extensions;
using CarQuest.Web.ViewModels.Home;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static CarQuest.Common.GeneralApplicationConstants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarQuestDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
	{
		options.SignIn.RequireConfirmedAccount =
			builder.Configuration.GetValue<bool>("Identity:SignId:RequireConfirmedAccount");
		options.Password.RequireLowercase =
			builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
		options.Password.RequireUppercase =
			builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
		options.Password.RequireNonAlphanumeric =
			builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
		options.Password.RequiredLength =
			builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
	})
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<CarQuestDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();

builder.Services.ConfigureApplicationCookie(cfg =>
{
	cfg.LoginPath = "/Identity/Account/Login";
});

builder.Services
	.AddControllersWithViews()
	.AddMvcOptions(options =>
	{
		options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
	});

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<ITicketUserService, TicketUserService>();
builder.Services.AddScoped<ITicketMechanicService, TicketMechanicService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOfferService, OfferService>();

WebApplication app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Home/Error/500");
	app.UseExceptionHandler("/Home/Error/404");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.EnableOnlineUsersCheck();

if (app.Environment.IsDevelopment())
{
	app.SeedAdministration(DevelopmentAdminEmail);
}

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapDefaultControllerRoute();
	endpoints.MapRazorPages();
});

app.Run();