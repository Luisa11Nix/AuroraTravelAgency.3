using AuroraTravelAgency.Services;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios (inyección de dependencias)
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDestinoRepositorio, DestinoRepositorio>();
builder.Services.AddSingleton<ICotizacionRepositorio, CotizacionRepositorio>();
builder.Services.AddSingleton<CotizadorService>();

var app = builder.Build();

// Pipeline de middleware: cada solicitud pasa por estos componentes en orden
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();   // sirve los archivos de wwwroot (css, js)
app.UseRouting();
app.UseAuthorization();

// Ruta por defecto: /{controlador}/{accion}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
