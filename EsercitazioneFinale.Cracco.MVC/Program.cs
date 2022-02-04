using EsercitazioneFinale.Cracco.Core.BusinessLayer;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using EsercitazioneFinale.Cracco.EF;
using EsercitazioneFinale.Cracco.EF.RepositoryEF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBusinessLayer, BusinessLayer>();

builder.Services.AddScoped<IRepositoryMenu, RepositoryMenuEF>();
builder.Services.AddScoped<IRepositoryPiatti, RepositoryPiattiEF>();

builder.Services.AddDbContext<MasterContext>(options =>
{
    options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Cracco; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
});

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

app.Run();
