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
	internal class EventoRepository
	{
		private readonly OrdenEventosContext _context;

		public EventoRepository(OrdenEventosContext context) { 
			_context = context;
		}

		//ADMIN:
		public async Task<IEnumerable<Eventos>> getAll() { 
			var e =  await _context.Eventos.ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else {
				return null;
			}
		}

		//Estados: EnEspera - Activo - Culminado
		//vizualizar
		public async Task<IEnumerable<Eventos>> getEventosEspera() { 
			var e = await _context.Eventos.Where(x=> x.Estado == "EnEspera").ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else {
				return null;
			}
		}

		public async Task<IEnumerable<Eventos>> getEventosActivos()
		{
			var e = await _context.Eventos.Where(x => x.Estado == "Activo").ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else
			{
				return null;
			}
		}

		public async Task<IEnumerable<Eventos>> getEventosCulminado()
		{
			var e = await _context.Eventos.Where(x => x.Estado == "Culminado").ToListAsync();
			if (e.Any())
			{
				return e;
			}
			else
			{
				return null;
			}
		}

		//Cambiar estados:

		public async Task<bool> CambiarEstado(string est, int idE) { 
			var e = await _context.Eventos.Where(x=> x.IdEvento == idE).FirstOrDefaultAsync();
			if (e == null)
			{
				return false;
			}
			else { 
				e.Estado = est;
				int rows = await _context.SaveChangesAsync();
				return rows > 0;
			}
		}

		//Eventos creados por una persona:



		//GetById
		public async Task<Eventos> getEventosById(int id)
		{
			var e = await _context.Eventos.Where(x=> x.IdEvento==id).FirstOrDefaultAsync();	
			if(e == null)
			{
				return null;
			}
			else
			{
				return e;
			}
		}

		//Modificar datos de evento:
		public async Task<bool> update(Eventos e)
		{
			_context.Update(e);
			int rows = _context.SaveChanges();
			return rows > 0;

		}
		 








	}
}
