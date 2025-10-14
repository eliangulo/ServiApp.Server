using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Repositorio.Repositorio;
using ServiApp.Server.Client.Pages;
using ServiApp.Server.Components;
using ServiApp.Servicio.ServicioHTTP;

// Configura el constructor del server y lo guardará en "builder"
var builder = WebApplication.CreateBuilder(args);

//region configura el Constructor de la aplicacion y sus servicios
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("El string de conexion no existe.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
//inyectamos el servicio generico
builder.Services.AddScoped<IServicioRepo<ServicioEnti>, ServicioRepo<ServicioEnti>>();//repoServicio
builder.Services.AddScoped<ICategoriaRepo<Categoria>, CategoriaRepo<Categoria>>();//repoCategoria

builder.Services.AddScoped<IHttpServicio, HttpServicio>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7223/")
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Construimos nuestra aplicación
var app = builder.Build();

// Aplicar migraciones automáticamente al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // Aplica todas las migraciones pendientes
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ServiApp.Server.Client._Imports).Assembly);

app.MapControllers();

app.Run();