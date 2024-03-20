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
    public class EscenaVideoService : IEscenaVideoService
	{
		private readonly IEscenasVideoRepository _repository;

		public EscenaVideoService(IEscenasVideoRepository repository)
		{
			_repository = repository;
		}


		//INSERT escena
		public async Task<bool> InsertCC(EscenasVideoInsertDTO escenasVideoInsertDTO)
		{
			var c = new EscenasVideo
			{
				IdServicioEdicionVideo = escenasVideoInsertDTO.IdServicioEdicionVideo,
				IdVideo = escenasVideoInsertDTO.IdVideo,
				Cambios = escenasVideoInsertDTO.Cambios,
				DescripcionEscena = escenasVideoInsertDTO?.DescripcionEscena,
				Estado = "activo",
				LinkVideo = escenasVideoInsertDTO?.LinkVideo,
				NombreEscena = escenasVideoInsertDTO?.NombreEscena,
				NombreVideo = escenasVideoInsertDTO.NombreVideo,
				Tiempo = escenasVideoInsertDTO?.Tiempo,
			};
			var e = await _repository.Insert(c);
			if (e != null) { return true; }
			else return false;
		}


		//GETALL BYID SERVICIO EDICION
		public async Task<IEnumerable<EscenasVideoDTO>> GetAllByIdServicioEdicion(int id)
		{
			var c = await _repository.getByIdServicioEdicion(id);
			if (c != null)
			{
				var vidto = c.Select(x => new EscenasVideoDTO
				{
					IdEscena = x.IdEscena,
					IdVideo = x.IdVideo,
					NombreEscena = x.NombreEscena,
					DescripcionEscena = x.DescripcionEscena,
					LinkVideo = x.LinkVideo,
					NombreVideo = x.NombreVideo,
					Cambios = x.Cambios,
					Tiempo = x.Tiempo,
				});
				return vidto;
			}
			else { return null; }
		}

		//GETALL BYID  
		public async Task<EscenasVideoDTO> GetAllById(int id)
		{
			var c = await _repository.getById(id);
			if (c != null)
			{
				var vidto = new EscenasVideoDTO
				{
					IdEscena = c.IdEscena,
					IdVideo = c.IdVideo,
					NombreEscena = c.NombreEscena,
					DescripcionEscena = c.DescripcionEscena,
					LinkVideo = c.LinkVideo,
					NombreVideo = c.NombreVideo,
					Cambios = c.Cambios,
					Tiempo = c.Tiempo,
				};
				return vidto;
			}
			else { return null; }
		}

		//update

		public async Task<bool> update(EscenasVideoUpdateDTO escenasVideoUpdate)
		{
			var v = new EscenasVideo
			{
				IdEscena = escenasVideoUpdate.IdEscena,
				IdServicioEdicionVideo = escenasVideoUpdate.IdServicioEdicionVideo,
				IdVideo = escenasVideoUpdate.IdVideo,
				DescripcionEscena = escenasVideoUpdate?.DescripcionEscena,
				NombreEscena = escenasVideoUpdate.NombreEscena,
				NombreVideo = escenasVideoUpdate.NombreVideo,
				LinkVideo = escenasVideoUpdate.LinkVideo,
				Estado = "activo",
				Tiempo = escenasVideoUpdate.Tiempo,
				Cambios = escenasVideoUpdate.Cambios
			};
			var e = await _repository.update(v);
			return e;
		}

		//delete

		public async Task<bool> delete(int id)
		{
			var d = await _repository.delete(id);
			return d;
		}




	}
}
