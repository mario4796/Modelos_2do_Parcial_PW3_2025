using GestionSuperheroes.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<MiDbContext>();
builder.Services.AddScoped<GestionSuperheroes.Servicios.ISuperheroeServicio, GestionSuperheroes.Servicios.SuperheroeServicio>();
builder.Services.AddScoped<GestionSuperheroes.Servicios.IUniversoServicio, GestionSuperheroes.Servicios.UniversoServicio>();

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
