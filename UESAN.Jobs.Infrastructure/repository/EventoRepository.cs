using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class EventoRepository : IEventoRepository
	{

		private readonly OrdenesEventosContext _context;

		public EventoRepository(OrdenesEventosContext context)
		{
			_context = context;
		}

		//ADMIN:
		public async Task<IEnumerable<Eventos>> getAll()
		{
			var e = await _context.Eventos.Include(x=> x.IdUsuarioNavigation).ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> insertEvento(Eventos eventos)
		{
			await _context.Eventos.AddAsync(eventos);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		//Estados: Abierto - Confirmado - Atendido

		public async Task<IEnumerable<Eventos>> getEventosByEstado(string cadena)
		{
			var e = await _context.Eventos.Where(x => x.Estado == cadena).ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else
			{
				return null;
			}
		}


		//Cambiar estados: MODIFICAR

		public async Task<bool> CambiarEstado(int idE)
		{

			var e = await _context.Eventos.Where(x => x.IdEvento == idE).FirstOrDefaultAsync();
			if (e == null)
			{
				return false;
			}
			else
			{
				string est = e.Estado;
				if (est == "Abierto")
				{
					est = "Confirmado";
				}
				else if (est == "Confirmado")
				{
					est = "Atendido";
				}
				e.Estado = est;
				int rows = await _context.SaveChangesAsync();
				return rows > 0;
			}
		}




		//GetById
		public async Task<Eventos> getEventosById(int id)
		{
			var e = await _context.Eventos.Where(x => x.IdEvento == id).FirstOrDefaultAsync();
			if (e == null)
			{
				return null;
			}
			else
			{
				return e;
			}
		}
		//GetEventos By idUsuario
		public async Task<IEnumerable<Eventos>> getEventosByUsuario(int id)
		{
			var eve = await _context.Eventos.Where(x=> x.IdUsuario == id).Include(y => y.IdUsuarioNavigation).ToListAsync();
			if (eve.Any())
			{
				return eve;
			}
			else
			{
				return null;
			}
		}

		//Modificar datos de evento:
		public async Task<bool> update(Eventos e)
		{
			_context.Update(e);
			int rows = _context.SaveChanges();
			return rows > 0;
		}

		public async Task<bool> delete(int id)
		{
			var eve = await _context.Eventos.Where(x => x.IdEvento == id).FirstOrDefaultAsync();
			if (eve == null)
			{
				return false;
			}
			else
			{
				eve.Estado = "Eliminado";
				int rows = await _context.SaveChangesAsync();
				return rows > 0;
			}
		}





	}
}
