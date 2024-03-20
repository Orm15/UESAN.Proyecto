using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiciosEdicionVideoController : ControllerBase
	{
		private readonly IServicioEdicionVideoService _servicioEdicionVideoService;

		public ServiciosEdicionVideoController(IServicioEdicionVideoService servicioEdicionVideoService)
		{
			_servicioEdicionVideoService = servicioEdicionVideoService;
		}

		[HttpPost("CreateServicioEdicion")]
		public async Task<IActionResult> InsertServicioEdicionVideo(ServicioEdicionVideoInsertDTO ucd)
		{
			var result = await _servicioEdicionVideoService.InsertServicioEdicion(ucd);
			if (result == 0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAllById{id}")]
		public async Task<ActionResult> GetAllById(int id)
		{
			var u = await _servicioEdicionVideoService.getbYId(id);
			if (u == null) return NotFound(" - No hay servicios de edicion con este id");
			else return Ok(u);
		}

		[HttpGet("GetAllByIdEvento{id}/idEvento")]
		public async Task<ActionResult> GetAllByIdEvento(int id)
		{
			var u = await _servicioEdicionVideoService.GetBYIdEvento(id);
			if (u == null) return NotFound(" - No hay servicios de edicion de este evento");
			else return Ok(u);
		}

		[HttpGet("GetAllByIdUsuario{id}/idUsuario")]
		public async Task<ActionResult> GetAllByIdUsuario(int id)
		{
			var u = await _servicioEdicionVideoService.GetBYIdUsuario(id);
			if (u == null) return NotFound(" - No hay servicios de edicion de este usuario");
			else return Ok(u);
		}

		[HttpPut]
		public async Task<IActionResult> Update(ServicioEdicionVideoUpdateDTO uad)
		{
			var u = await _servicioEdicionVideoService.update(uad);
			return Ok(u);
		}


		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _servicioEdicionVideoService.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}
	}
}
