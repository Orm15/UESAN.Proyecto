﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Utilidades;

namespace UESAN.proyecto.Infrastructure.Shared
{
	public static class ServiceRegistration
	{
		public static void AddSharedInfrastructure(this IServiceCollection services,IConfiguration _config)
		{
			/*
			var c = _config.GetSection("JWTSettings");
			services.Configure<JWTSettings>(c);
			*/

			services.Configure<JWTSettings>(_config.GetSection("JWTSettings"));


			services.AddTransient<IJWTFactory, JWTFactory>();

			var issuer = _config["JWTSettings:Issuer"];
			var audience = _config["JWTSettings:Audience"];
			var secretKey = _config["JWTSettings:SecretKey"];

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})

			   .AddJwtBearer(o =>  
			   {
				   o.TokenValidationParameters = new TokenValidationParameters
				   {
					   ValidateIssuerSigningKey = true,
					   ValidateIssuer = true,
					   ValidateAudience = true,
					   ValidateLifetime = true,
					   ClockSkew = TimeSpan.Zero,

					   ValidIssuer = issuer,
					   ValidAudience = audience,
					   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
				   };
			   });
		}
	}
}
