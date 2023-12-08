using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace UESAN.Proyecto.Core.Services
{
	public class EventosService
	{
		/*
		private readonly IEventoRepository _eventoRepository;
		private readonly IInteraccionRepository _interaccionRepository;
		

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

		public async Task<IEnumerable<EventosDTO>> getEventosCreadorByIdUsuario(int idUsuario)
		{
			var interacciones = await _interaccionRepository.GetInteraccionesbyIdUsuarioCreador(idUsuario);
			if (interacciones.Any())
			{
				List < Eventos > eve = new List < Eventos >();
				int idEvento;
				foreach (var item in interacciones)
                {
					idEvento = (int)item.IdEvento;
					var e = await _eventoRepository.getEventosById(idEvento);
					eve.Add(e);
                }

				var eventosD = eve.Select(x => new EventosDTO
				{
					IdEvento = x.IdEvento,
					Descripcion = x.Descripcion,
					HoraFin = x.HoraFin,
					HoraInicio = x.HoraInicio,
					Nombre = x.Nombre,
					FechaCreacion = x.FechaCreacion,
					FechaEvento = x.FechaEvento,
					Lugar = x.Lugar,
					Estado = x.Estado,
					MomentosImportantes = x.MomentosImportantes,
					CantidadInvitados = x.CantidadInvitados

				});

				return eventosD;  

            }
			else {
				return null;
			}
		}

		//Eventos donde el usuario dado fue creador o vizualizador

		public async Task<IEnumerable<EventosDTO>> GetEventosCreadorVisualizadorByIdUsuario(int id)
		{
			var interacciones = await _interaccionRepository.getInteraccionesByCreadorVisualizador(id);
			if (interacciones.Any())
			{
				int idEve;
				List<Eventos> eventos = new List<Eventos>();
                foreach (var item in interacciones)
                {
					idEve = (int)item.IdEvento;
					var e = await _eventoRepository.getEventosById(idEve);
					eventos.Add(e);
                }
				var ev = eventos.Select(x => new EventosDTO
				{
					IdEvento = x.IdEvento,
					Descripcion = x.Descripcion,
					HoraFin = x.HoraFin,
					HoraInicio = x.HoraInicio,
					Nombre = x.Nombre,
					FechaCreacion = x.FechaCreacion,
					FechaEvento = x.FechaEvento,
					Lugar = x.Lugar,
					Estado = x.Estado,
					MomentosImportantes = x.MomentosImportantes,
					CantidadInvitados = x.CantidadInvitados
				});

				return ev;

            }
			else {
				return null;
			}
		}
		//Eventos donde el usuario es un visualizador solo eso

		public async Task<IEnumerable<EventosDTO>> GetEventosVisualizadorByIdUsuario(int id)
		{
			var interacciones = await _interaccionRepository.GetInteraccionesbyIdUsuarioVisualizador(id);
			if (interacciones.Any())
			{
				int idEve;
				List<Eventos> eventos = new List<Eventos>();
				foreach (var item in interacciones)
				{
					idEve = (int)item.IdEvento;
					var e = await _eventoRepository.getEventosById(idEve);
					eventos.Add(e);
				}
				var ev = eventos.Select(x => new EventosDTO
				{
					IdEvento = x.IdEvento,
					Descripcion = x.Descripcion,
					HoraFin = x.HoraFin,
					HoraInicio = x.HoraInicio,
					Nombre = x.Nombre,
					FechaCreacion = x.FechaCreacion,
					FechaEvento = x.FechaEvento,
					Lugar = x.Lugar,
					Estado = x.Estado,
					MomentosImportantes = x.MomentosImportantes,
					CantidadInvitados = x.CantidadInvitados
				});

				return ev;

			}
			else
			{
				return null;
			}
		}








		*/
	}
		
}
