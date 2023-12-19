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
	public class EscenasVideoRepository : IEscenasVideoRepository
	{
		private readonly OrdenesEventosContext _eventosContext;

		public EscenasVideoRepository(OrdenesEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}


		//getAll
		public async Task<IEnumerable<EscenasVideo>> getAll()
		{
			var e = await _eventosContext.EscenasVideo.Where(x => x.Estado == "activo").ToListAsync();
			if (e.Any()) return e;
			else return null;
		}

		//get by id
		public async Task<EscenasVideo> getById(int id)
		{
			var sv = await _eventosContext.EscenasVideo.Where(x => x.IdEscena == id && x.Estado == "activo").FirstOrDefaultAsync();
			if (sv == null) return null;
			else return sv;
		}

		//get by idServicioEdicion // osea todos las escenas que componen un video
		public async Task<IEnumerable<EscenasVideo>> getByIdServicioEdicion(int id)
		{
			var e = await _eventosContext.EscenasVideo.Where(x => x.IdServicioEdicionVideo == id && x.Estado == "activo").ToListAsync();
			if (e == null) return null;
			else return e;
		}



		//insert
		public async Task<EscenasVideo> Insert(EscenasVideo sv)
		{
			await _eventosContext.EscenasVideo.AddAsync(sv);
			int rows = await _eventosContext.SaveChangesAsync();
			if (rows > 0) return sv;
			else return null;
		}

		//update
		public async Task<bool> update(EscenasVideo sv)
		{
			_eventosContext.EscenasVideo.Update(sv);
			int rows = _eventosContext.SaveChanges();
			return rows > 0;
		}

		//delete
		public async Task<bool> delete(int id)
		{
			var emp = await _eventosContext.EscenasVideo.Where(x => x.IdEscena == id && x.Estado == "activo").FirstOrDefaultAsync();

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
