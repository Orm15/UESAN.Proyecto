using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Services
{
    public class ServicioService : IServicioService
	{
		private readonly IServiciosRepository _serviciosRepository;

		public ServicioService(IServiciosRepository serviciosRepository)
		{
			_serviciosRepository = serviciosRepository;
		}
		//Insert SERVICIO
		public async Task<int> InsertServicio(ServicioInsertDTO servicioInsertDTO)
		{
			var s = new Servicios()
			{
				IdEvento = servicioInsertDTO.IdEvento,
				Nombre = servicioInsertDTO.Nombre,
				Tipo = servicioInsertDTO.Tipo,
				Estado = "activo"
			};
			var b = await _serviciosRepository.insertServicio(s);
			return b;
		}



		//GETALL SERVICIOS
		public async Task<IEnumerable<ServicioDTO>> GetAll()
		{
			var serve = await _serviciosRepository.getAll();
			if (serve == null)
			{
				return null;
			}
			else
			{
				var sdto = serve.Select(serve => new ServicioDTO
				{
					Estado = serve.Estado,
					IdServicios = serve.IdServicios,
					Nombre = serve.Nombre,
					Tipo = serve.Tipo,
					eventoPrincipal = new EventoPrincipalDTO
					{
						IdEvento = serve.IdEventoNavigation.IdEvento,
						Nombre = serve.IdEventoNavigation.Nombre,
						FechaEvento = serve.IdEventoNavigation.FechaEvento,
						Lugar = serve.IdEventoNavigation.Lugar,
						usuarioPropietario = new UsuarioPropietarioDTO
						{
							IdUsuario = serve.IdEventoNavigation.IdUsuarioNavigation.IdUsuario,
							Nombre = serve.IdEventoNavigation.IdUsuarioNavigation.Nombre
						}
					}

				});
				return sdto;
			}
		}

		//GetALL servicios by idevento

		public async Task<IEnumerable<ServicioDTO>> GetAllByIdEvento(int id)
		{
			var serve = await _serviciosRepository.getAllByIdEvento(id);
			if (serve == null)
			{
				return null;
			}
			else
			{
				var sdto = serve.Select(serve => new ServicioDTO
				{
					Estado = serve.Estado,
					IdServicios = serve.IdServicios,
					Nombre = serve.Nombre,
					Tipo = serve.Tipo,
					eventoPrincipal = new EventoPrincipalDTO
					{
						IdEvento = serve.IdEventoNavigation.IdEvento,
						Nombre = serve.IdEventoNavigation.Nombre,
						FechaEvento = serve.IdEventoNavigation.FechaEvento,
						Lugar = serve.IdEventoNavigation.Lugar,
						usuarioPropietario = new UsuarioPropietarioDTO
						{
							IdUsuario = serve.IdEventoNavigation.IdUsuarioNavigation.IdUsuario,
							Nombre = serve.IdEventoNavigation.IdUsuarioNavigation.Nombre
						}
					}

				});
				return sdto;
			}
		}

		//GetById
		public async Task<ServicioDTO> GetById(int id)
		{
			var serve = await _serviciosRepository.getById(id);
			if (serve == null)
			{
				return null;
			}
			else
			{
				var sdto = new ServicioDTO
				{
					Estado = serve.Estado,
					IdServicios = serve.IdServicios,
					Nombre = serve.Nombre,
					Tipo = serve.Tipo,
					eventoPrincipal = new EventoPrincipalDTO
					{
						IdEvento = serve.IdEventoNavigation.IdEvento,
						Nombre = serve.IdEventoNavigation.Nombre,
						FechaEvento = serve.IdEventoNavigation.FechaEvento,
						Lugar = serve.IdEventoNavigation.Lugar,
						usuarioPropietario = new UsuarioPropietarioDTO
						{
							IdUsuario = serve.IdEventoNavigation.IdUsuarioNavigation.IdUsuario,
							Nombre = serve.IdEventoNavigation.IdUsuarioNavigation.Nombre
						}
					}

				};
				return sdto;
			}
		}

		//modificar
		public async Task<bool> update(ServicioUpdateDTO servicioUpdateDTO)
		{
			return false;
		}

		public async Task<bool> delete(int id)
		{
			var est = await _serviciosRepository.delete(id);
			return est;
		}


	}
}
