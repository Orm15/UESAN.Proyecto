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
    public class EdicionService : IEdicionService
	{
		private readonly IEdicionRepository _edicionRepo;

		public EdicionService(IEdicionRepository edicionRepo)
		{
			_edicionRepo = edicionRepo;
		}

		//Insert Edicion
		public async Task<bool> InsertEdicion(EdicionInsertDTO edicionInsertDTO)
		{
			var e = new Edicion()
			{
				IdVideo = edicionInsertDTO.IdVideo,
				Descripción = edicionInsertDTO.Descripción,
				Estado = "activo",
				Musica = edicionInsertDTO.Musica,
				Nombre = edicionInsertDTO.Nombre

			};
			var es = await _edicionRepo.Insert(e);
			if (es != null) return true;
			else return false;
		}
		//GETBYID EDICION
		public async Task<EdicionDTO> GetByIdEdicion(int idEdi)
		{
			var edicion = await _edicionRepo.GetByIdEdicion(idEdi);
			if (edicion != null)
			{
				var e = new EdicionDTO
				{
					Descripción = edicion.Descripción,
					IdEdicion = edicion.IdEdicion,
					IdVideo = edicion.IdVideo,
					Musica = edicion.Musica,
					Nombre = edicion.Nombre,
				};
				return e;
			}
			else return null;
		}

		//GetByIdVideo
		public async Task<EdicionDTO> GetByIdVideo(int idEdi)
		{
			var edicion = await _edicionRepo.GetByIdVideo(idEdi);
			if (edicion != null)
			{
				var e = new EdicionDTO
				{
					Descripción = edicion.Descripción,
					IdEdicion = edicion.IdEdicion,
					IdVideo = edicion.IdVideo,
					Musica = edicion.Musica,
					Nombre = edicion.Nombre,
				};
				return e;
			}
			else return null;
		}
		//GetAll
		public async Task<IEnumerable<EdicionDTO>> GetAll()
		{
			var edicion = await _edicionRepo.getAll();
			if (edicion != null)
			{
				var e = edicion.Select(x => new EdicionDTO
				{
					Descripción = x.Descripción,
					IdEdicion = x.IdEdicion,
					IdVideo = x.IdVideo,
					Musica = x.Musica,
					Nombre = x.Nombre
				});
				return e;
			}
			else return null;
		}

		public async Task<bool> update(EdicionUpdateDTO edicionUpdateDTO)
		{
			//Esto tambien tiene un margen de edicion.
			DateTime fechaEvento = (DateTime)await _edicionRepo.getFechaEventoByIdEdicion(edicionUpdateDTO.IdEdicion);
			DateTime fechaActual = DateTime.Now;
			int diferencia = (fechaEvento - fechaActual).Days;
			if (diferencia > 4)
			{
				var edicion = new Edicion
				{
					IdEdicion = edicionUpdateDTO.IdEdicion,
					IdVideo = edicionUpdateDTO.IdVideo,
					Nombre = edicionUpdateDTO.Nombre,
					Musica = edicionUpdateDTO.Musica,
					Estado = "activo",
					Descripción = edicionUpdateDTO.Descripción
				};
				var est = await _edicionRepo.update(edicion);
				return est;
			}else return false;
		}

		public async Task<bool> delete(int id)
		{
			var ed = await _edicionRepo.delete(id);
			return ed;
		}


	}
}
