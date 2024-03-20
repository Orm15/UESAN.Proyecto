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
	public class CircuitoCerradoRepository : ICircuitoCerradoRepository
	{
		private readonly OrdenesEventosContext _eventosContext;

		public CircuitoCerradoRepository(OrdenesEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}

		public async Task<IEnumerable<CircuitoCerrado>> getAll()
		{
			var c = await _eventosContext.CircuitoCerrado.Where(x => x.Estado == "activo").ToListAsync();
			if (c.Any()) return c;
			else return null;
		}

		public async Task<CircuitoCerrado> getById(int id)
		{
			var c = await _eventosContext.CircuitoCerrado.Where(x => x.IdCircuitoCerrado == id).FirstOrDefaultAsync();
			if (c != null) return c;
			else return null;
		}

		public async Task<CircuitoCerrado> getByIdEvento(int id)
		{
			var c = await _eventosContext.CircuitoCerrado.Where(x => x.IdServicioNavigation.IdEventoNavigation.IdEvento == id)
				.Include(x => x.IdServicioNavigation.IdEventoNavigation).FirstOrDefaultAsync();
			if (c != null) return c;
			else return null;
		}

		public async Task<CircuitoCerrado> getByIdServicio(int id)
		{
			var c = await _eventosContext.CircuitoCerrado.Where(x => x.IdServicio == id)
				.Include(x => x.IdServicioNavigation.IdEventoNavigation).FirstOrDefaultAsync();
			if (c != null) return c;
			else return null;
		}

		public async Task<bool> update(CircuitoCerrado circuito)
		{
			_eventosContext.CircuitoCerrado.Update(circuito);
			int rows = _eventosContext.SaveChanges();
			return rows > 0;
		}

		public async Task<CircuitoCerrado> Insert(CircuitoCerrado sv)
		{
			await _eventosContext.CircuitoCerrado.AddAsync(sv);
			int rows = await _eventosContext.SaveChangesAsync();
			if (rows > 0) return sv;
			else return null;
		}

		//delete: no hay delete :V
		public async Task<bool> delete(int id)
		{
			var emp = await _eventosContext.CircuitoCerrado.Where(x => x.IdCircuitoCerrado == id && x.Estado == "activo").FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.Estado = "inactivo";
			int rows = await _eventosContext.SaveChangesAsync();
			return rows > 0;
		}

	}
}
