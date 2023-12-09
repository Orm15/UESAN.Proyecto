using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.Utilidades;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class UsuarioRepository : IUsuarioRepository
	{

		private readonly OrdenesEventosContext _context;

		public UsuarioRepository(OrdenesEventosContext context)
		{
			_context = context;
		}
		//Funcion del admin, puede llamar por medio de un filtro
		public async Task<IEnumerable<Usuarios>> getAll(string estado)
		{
			if (estado == "todos")
			{
				return await _context.Usuarios.ToListAsync();
			}
			else { 
				var usu =  await _context.Usuarios.Where(x => x.Estado == estado).ToListAsync();
				if (usu.Any())
				{
					return usu;
				}
				else {
					return null;
				}
			}

		}

		public async Task<Usuarios> getById(int id)
		{
			var usu = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
			if(usu == null)
			{
				return null;
			}
			else
			{
				return usu;
			}
		}

		public async Task<Usuarios> Insert(Usuarios u)
		{
			await _context.Usuarios.AddAsync(u);
			int rows = await _context.SaveChangesAsync();
			if (rows > 0)
			{
				return u;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> update(Usuarios u)
		{
			_context.Usuarios.Update(u);
			int rows = _context.SaveChanges();
			return rows > 0;
		}

		public async Task<bool> delete(int id)
		{
			var emp = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.Estado = "inactivo";
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}
		//si existe un usuario con ese correo ya creado retorna true
		public async Task<bool> IsEmailRegistered(string email)
		{
			return await _context
				.Usuarios
				.Where(x => x.Correo == email).AnyAsync();
		}
		//SIGIN SIN SALT
		public async Task<Usuarios> SigIn(string correo, string contra)
		{
			var u = await _context.Usuarios.Where(x => x.Correo == correo && x.Contra == contra && x.Estado == "activo")
				.FirstOrDefaultAsync();
			if (u == null)
			{
				return null;
			}
			else
			{
				return u;
			}
		}
		//SIGIN CON SALT.

		public async Task<Usuarios> SigInSalt(string correo, string contra)
		{
			var user = await _context.Usuarios
				.Where(x => x.Correo == correo && x.Estado == "activo")
				.FirstOrDefaultAsync();

			if (user != null && VerifyPassword(contra, user.Contra,user.Salt))
			{
				return user;
			}

			return null;
		}

		private bool VerifyPassword(string PasswordIngresado, string PasswordAlmacenado,string salt)
		{
			// Aquí extraemos la sal del hash almacenado
			string storedSalt = salt;
			// Calculamos el hash de la contraseña proporcionada con la sal almacenada
			string hashedPassword = SecurityHelperUtilidades.HashPassword(PasswordIngresado.Trim(), storedSalt.Trim());
			// Comparamos los resultados
			Console.WriteLine($"PasswordAlmacenado: {PasswordAlmacenado}");

			return PasswordAlmacenado.Trim() == hashedPassword.Trim();
		}

		









	}
}
