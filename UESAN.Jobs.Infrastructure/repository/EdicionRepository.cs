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
	public class EdicionRepository : IEdicionRepository
	{
		private readonly OrdenesEventosContext _eventosContext;

		public EdicionRepository(OrdenesEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}

		//insert
		public async Task<Edicion> Insert(Edicion sv)
		{
			await _eventosContext.Edicion.AddAsync(sv);
			int rows = await _eventosContext.SaveChangesAsync();
			if (rows > 0) return sv;
			else return null;
		}

		//GETBYID VIDEO
		public async Task<Edicion> GetByIdVideo(int id)
		{
			var edicion = await _eventosContext.Edicion.Where(x => x.IdVideo == id && x.Estado == "activo" && x.IdVideoNavigation.Estado == "activo").FirstOrDefaultAsync();
			if (edicion == null) { return null; }
			else { return edicion; }
		}
		//GETBYIDEDICION
		public async Task<Edicion> GetByIdEdicion(int id)
		{
			var edicion = await _eventosContext.Edicion.Where(x => x.IdEdicion == id && x.Estado == "activo").FirstOrDefaultAsync();
			if (edicion == null) { return null; }
			else { return edicion; }
		}
		//GetAll
		public async Task<IEnumerable<Edicion>> getAll()
		{
			var edicion = await _eventosContext.Edicion.Where(x=> x.Estado == "activo").ToListAsync();
			if (!edicion.Any()) { return null; }
			else { return edicion; }
		}

		//Update edicion
		public async Task<bool> update(Edicion sv)
		{
			_eventosContext.Edicion.Update(sv);
			int rows = _eventosContext.SaveChanges();
			return rows > 0;
		}
		//delete
		//delete: no hay delete :V
		public async Task<bool> delete(int id)
		{
			var emp = await _eventosContext.Edicion.Where(x => x.IdEdicion == id && x.Estado == "activo").FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.Estado = "inactivo";
			int rows = await _eventosContext.SaveChangesAsync();
			return rows > 0;
		}

		/*public async Task<DateTime?> getFechaEventoByIdEdicion(int id)
		{
			using (var nuevoContexto = new OrdenesEventosContext())
			{
				var video = await nuevoContexto.Edicion
					.Where(x => x.IdEdicion == id)
					.Include(y => y.IdVideoNavigation.IdServicioNavigation.IdEventoNavigation)
					.FirstOrDefaultAsync();
				var fecha = video.IdVideoNavigation.IdServicioNavigation?.IdEventoNavigation?.FechaEvento;

				if (video == null || fecha == null)
				{
					return null;
				}
				else
				{
					return (DateTime)fecha;
				}
			}
		}
		*/


	}
}
