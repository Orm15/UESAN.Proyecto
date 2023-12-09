using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioServices _usuarioServices;

		public UsuarioController(IUsuarioServices usuarioServices)
		{
			_usuarioServices = usuarioServices;
		}

		//AQUI SE HACE LA VALIDACION DE LAS CUENTAS
		[HttpPost("SignIn")]
		public async Task<IActionResult> SigIn([FromBody] UsuarioAuthenticationDTO uad)
		{
			var result = await _usuarioServices.sigInSal(uad.Correo, uad.Contra);
			if (result == null)
			{
				return NotFound(" - Usuario no encontrado - ");
			}
			else { 
				return Ok(result);
				
			}
		}

		//Crear usuarios
		[HttpPost("SignUp")]
		public async Task<IActionResult> SignUp(UsuarioCreateDTO ucd)
		{
			var result = await _usuarioServices.CreateUsuarioNormalSalt(ucd);
			if (result == null) { return BadRequest(); }
			else { return Ok(result); }
		}


		[HttpPost("SignUp/admin")]
		public async Task<IActionResult> SignUpAdmin(UsuarioCreateDTO up)
		{
			var result = await _usuarioServices.CreateAdmin(up);
			if (result == null)
			{
				return BadRequest(" - No se ha creado el admin - ");
			}
			
			else { return Ok(result); }
		}

		[HttpPut]
		public async Task<IActionResult> Update(UsuarioUpdateDTO uad)
		{
			var u = await _usuarioServices.updateUsuario(uad);
			return Ok(u);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _usuarioServices.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAll(string estado)
		{
			var empresa = await _usuarioServices.getAll(estado);
			return Ok(empresa);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _usuarioServices.getById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
	}
}
