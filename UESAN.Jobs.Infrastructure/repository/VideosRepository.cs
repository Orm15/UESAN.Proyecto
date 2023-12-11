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
	public class VideosRepository : IVideosRepository
	{
		private readonly OrdenesEventosContext _context;

		public VideosRepository(OrdenesEventosContext context)
		{
			_context = context;
		}

		//getAll
		public async Task<IEnumerable<Videos>> getAll()
		{
			var e = await _context.Videos.ToListAsync();
			if (e.Any()) return e;
			else return null;
		}

		//get by id
		public async Task<Videos> getById(int id)
		{
			var sv = await _context.Videos.Where(x => x.IdVideo == id && x.Estado == "activo" ).FirstOrDefaultAsync();
			if (sv == null) return null;
			else return sv;
		}

		//get by ServiciosId
		public async Task<IEnumerable<Videos>> getByIdServicio(int id)
		{
			var e = await _context.Videos.Where(x => x.IdServicio == id && x.Estado == "activo").ToListAsync();
			if (e == null) return null;
			else return e;
		}

		//GetVideos ByIdEvento
		public async Task<IEnumerable<Videos>> getByIdEvento(int id)
		{
			var e = await _context.Videos.Where(x => x.IdServicioNavigation.IdEvento == id && x.Estado == "activo").ToListAsync();
			if (e == null) return null;
			else return e;
		}

		//insert
		public async Task<Videos> Insert(Videos sv)
		{
			await _context.Videos.AddAsync(sv);
			int rows = await _context.SaveChangesAsync();
			if (rows > 0) return sv;
			else return null;
		}

		//update
		public async Task<bool> update(Videos sv)
		{
			_context.Videos.Update(sv);
			int rows = _context.SaveChanges();
			return rows > 0;
		}

		//get link
		public async Task<string> getLink(int id)
		{
			var sv = await _context.Videos.Where(x => x.IdVideo == id && x.Estado == "activo").FirstOrDefaultAsync();
			if (sv == null) return null;
			else return sv.Link;
		}

		//delete: no hay delete :V
		public async Task<bool> delete(int id)
		{
			var emp = await _context.Videos.Where(x => x.IdVideo == id && x.Estado == "activo").FirstOrDefaultAsync();

			if (emp == null)
			{
				return false;
			}
			emp.Estado = "inactivo";
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<DateTime?> getFechaEventoByIdVideo(int id)
		{
			using (var nuevoContexto = new OrdenesEventosContext())
			{
				var video = await nuevoContexto.Videos
					.Where(x => x.IdVideo == id)
					.Include(y => y.IdServicioNavigation.IdEventoNavigation)
					.FirstOrDefaultAsync();

				if (video == null || video.IdServicioNavigation?.IdEventoNavigation?.FechaEvento == null)
				{
					return null;
				}
				else
				{
					return (DateTime)video.IdServicioNavigation.IdEventoNavigation.FechaEvento;
				}
			}
		}

		public async Task<bool> CambiarEstadoEdicion(int id)
		{
			var video = await _context.Videos.Where(x=> x.IdVideo == id).FirstOrDefaultAsync();
			if (video == null) { return false;}
			else
			{
				int edicion = (int)video.Edicion;
				if(edicion == 0)
				{
					edicion = 1;
				}
				else
				{
					edicion = 0;
				}
				video.Edicion = edicion;
				int rows = await _context.SaveChangesAsync();
				return rows > 0;
			}
		}

	}
}
