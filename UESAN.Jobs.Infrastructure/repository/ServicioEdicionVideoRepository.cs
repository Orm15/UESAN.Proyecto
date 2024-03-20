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
	public class ServicioEdicionVideoRepository : IServicioEdicionVideoRepository
	{
		private readonly OrdenesEventosContext _eventosContext;

		public ServicioEdicionVideoRepository(OrdenesEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}

		//getAll
		public async Task<IEnumerable<ServicioEdicionVideo>> getAll()
		{
			var e = await _eventosContext.ServicioEdicionVideo.Where(x => x.Estado == "activo").ToListAsync();
			if (e.Any()) return e;
			else return null;
		}

		//get by id servicioEdicion
		public async Task<ServicioEdicionVideo> getById(int id)
		{
			var sv = await _eventosContext.ServicioEdicionVideo.Where(x => x.IdServicioEdicionVideo == id && x.Estado == "activo").FirstOrDefaultAsync();
			if (sv == null) return null;
			else return sv;
		}

		//get by id evento
		public async Task<IEnumerable<ServicioEdicionVideo>> getByIdEvento(int id)
		{
			var sv = await _eventosContext.ServicioEdicionVideo.Where(x => x.IdEvento == id && x.Estado == "activo").ToListAsync();
			if (sv == null) return null;
			else return sv;
		}

		//get by usuario
		public async Task<IEnumerable<ServicioEdicionVideo>> getByIdUsuario(int id)
		{
			var e = await _eventosContext.ServicioEdicionVideo.Where(x => x.IdUsuario == id && x.Estado == "activo").ToListAsync();
			if (e == null) return null;
			else return e;
		}



		//insert
		public async Task<ServicioEdicionVideo> Insert(ServicioEdicionVideo sv)
		{
			await _eventosContext.ServicioEdicionVideo.AddAsync(sv);
			int rows = await _eventosContext.SaveChangesAsync();
			if (rows > 0) return sv;
			else return null;
		}

		//update
		public async Task<bool> update(ServicioEdicionVideo sv)
		{
			_eventosContext.ServicioEdicionVideo.Update(sv);
			int rows = _eventosContext.SaveChanges();
			return rows > 0;
		}

		//delete
		public async Task<bool> delete(int id)
		{
			var emp = await _eventosContext.ServicioEdicionVideo.Where(x => x.IdServicioEdicionVideo == id && x.Estado == "activo").FirstOrDefaultAsync();

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
