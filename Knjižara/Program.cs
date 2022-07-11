using Knjižara.Mailer;
using Knjižara.Mailer.Models;
using Knjižara.Middlewares;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<MailSettings>(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MailSettings"));

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



app.UseStaticFiles();

app.UseRouting();

app.UseSession();

// Middlewares
app.UseGuest();
app.UseAuthenticate();
app.UseUserHasAccess();

// Routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
