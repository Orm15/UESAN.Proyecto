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



builder.Services.AddControllers().AddJsonOptions(options =>
{
	options
		.JsonSerializerOptions
		.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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

app.MapControllers();

app.Run();
