using CoderMind.Application;
using CoderMind.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//builder.Services.AddApplicationMongoService(opt =>
//{
//    opt!.ConnectionString = builder.Configuration["MongoConnection:ConnectionString"]!;
//    opt.DatabaseName = builder.Configuration["MongoConnection:DatabaseName"]!;
//});

builder.Services.AddApplicationEfService(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
