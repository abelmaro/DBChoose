using DBChoose.Business.Services;
using DBChoose.Business.Services.Interfaces;
using DBChoose.DataAccess.Ef;
using DBChoose.Ef.Extensions;
using DBChoose.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProviderInfoService, ProviderInfoService>();
builder.AddDataContext();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var IdentityContext = serviceScope.ServiceProvider.GetRequiredService<DBChooseContext>();
    IdentityContext.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Main/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<DatabaseProviderValidationMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();
