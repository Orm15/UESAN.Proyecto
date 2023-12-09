using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Utilidades;

namespace UESAN.Proyecto.Core.Services
{
    public class UsuarioServices : IUsuarioServices
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioServices(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}
		//traer todos los usuarios por estado
		public async Task<IEnumerable<UsuarioDTO>> getAll(string estado)
		{
			var u = await _usuarioRepository.getAll(estado);
			var ud = u.Select(x => new UsuarioDTO
			{
				IdUsuario = x.IdUsuario,
				Nombre = x.Nombre,
				Correo = x.Correo,
				Tipo = x.Tipo,
				Area = x.Area
			});

			return ud;
		}

		//GetById
		public async Task<UsuarioDTO> getById(int id)
		{
			var u = await _usuarioRepository.getById(id);
			if (u != null)
			{
				var usu = new UsuarioDTO
				{
					IdUsuario = u.IdUsuario,
					Nombre = u.Nombre,
					Correo = u.Correo,
					Tipo = u.Tipo,
					Area = u.Area
				};
				return usu;
			}
			else
			{
				return null;
			}

		}


		//Crear un admin

		public async Task<UsuarioAuthResponseDTO> CreateAdmin(UsuarioCreateDTO usuarioCreateDTO)
		{
			var est = await _usuarioRepository.IsEmailRegistered(usuarioCreateDTO.Correo);
			if (est == false)
			{
				var (p, s) = SecurityHelperUtilidades.SetPassword(usuarioCreateDTO.Contra);
				var u = new Usuarios
				{
					Nombre = usuarioCreateDTO.Nombre,
					Correo = usuarioCreateDTO.Correo,
					Area = usuarioCreateDTO.Area,
					Estado = "Activo",
					Tipo = "Admin",
					Contra = p,
					Salt = s
				};
				//Esto se agrego para retornar id y tipo
				var usuario = await _usuarioRepository.Insert(u);
				var uard = new UsuarioAuthResponseDTO
				{
					IdUsuario = usuario.IdUsuario,
					Tipo = usuario.Tipo,
				};
				return uard;
			}
			else
			{
				return null;
			}
		}

		//Crear un usuario Normal sin salt

		public async Task<UsuarioAuthResponseDTO> CreateUsuarioNormal(UsuarioCreateDTO usuarioCreateDTO)
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
				//Esto se agrego para retornar id y tipo
				var usuario = await _usuarioRepository.Insert(u);
				var uard = new UsuarioAuthResponseDTO
				{
					IdUsuario = usuario.IdUsuario,
					Tipo = usuario.Tipo,
				};
				return uard;
			}
			else
			{
				return null;
			}
		}
		//Crear un usuario Normal con Salt
		public async Task<UsuarioAuthResponseDTO> CreateUsuarioNormalSalt(UsuarioCreateDTO usuarioCreateDTO)
		{
			var est = await _usuarioRepository.IsEmailRegistered(usuarioCreateDTO.Correo);
			if (est == false)
			{
				var (p,s) = SecurityHelperUtilidades.SetPassword(usuarioCreateDTO.Contra);
				var u = new Usuarios
				{
					Nombre = usuarioCreateDTO.Nombre,
					Correo = usuarioCreateDTO.Correo,
					Area = usuarioCreateDTO.Area,
					Estado = "Activo",
					Tipo = "normal",
					Contra = p,
					Salt = s
					
				};
				//Esto se agrego para retornar id y tipo
				var usuario =  await _usuarioRepository.Insert(u);
				var uard = new UsuarioAuthResponseDTO
				{
					IdUsuario = usuario.IdUsuario,
					Tipo = usuario.Tipo,
				};
				return uard;
			}
			else
			{
				return null;
			}
		}

		//modificar un usuario
		public async Task<bool> updateUsuario(UsuarioUpdateDTO usuarioUpdateDTO)
		{
			var usuario = new Usuarios
			{
				IdUsuario = usuarioUpdateDTO.IdUsuario,
				Nombre = usuarioUpdateDTO.Nombre,
				Contra = usuarioUpdateDTO.Contra,
				Correo = usuarioUpdateDTO.Correo,
				Area = usuarioUpdateDTO.Area,
				Estado = "Activo",
				Tipo = "normal"

			};
			var est = await _usuarioRepository.update(usuario);
			return est;
		}

		//modificar un usuario con salt
		public async Task<bool> updateUsuarioSalt(UsuarioUpdateDTO usuarioUpdateDTO)
		{
			var(p, s) = SecurityHelperUtilidades.SetPassword(usuarioUpdateDTO.Contra);
			var usuario = new Usuarios
			{
				IdUsuario = usuarioUpdateDTO.IdUsuario,
				Nombre = usuarioUpdateDTO.Nombre,
				Contra = p,
				Correo = usuarioUpdateDTO.Correo,
				Area = usuarioUpdateDTO.Area,
				Estado = "Activo",
				Tipo = "normal",
				Salt = s

			};
			var est = await _usuarioRepository.update(usuario);
			return est;
		}
		//ingresar por medio de un validación sin salt
		public async Task<UsuarioAuthResponseDTO> sigIn(string correo, string password)
		{
			var u = await _usuarioRepository.SigIn(correo, password);
			if (u != null)
			{
				var usuariod = new UsuarioAuthResponseDTO
				{
					IdUsuario = u.IdUsuario,
					Tipo = u.Tipo
				};
				return usuariod;
			}
			else
			{
				return null;
			}
		}

		//ingresar por medio de un validación con salt
		public async Task<UsuarioAuthResponseDTO> sigInSal(string correo, string password)
		{
			var u = await _usuarioRepository.SigInSalt(correo, password);
			if (u != null)
			{
				var usuariod = new UsuarioAuthResponseDTO
				{
					IdUsuario = u.IdUsuario,
					Tipo = u.Tipo
				};
				return usuariod;
			}
			else
			{
				return null;
			}
		}
		//borrar

		public async Task<bool> delete(int id)
		{
			var est = await _usuarioRepository.delete(id);
			return est;
		}




	}
}
