using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Services
{
    public class EventosService : IEventosService
	{

		private readonly IEventoRepository _eventoRepository;
		private readonly IUsuarioRepository _usuarioRepository;


		public EventosService(IEventoRepository eventoRepository, IUsuarioRepository usuarioRepository)
		{
			_eventoRepository = eventoRepository;
			_usuarioRepository = usuarioRepository;
			
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
					usuarioPropietario = new UsuarioPropietarioDTO()
					{
						IdUsuario = e.IdUsuarioNavigation.IdUsuario,
						Nombre = e.IdUsuarioNavigation.Nombre
					}

				});
				return EveDTO;
			}

		}

		public async Task<int> InsertEvento(EventoInsertDTO eventoInsertDTO)
		{
			DateTime now = DateTime.Now;
			var Eve = new Eventos()
			{
				Nombre = eventoInsertDTO.Nombre,
				Descripcion = eventoInsertDTO.Descripcion,
				Estado = "Abierto",
				FechaCreacion = now,
				FechaEvento = eventoInsertDTO.FechaEvento,
				HoraFin = eventoInsertDTO.HoraFin,
				HoraInicio = eventoInsertDTO.HoraInicio,
				Lugar = eventoInsertDTO.Lugar,
				MomentosImportantes = eventoInsertDTO.MomentosImportantes,
				CantidadInvitados = eventoInsertDTO.CantidadInvitados,
				IdUsuario = eventoInsertDTO.IdUsuario

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
			if(eve == null)
			{
				return null;
			}
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
				usuarioPropietario = new UsuarioPropietarioDTO()
				{
					IdUsuario = e.IdUsuarioNavigation.IdUsuario,
					Nombre = e.IdUsuarioNavigation.Nombre
				}
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
					IdUsuario = eventoUpdateDTO.IdUsuario,
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

		public async Task<IEnumerable<EventosDTO>> GetEventosByUsuarioCreador(int id)
		{
			var eve = await _eventoRepository.getEventosByUsuario(id);
			if (eve == null)
			{
				return null;
			}
			else
			{
				var ed = eve.Select(e => new EventosDTO
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
					usuarioPropietario = new UsuarioPropietarioDTO()
					{
						IdUsuario = e.IdUsuarioNavigation.IdUsuario,
						Nombre = e.IdUsuarioNavigation.Nombre
					}
				});
				return ed;
			}

		}
		//Eventos donde el usuario dado fue creador o vizualizador
		public async Task<IEnumerable<EventosDTO>> getEventosByUsuarioCreadorOrVizualizador(int id)
		{
			var usu = await _usuarioRepository.getById(id);
			if(usu!= null)
			{
				var eve = await _eventoRepository.GetEventosByUsuarioCreadorOrVizualizador(id, usu.Area);
				if(eve!= null)
				{
					var eveDTO = eve.Select(e => new EventosDTO
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
						usuarioPropietario = new UsuarioPropietarioDTO()
						{
							IdUsuario = e.IdUsuarioNavigation.IdUsuario,
							Nombre = e.IdUsuarioNavigation.Nombre
						}
					});
					return eveDTO;
				}
				else
				{
					return null;
				}

			}
			else
			{
				return null;
			}
			
			
		}

		//Eventos donde el usuario es un visualizador solo eso (Por el area)
		public async Task<IEnumerable<EventosDTO>> getEventosByUsuarioVizualizador(int id)
		{
			var Usuario = await _usuarioRepository.getById(id);
			if(Usuario != null)
			{
				var events = await _eventoRepository.getAllByIdMismaArea(Usuario.Area);
				if (events != null)
				{
					var ed = events.Select(e => new EventosDTO
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
						usuarioPropietario = new UsuarioPropietarioDTO()
						{
							IdUsuario = e.IdUsuarioNavigation.IdUsuario,
							Nombre = e.IdUsuarioNavigation.Nombre
						}
					});
					return ed;
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
			
			
			

		}

		//Evento get By ID evento
		public async Task<EventosDTO> getById(int id)
		{
			var e = await _eventoRepository.getEventosById(id);
			if(e == null)
			{
				return null;
			}
			else
			{
				return new EventosDTO
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
					usuarioPropietario = new UsuarioPropietarioDTO()
					{
						IdUsuario = e.IdUsuarioNavigation.IdUsuario,
						Nombre = e.IdUsuarioNavigation.Nombre
					}
				};
			}
		}










	}

}
