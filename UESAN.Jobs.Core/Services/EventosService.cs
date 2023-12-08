using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.Proyecto.Core.Services
{
	public class EventosService
	{
		
		private readonly IEventoRepository _eventoRepository;
		

		public EventosService(IEventoRepository eventoRepository)
		{
			_eventoRepository = eventoRepository;
		}
		 
		public async Task<IEnumerable<EventosDTO>> getAll()
		{
			var eve = await _eventoRepository.getAll();
			if (eve == null)
			{
				return null;
			}
			else
			{
				var EveDTO = eve.Select(e => new EventosDTO
				{
					IdEvento = e.IdEvento,
					Nombre = e.Nombre,
					Descripcion = e.Descripcion,
					FechaEvento = e.FechaEvento,
					FechaCreacion = e.FechaCreacion,
					HoraFin = e.HoraFin,
					HoraInicio = e.HoraInicio,
					Lugar = e.Lugar,
					Estado = e.Estado,
					MomentosImportantes = e.MomentosImportantes,
					CantidadInvitados = e.CantidadInvitados,

				});
				return EveDTO;
			}

		}

		public async Task<bool> InsertEvento(EventoInsertDTO eventoInsertDTO)
		{
			var Eve = new Eventos()
			{
				Nombre = eventoInsertDTO.Nombre,
				Descripcion = eventoInsertDTO.Descripcion,
				Estado = "Abierto",
				FechaCreacion = eventoInsertDTO.FechaCreacion,
				FechaEvento = eventoInsertDTO.FechaEvento,
				HoraFin = eventoInsertDTO.HoraFin,
				HoraInicio = eventoInsertDTO.HoraInicio,
				Lugar = eventoInsertDTO.Lugar,
				MomentosImportantes = eventoInsertDTO.MomentosImportantes,
				CantidadInvitados = eventoInsertDTO.CantidadInvitados,
			};
			var b = await _eventoRepository.insertEvento(Eve);
			return b;
		}

		//Cambiar estado

		public async Task<bool> CambiarEstado(int id)
		{
			return await _eventoRepository.CambiarEstado(id);
		}

		public async Task<IEnumerable<EventosDTO>> EventosByEstado(string r)
		{
			var eve = await _eventoRepository.getEventosByEstado(r);
			var dto = eve.Select(e => new EventosDTO
			{
				IdEvento = e.IdEvento,
				Nombre = e.Nombre,
				Descripcion = e.Descripcion,
				FechaEvento = e.FechaEvento,
				FechaCreacion = e.FechaCreacion,
				HoraFin = e.HoraFin,
				HoraInicio = e.HoraInicio,
				Lugar = e.Lugar,
				Estado = e.Estado,
				MomentosImportantes = e.MomentosImportantes,
				CantidadInvitados = e.CantidadInvitados,
			});

			if (dto.Any())
			{
				return dto;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> Update(EventoUpdateDTO eventoUpdateDTO)
		{

			DateTime fechaActual = DateTime.Now;
			int diferencia = (eventoUpdateDTO.FechaEvento - fechaActual).Value.Days;
			if (diferencia >= 2 && eventoUpdateDTO.Estado.Equals("Abierto"))
			{
				var eve = new Eventos()
				{
					IdEvento = eventoUpdateDTO.IdEvento,
					Nombre = eventoUpdateDTO.Nombre,
					Descripcion = eventoUpdateDTO.Descripcion,
					FechaEvento = eventoUpdateDTO.FechaEvento,
					FechaCreacion = eventoUpdateDTO.FechaCreacion,
					HoraFin = eventoUpdateDTO.HoraFin,
					HoraInicio = eventoUpdateDTO.HoraInicio,
					Lugar = eventoUpdateDTO.Lugar,
					Estado = "Abierto",
					MomentosImportantes = eventoUpdateDTO.MomentosImportantes,
					CantidadInvitados = eventoUpdateDTO.CantidadInvitados,
				};
				return await _eventoRepository.update(eve);
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> delete(int id)
		{
			return await _eventoRepository.delete(id);
		}

		//Dame los eventos donde  dado el idUsuario retorne todos donde fue creador

		

		//Eventos donde el usuario dado fue creador o vizualizador

		
		//Eventos donde el usuario es un visualizador solo eso

		








		
	}
		
}
