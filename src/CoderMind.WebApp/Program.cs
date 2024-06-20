using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using CoderMind.Application;
using CoderMind.Persistence.Database;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//builder.Services.AddApplicationMongoService(opt =>
//{
//    opt!.ConnectionString = builder.Configuration["MongoConnection:ConnectionString"]!;
//    opt.DatabaseName = builder.Configuration["MongoConnection:DatabaseName"]!;
//});

builder.Services.AddApplicationEfService(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EFContext>().AddDefaultTokenProviders();
builder.Services.AddNotyf(conf =>
{
    conf.DurationInSeconds = 3;
    conf.IsDismissable = true;
    conf.Position = NotyfPosition.TopRight;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseNotyf();


app.Run();
