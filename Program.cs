using Real_Time_Charts_SignalR.Hubs;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Real_Time_Charts_SignalR.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.)
builder.Services.AddTransient<IAlphaVintageClient, AlphaVintageClient>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddJob();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChartHub>("/charthub");

app.Run("https://localhost:7199");
