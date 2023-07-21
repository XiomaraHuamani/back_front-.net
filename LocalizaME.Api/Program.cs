using LocalizaME.DataAccess;
using LocalizaME.Dto.Response;
using LocalizaME.Entity;
using LocalizaME.Entity.Infos;
using LocalizaME.Repositories; 
using LocalizaME.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
//configuracion de permisos para conectar a la parte web
var Mycors = "Mycors";

// Add services to the container.
builder.Services.AddDbContext<LocalizameDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalizaME"));
});

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<Cliente, ClienteDtoResponse>();
    config.CreateMap<Producto, ProductoDtoResponse>();
    config.CreateMap<Repartidor, RepartidorDtoResponse>();
    config.CreateMap<Ubicacion, UbicacionDtoResponse>();
    config.CreateMap<Pedido, PedidoDtoResponse>();
    config.CreateMap<PedidoInfo, ReportePedidoDtoResponse>();
});

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<IRepartidorRepository, RepartidorRepository>();
builder.Services.AddTransient<IRepartidorService, RepartidorService>();
builder.Services.AddTransient<IUbicacionRepository, UbicacionRepository>();
builder.Services.AddTransient<IUbicacionService, UbicacionService>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IPedidoService, PedidoService>();

builder.Services.AddControllers();

//agragando el servicio de los permisos
builder.Services.AddCors(options =>
 {
     options.AddPolicy(Mycors, builder =>
 {
     builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
 });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


//ejecucion de permisos
app.UseCors(Mycors);

app.MapControllers();

app.Run();

