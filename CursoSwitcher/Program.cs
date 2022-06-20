using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


static void ConfigurationCookie(CookieAuthenticationOptions options)
{
    options.LoginPath = "/Login/Index";
    options.AccessDeniedPath = "/NotAllowed/Index";
    options.LogoutPath = "/Login/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
}


// Add services to the container.
builder.Services.AddControllersWithViews();
/* https://stackoverflow.com/questions/36488461/sqlite-in-asp-net-core-with-entityframeworkcore */
// Configuramos la integración entre el ORM (Object relational mapper) y el servicio de SQLite indicandole QUE manager es el que usaremos.
builder.Services.AddEntityFrameworkSqlite().AddDbContext<ModelContextManager>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(ConfigurationCookie);


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

// ORDEN MUCHO MUY IMPORTANTE
// PRIMERO AUTENTICO (¿Quien sos?)
app.UseAuthentication();
// SEGUNDO AUTORIZO (Ya se quien sos... Ahora en base a tu rol o permisos, te dejaré hacer ciertas cosas...)
app.UseAuthorization();

// Aclaro que mi proyecto, usará una política de cookies para la autenticación.
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
