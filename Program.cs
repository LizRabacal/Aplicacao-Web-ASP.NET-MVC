using TRABALHOELETROPONTO.Models;
using TRABALHOELETROPONTO.Data;
using TRABALHOELETROPONTO.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultDatabase");

builder.Services.AddDbContext<FuncionarioContext>(opt => {
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});

builder.Services.AddDbContext<ItensVendaContext>(opt => {
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});

builder.Services.AddDbContext<VendaContext>(opt => {
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});



builder.Services.AddDbContext<ClienteContext>(opt => {
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});
 builder.Services.AddIdentity<Cliente, IdentityRole>()
        .AddEntityFrameworkStores<ClienteContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<SignInManager<Cliente>, SignInManager<Cliente>>();
builder.Services.AddScoped<UserManager<Cliente>, UserManager<Cliente>>();        




builder.Services.AddDbContext<ProdutoContext>(opt => {
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IFuncionarioRepository,FuncionarioRepository>();


builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();





builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
