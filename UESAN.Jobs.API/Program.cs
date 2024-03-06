using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.proyecto.Infrastructure.repository;
using UESAN.proyecto.Infrastructure.Shared;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;
using UESAN.Proyecto.Core.Utilidades;

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
builder.Services.AddSharedInfrastructure(_config);
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddControllers();
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
			//.WithOrigins("http://localhost:5158")
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

	// Agregar el esquema de seguridad JWT
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Ingrese el token JWT en el formato 'Bearer {token}'",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT"
	});

	// Agregar el requisito de seguridad JWT a nivel global
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
			},
			new string[] { }
		}
	});
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
