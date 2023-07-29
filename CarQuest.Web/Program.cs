using CarQuest.Data;
using CarQuest.Data.Models;

using Microsoft.EntityFrameworkCore;

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
            builder.Configuration.GetValue<bool>("Identity:SignId:RequireLowercase");
        options.Password.RequireUppercase =
            builder.Configuration.GetValue<bool>("Identity:SignId:RequireUppercase");
        options.Password.RequireNonAlphanumeric =
            builder.Configuration.GetValue<bool>("Identity:SignId:RequireNonAlphanumeric");
        options.Password.RequiredLength =
            builder.Configuration.GetValue<int>("Identity:SignId:RequiredLength");
    })
    .AddEntityFrameworkStores<CarQuestDbContext>();

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
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

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();