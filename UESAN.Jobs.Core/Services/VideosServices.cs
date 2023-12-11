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
    public class VideosServices : IVideosServices
	{
		private readonly IVideosRepository _videosRepository;
		private readonly IServiciosRepository _serviciosRepository;

		public VideosServices(IVideosRepository videosRepository, IServiciosRepository serviciosRepository)
		{
			_videosRepository = videosRepository;
			_serviciosRepository = serviciosRepository;
		}
		//Crear video
		public async Task<int> InsertVideo(VideosInsertDTO videosInsertDTO)
		{
			DateTime fecha = DateTime.Now;
			var edi = new Videos
			{
				IdServicio = videosInsertDTO.IdServicio,
				Edicion = videosInsertDTO.Edicion,
				Estado = "activo",
				FechaSubida = fecha,
				Link = videosInsertDTO.Link,
				Nombre = videosInsertDTO.Nombre,
				LugarFilmacion = videosInsertDTO.LugarFilmacion,
				NombreObjetivo = videosInsertDTO.NombreObjetivo,
			};
			var e = await _videosRepository.Insert(edi);
			if (e != null) { return e.IdVideo; }
			else return 0;
		}

		//GetAll
		public async Task<IEnumerable<VideosDTO>> GetAll()
		{
			var video = await _videosRepository.getAll();
			if (video != null)
			{
				var vidto = video.Select(x => new VideosDTO
				{
					IdServicio = x.IdServicio,
					Edicion = x.Edicion,
					Estado = x.Estado,
					IdVideo = x.IdVideo,
					Link = x.Link,
					Nombre = x.Nombre,
					NombreObjetivo = x.NombreObjetivo,
					FechaSubida = x.FechaSubida,
					LugarFilmacion = x.LugarFilmacion,
				});
				return vidto;
			}
			else { return null; }
		}

		//getByid video
		public async Task<VideosDTO> getbYIdVideo(int id)
		{
			var x = await _videosRepository.getById(id);
			if (x != null)
			{
				var vdto = new VideosDTO
				{
					IdServicio = x.IdServicio,
					Edicion = x.Edicion,
					Estado = x.Estado,
					IdVideo = x.IdVideo,
					Link = x.Link,
					Nombre = x.Nombre,
					NombreObjetivo = x.NombreObjetivo,
					FechaSubida = x.FechaSubida,
					LugarFilmacion = x.LugarFilmacion,
				};
				return vdto;
			}
			else return null;
		}

		//getByIdSerivcio
		public async Task<IEnumerable<VideosDTO>> GetBYIdServicio(int id)
		{
			var video = await _videosRepository.getByIdServicio(id);
			if (video != null)
			{
				var vidto = video.Select(x => new VideosDTO
				{
					IdServicio = x.IdServicio,
					Edicion = x.Edicion,
					Estado = x.Estado,
					IdVideo = x.IdVideo,
					Link = x.Link,
					Nombre = x.Nombre,
					NombreObjetivo = x.NombreObjetivo,
					FechaSubida = x.FechaSubida,
					LugarFilmacion = x.LugarFilmacion,
				});
				return vidto;
			}
			else { return null; }
		}

		//getByIdEvento
		public async Task<IEnumerable<VideosDTO>> GetBYIdEvento(int id)
		{
			var video = await _videosRepository.getByIdEvento(id);
			if (video != null)
			{
				var vidto = video.Select(x => new VideosDTO
				{
					IdServicio = x.IdServicio,
					Edicion = x.Edicion,
					Estado = x.Estado,
					IdVideo = x.IdVideo,
					Link = x.Link,
					Nombre = x.Nombre,
					NombreObjetivo = x.NombreObjetivo,
					FechaSubida = x.FechaSubida,
					LugarFilmacion = x.LugarFilmacion,
				});
				return vidto;
			}
			else { return null; }
		}
		//update //corregir
		public async Task<bool> update(VideosUpdateDTO videosUpdateDTO)
		{
			DateTime fec = (DateTime)(await _serviciosRepository.getById((int)videosUpdateDTO.IdServicio)).IdEventoNavigation.FechaEvento;
			DateTime fechaActual = DateTime.Now;
			int diferencia = (fec - fechaActual).Days;
			if (diferencia >= 4)
			{
				var v = new Videos
				{
					IdServicio = videosUpdateDTO.IdServicio,
					IdVideo = videosUpdateDTO.IdVideo,
					Link = videosUpdateDTO.Link,
					FechaSubida = videosUpdateDTO.FechaSubida,
					Edicion = videosUpdateDTO.Edicion,
					Estado = "activo",
					LugarFilmacion = videosUpdateDTO.LugarFilmacion,
					Nombre = videosUpdateDTO.Nombre,
					NombreObjetivo = videosUpdateDTO.NombreObjetivo
				};
				var e = await _videosRepository.update(v);
				return e;
			}
			else
			{
				return false;
			}

		}

		//delete
		public async Task<bool> delete(int id)
		{
			return await _videosRepository.delete(id);
		}

		public async Task<bool> CmabiarEstadoEdicion(int id)
		{
			return await _videosRepository.CambiarEstadoEdicion(id);
		}



	}
}
