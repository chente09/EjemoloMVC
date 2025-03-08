using EjemoloMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio HTTP con HttpClient
builder.Services.AddHttpClient<DogService>(client =>
{
    client.BaseAddress = new Uri("https://api.thedogapi.com/v1/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
