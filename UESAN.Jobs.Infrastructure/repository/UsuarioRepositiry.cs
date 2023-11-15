using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;

namespace UESAN.proyecto.Infrastructure.repository
{
	internal class UsuarioRepositiry
	{
		private readonly OrdenEventosContext _context;

		public UsuarioRepositiry(OrdenEventosContext context) {
			_context = context;
		}
		//Funcion del admin
		public async Task<IEnumerable<Usuarios>> getAll() {

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



	}
}
