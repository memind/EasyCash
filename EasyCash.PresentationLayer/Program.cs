using EasyCash.BusinessLayer.Abstract;
using EasyCash.BusinessLayer.Concrete;
using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DataAccessLayer.EntityFramework;
using EasyCash.EntityLayer.Concrete;
using EasyCash.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDal, EFCustomerAccountProcessDAL>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.Run();
