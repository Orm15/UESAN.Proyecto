using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UESAN.proyecto.Infrastructure.repository
{
	public class UsuarioRepository 
	{
		/*
		private readonly OrdenEventosContext _context;

		public UsuarioRepository(OrdenEventosContext context)
		{
			_context = context;
		}
		//Funcion del admin
		public async Task<IEnumerable<Usuarios>> getAll()
		{

			return await _context.Usuarios.ToListAsync();
		}

		public async Task<int> Insert(Usuarios u)
		{
			await _context.Usuarios.AddAsync(u);
			int rows = await _context.SaveChangesAsync();
			if (rows > 0)
			{
				return u.IdUsuario;
			}
			else
			{
				return 0;
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

		public async Task<Usuarios> SigIn(string username)
		{
			var u = await _context.Usuarios.Where(x => x.Correo == username && x.Estado == "activo")
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




		*/

	}
}
