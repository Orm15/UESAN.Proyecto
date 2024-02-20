using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.proyecto.Infrastructure.repository;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var connectionString = _config
				.GetConnectionString("DevConnection");
builder
	   .Services
	   .AddDbContext<OrdenesEventosContext>
	   (options => options.UseSqlServer(connectionString));

//Aqui se  registran las clases:
builder.Services.AddTransient<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddTransient<IUsuarioServices,UsuarioServices>();
builder.Services.AddTransient<IEventoRepository,EventoRepository>();
builder.Services.AddTransient<IEventosService, EventosService>();
builder.Services.AddTransient<IServiciosRepository, ServiciosRepository>();
builder.Services.AddTransient<IServicioService, ServicioService>();
builder.Services.AddTransient<IVideosRepository, VideosRepository>();
builder.Services.AddTransient<IVideosServices, VideosServices>();
builder.Services.AddTransient<IEdicionRepository, EdicionRepository>();
builder.Services.AddTransient<IEdicionService, EdicionService>();
builder.Services.AddTransient<IServicioFotosRepository, ServicioFotosRepository>();
builder.Services.AddTransient<IServicioFotosService, ServicioFotosService>();
builder.Services.AddTransient<ICircuitoCerradoRepository, CircuitoCerradoRepository>();
builder.Services.AddTransient<ICircuitoCerradoService, CircuitoCerradoService>();
builder.Services.AddTransient<IEscenasVideoRepository, EscenasVideoRepository>();
builder.Services.AddTransient<IEscenaVideoService, EscenaVideoService>();
builder.Services.AddTransient<IServicioEdicionVideoRepository,ServicioEdicionVideoRepository>();
builder.Services.AddTransient<IServicioEdicionVideoService, ServicioEdicionVideoService>();
builder.Services.AddTransient<IStreamRepository, StreamRepository>();
builder.Services.AddTransient<IStreamService, StreamService>();




builder.Services.AddControllers().AddJsonOptions(options =>
{
	options
		.JsonSerializerOptions
		.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder
			.WithOrigins("http://localhost:9000")
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
