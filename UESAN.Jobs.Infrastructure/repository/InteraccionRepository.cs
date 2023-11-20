using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class InteraccionRepository
	{
		private readonly OrdenEventosContext _eventosContext;

		public InteraccionRepository(OrdenEventosContext eventosContext)
		{
			_eventosContext = eventosContext;
		}

		public async Task<IEnumerable<Interaccion>> getall() {
			return await _eventosContext.Interaccion.ToListAsync();
		}

		public async Task<Interaccion> getByIdInteraccion(int id) { 
			var interaccion= await _eventosContext.Interaccion
				.Where(x=>x.IdInteraccion == id).FirstOrDefaultAsync();
			if (interaccion == null)
			{
				return null;
			}
			else {
				return interaccion;
			}
		}

		public async Task<IEnumerable<Interaccion>> getByIdEvento(int id) {
			var interacciones = await _eventosContext.Interaccion
				.Where(x=> x.IdEvento == id).ToListAsync();
			if (interacciones.Any())
			{
				return interacciones;
			}
			else {
				return null;
			}
		}
		//Interacciones en las que el usuario ingresado es creador
		public async Task<IEnumerable<Interaccion>> GetbyIdUsuarioCreador(int id)
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



		
	}
}
