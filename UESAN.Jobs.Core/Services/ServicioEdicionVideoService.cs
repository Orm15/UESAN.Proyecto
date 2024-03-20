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
    public class ServicioEdicionVideoService : IServicioEdicionVideoService
	{
		private readonly IServicioEdicionVideoRepository _servicioEdicionVideoRepository;

		public ServicioEdicionVideoService(IServicioEdicionVideoRepository servicioEdicionVideoRepository)
		{
			_servicioEdicionVideoRepository = servicioEdicionVideoRepository;
		}
		//INSERT
		public async Task<int> InsertServicioEdicion(ServicioEdicionVideoInsertDTO x)
		{
			var c = new ServicioEdicionVideo
			{
				IdEvento = x.IdEvento,
				IdUsuario = x.IdUsuario,
				NombreProyecto = x.NombreProyecto,
				FormatoVideo = x.FormatoVideo,
				Destino = x.Destino,
				Musica = x.Musica,
				Logos = x.Logos,
				Objetivo = x.Objetivo,
				NombreEntrevistado = x.NombreEntrevistado,
				CarreraCargoEmpresa = x.CarreraCargoEmpresa,
				DuracionVideo = x.DuracionVideo,
				Estado = "activo"
			};
			var e = await _servicioEdicionVideoRepository.Insert(c);
			if (e != null) { return e.IdServicioEdicionVideo; }
			else return 0;
		}
		//getByid servicio
		public async Task<ServicioEdicionVideoDTO> getbYId(int id)
		{
			var x = await _servicioEdicionVideoRepository.getById(id);
			if (x != null)
			{
				var vdto = new ServicioEdicionVideoDTO
				{
					IdServicioEdicionVideo = x.IdServicioEdicionVideo,
					IdEvento = x.IdEvento,
					IdUsuario = x.IdUsuario,
					NombreProyecto = x.NombreProyecto,
					Objetivo = x.Objetivo,
					Destino = x.Destino,
					FormatoVideo = x.FormatoVideo,
					Musica = x.Musica,
					Logos = x.Logos,
					NombreEntrevistado = x.NombreEntrevistado,
					CarreraCargoEmpresa = x.CarreraCargoEmpresa,
					DuracionVideo = x.DuracionVideo,
				};
				return vdto;
			}
			else return null;
		}
		//getById USUARIO
		public async Task<IEnumerable<ServicioEdicionVideoDTO>> GetBYIdUsuario(int id)
		{
			var s = await _servicioEdicionVideoRepository.getByIdUsuario(id);
			if (s != null)
			{
				var vidto = s.Select(x => new ServicioEdicionVideoDTO
				{
					IdServicioEdicionVideo = x.IdServicioEdicionVideo,
					IdEvento = x.IdEvento,
					IdUsuario = x.IdUsuario,
					NombreProyecto = x.NombreProyecto,
					Objetivo = x.Objetivo,
					Destino = x.Destino,
					FormatoVideo = x.FormatoVideo,
					Musica = x.Musica,
					Logos = x.Logos,
					NombreEntrevistado = x.NombreEntrevistado,
					CarreraCargoEmpresa = x.CarreraCargoEmpresa,
					DuracionVideo = x.DuracionVideo,
				});
				return vidto;
			}
			else { return null; }
		}

		//get by id evento

		public async Task<IEnumerable<ServicioEdicionVideoDTO>> GetBYIdEvento(int id)
		{
			var s = await _servicioEdicionVideoRepository.getByIdEvento(id);
			if (s != null)
			{
				var vidto = s.Select(x => new ServicioEdicionVideoDTO
				{
					IdServicioEdicionVideo = x.IdServicioEdicionVideo,
					IdEvento = x.IdEvento,
					IdUsuario = x.IdUsuario,
					NombreProyecto = x.NombreProyecto,
					Objetivo = x.Objetivo,
					Destino = x.Destino,
					FormatoVideo = x.FormatoVideo,
					Musica = x.Musica,
					Logos = x.Logos,
					NombreEntrevistado = x.NombreEntrevistado,
					CarreraCargoEmpresa = x.CarreraCargoEmpresa,
					DuracionVideo = x.DuracionVideo,
				});
				return vidto;
			}
			else { return null; }
		}

		//getAll

		public async Task<IEnumerable<ServicioEdicionVideoDTO>> GetAll()
		{
			var s = await _servicioEdicionVideoRepository.getAll();
			if (s != null)
			{
				var vidto = s.Select(x => new ServicioEdicionVideoDTO
				{
					IdServicioEdicionVideo = x.IdServicioEdicionVideo,
					IdEvento = x.IdEvento,
					IdUsuario = x.IdUsuario,
					NombreProyecto = x.NombreProyecto,
					Objetivo = x.Objetivo,
					Destino = x.Destino,
					FormatoVideo = x.FormatoVideo,
					Musica = x.Musica,
					Logos = x.Logos,
					NombreEntrevistado = x.NombreEntrevistado,
					CarreraCargoEmpresa = x.CarreraCargoEmpresa,
					DuracionVideo = x.DuracionVideo,
				});
				return vidto;
			}
			else { return null; }
		}

		public async Task<bool> update(ServicioEdicionVideoUpdateDTO servicioEdicion)
		{
			var v = new ServicioEdicionVideo
			{
				IdServicioEdicionVideo = servicioEdicion.IdServicioEdicionVideo,
				IdEvento = servicioEdicion.IdEvento,
				IdUsuario = servicioEdicion.IdUsuario,
				NombreProyecto = servicioEdicion.NombreProyecto,
				FormatoVideo = servicioEdicion.FormatoVideo,
				Destino = servicioEdicion.Destino,
				Musica = servicioEdicion.Musica,
				Logos = servicioEdicion.Logos,
				Objetivo = servicioEdicion.Objetivo,
				NombreEntrevistado = servicioEdicion.NombreEntrevistado,
				CarreraCargoEmpresa = servicioEdicion.CarreraCargoEmpresa,
				DuracionVideo = servicioEdicion.DuracionVideo,
				Estado = "activo"
			};
			var e = await _servicioEdicionVideoRepository.update(v);
			return e;
		}

		//delete

		public async Task<bool> delete(int id)
		{
			var d = await _servicioEdicionVideoRepository.delete(id);
			return d;
		}


	}
}
