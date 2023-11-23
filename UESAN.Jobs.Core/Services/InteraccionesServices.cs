using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.Proyecto.Core.Services
{
	public  class InteraccionesServices
	{
		private readonly IInteraccionRepository _interaccionRepository;

		public InteraccionesServices(IInteraccionRepository interaccionRepository)
		{
			_interaccionRepository = interaccionRepository;
		}	


		//Interacciones en las que el usuario dado fue creador:
		public async Task<IEnumerable<InteraccionDTO>> InteraccionesCreadorByUsuario(int id)
		{
			var interacciones = await _interaccionRepository.GetbyIdUsuarioCreador(id);
			if (interacciones.Any())
			{
				var idto = interacciones.Select(e => new InteraccionDTO
				{
					IdEvento = e.IdEvento,
					IdUsuario = e.IdUsuario,
					Descripcion = e.Descripcion,
					Tipo = e.Tipo,
					IdInteraccion = e.IdInteraccion,

				});

				return idto;

			}
			else {
				return null;
			}
		}

		//Interacciones en las que el usuario dado fue visualizador
		//rev
		public async Task<IEnumerable<InteraccionDTO>> InteraccionesvisualizadorByUsuario(int id)
		{
			var interacciones = await _interaccionRepository.GetInteraccionesbyIdUsuarioVisualizador(id);
			if (interacciones.Any())
			{
				var idto = interacciones.Select(e => new InteraccionDTO
				{
					IdEvento = e.IdEvento,
					IdUsuario = e.IdUsuario,
					Descripcion = e.Descripcion,
					Tipo = e.Tipo,
					IdInteraccion = e.IdInteraccion,

				});

				return idto;

			}
			else
			{
				return null;
			}
		}

		//Crear una interaccion del tipo Creador
		public async Task<bool> insertInteraccionCreador(InteraccionInsertDTO interaccion)
		{
			var interac = new Interaccion
			{
				IdEvento = interaccion.IdEvento,
				IdUsuario = interaccion.IdUsuario,
				Descripcion = interaccion.Descripcion,
				Tipo = "Creador",
			};

			return await _interaccionRepository.interaccionInsert(interac);
		}

		//Crear una interaccion del tipo visualizador
		public async Task<bool> insertInteraccionVisualizador(InteraccionInsertDTO interaccion)
		{
			var interac = new Interaccion
			{
				IdEvento = interaccion.IdEvento,
				IdUsuario = interaccion.IdUsuario,
				Descripcion = interaccion.Descripcion,
				Tipo = "Visualizador",
			};

			return await _interaccionRepository.interaccionInsert(interac);
		}




	}
}
