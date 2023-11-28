using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.repository;
using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.Services
{
	public  class UsuarioServices
	{/*
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioServices(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}	
		//traer todos los usuarios
		public async Task<IEnumerable<UsuarioDTO>> getAll()
		{
			var u = await _usuarioRepository.getAll();
			var ud = u.Select(x => new UsuarioDTO
			{
				IdUsuario = x.IdUsuario,
				Nombre = x.Nombre,
				Correo = x.Correo,
				Estado = x.Estado,
				Tipo = x.Tipo,
			});

			return ud;
		}

		//Crear un admin

		public async Task<int> CreateAdmin(UsuarioCreateDTO usuarioCreateDTO)
		{
			var est = await _usuarioRepository.IsEmailRegistered(usuarioCreateDTO.Correo);
			if(est == false)
			{
				var u = new Usuarios
				{
					Nombre = usuarioCreateDTO.Nombre,
					Correo=usuarioCreateDTO.Correo,
					Area = usuarioCreateDTO.Area,
					Estado = "Activo",
					Tipo = "Admin"
				};
				return await _usuarioRepository.Insert(u);
			}
			else
			{
				return 0;
			}
		}

		//Crear un usuario Normal

		public async Task<int> CreateUsuarioNormal(UsuarioCreateDTO usuarioCreateDTO)
		{
			var est = await _usuarioRepository.IsEmailRegistered(usuarioCreateDTO.Correo);
			if (est == false)
			{
				var u = new Usuarios
				{
					Nombre = usuarioCreateDTO.Nombre,
					Correo = usuarioCreateDTO.Correo,
					Area = usuarioCreateDTO.Area,
					Estado = "Activo",
					Tipo = "normal"
				};
				return await _usuarioRepository.Insert(u);
			}
			else
			{
				return 0;
			}
		}

		*/

	}
}
