using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class InteraccionRepository : IInteraccionRepository
	{
		private readonly OrdenEventosContext _eventosContext;

		public InteraccionRepository(OrdenEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}

		public async Task<IEnumerable<Interaccion>> getall()
		{
			return await _eventosContext.Interaccion.ToListAsync();
		}

		public async Task<Interaccion> getByIdInteraccion(int id)
		{
			var interaccion = await _eventosContext.Interaccion
				.Where(x => x.IdInteraccion == id).FirstOrDefaultAsync();
			if (interaccion == null)
			{
				return null;
			}
			else
			{
				return interaccion;
			}
		}

		public async Task<IEnumerable<Interaccion>> getByIdEvento(int id)
		{
			var interacciones = await _eventosContext.Interaccion
				.Where(x => x.IdEvento == id).ToListAsync();
			if (interacciones.Any())
			{
				return interacciones;
			}
			else
			{
				return null;
			}
		}
		//Interacciones en las que el usuario ingresado es creador
		public async Task<IEnumerable<Interaccion>> GetInteraccionesbyIdUsuarioCreador(int id)
		{
			var intera = await _eventosContext.Interaccion.Where(x => x.IdUsuario == id && x.Tipo == "Creador").ToListAsync();
			if (intera.Any())
			{
				return intera;
			}
			else
			{
				return null;
			}
		}


		//Interacciones en las que el usuario es creador o visualizador

		public async Task<IEnumerable<Interaccion>> getInteraccionesByCreadorVisualizador(int idUsuario)
		{
			var interacciones = await _eventosContext.Interaccion.Where(x => x.IdUsuario == idUsuario && (x.Tipo.Equals("Creador") || x.Tipo.Equals("Visualizador"))).ToListAsync();
			if (interacciones.Any())
			{
				return interacciones;
			}
			else
			{
				return null;
			}
		}

		//Interacciones en las que el usuario ingresado es visualizador
		public async Task<IEnumerable<Interaccion>> GetInteraccionesbyIdUsuarioVisualizador(int id)
		{
			var intera = await _eventosContext.Interaccion.Where(x => x.IdUsuario == id && x.Tipo == "Visualizador").ToListAsync();
			if (intera.Any())
			{
				return intera;
			}
			else
			{
				return null;
			}
		}
		//RELACIONADO A USUARIOS
		//Las interacciones de visualizacion  dado un idEvento  
		public async Task<IEnumerable<Interaccion>> GetInteraccionesVisualizacionByIdEvento(int id)
		{
			var intera = await _eventosContext.Interaccion.Where(x => x.IdEvento == id && x.Tipo == "Visualizador")
				.Include(y=> y.IdUsuarioNavigation).ToListAsync();
			if (intera.Any())
			{
				return intera;
			}
			else
			{
				return null;
			}
		}

		//Las interacciones de creacion  dado un idEvento  
		public async Task<Interaccion> GetInteraccioncreadorByIdEvento(int id)
		{
			var intera = await _eventosContext.Interaccion.Where(x => x.IdEvento == id && x.Tipo == "Creador")
				.Include(y=> y.IdUsuarioNavigation).FirstOrDefaultAsync();
			if (intera != null)
			{
				return intera;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> interaccionInsert(Interaccion interaccion)
		{
			await _eventosContext.Interaccion.AddAsync(interaccion);
			int rows = await _eventosContext.SaveChangesAsync();
			return rows > 0;
		}








	}
}
