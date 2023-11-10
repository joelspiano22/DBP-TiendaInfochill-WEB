using ProyectoDBP_TIENDA.Service.Interface;
using ProyectoDBP_TIENDA.Service.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
}); //Agregar sesiones al proyecto 

builder.Services.Add(new ServiceDescriptor(typeof(IAdmin), new AdminRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuario), new UsuarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProducto), new ProductoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProveedores), new ProveedorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICliente), new ClienteRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ITemporalVenta), new TemporalVentaRepository()));


//builder.Services.Add(new ServiceDescriptor(typeof(ICarrito), new CarritoRepository()));

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
app.UseSession();   
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=ProductoPrincipal}/{id?}");

app.Run();
