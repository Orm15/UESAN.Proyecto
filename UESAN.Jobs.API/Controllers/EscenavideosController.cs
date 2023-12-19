using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EscenavideosController : ControllerBase
	{
		private readonly IEscenaVideoService _escenaVideoService;

		public EscenavideosController(IEscenaVideoService escenaVideoService)
		{
			_escenaVideoService = escenaVideoService;
		}

		[HttpPost("CreateVideo")]
		public async Task<IActionResult> InsertEvento(EscenasVideoInsertDTO ucd)
		{
			var result = await _escenaVideoService.InsertCC(ucd);
			if (!result) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAllByIdServicioEdicion{id}/servicioEdicionID")]
		public async Task<ActionResult> GetAllByServiciosEdicion(int id)
		{
			var u = await _escenaVideoService.GetAllByIdServicioEdicion(id);
			if (u == null) return NotFound(" - No hay escenas de esta edicion aun");
			else return Ok(u);
		}

		[HttpGet("GetById{id}")]
		public async Task<ActionResult> GetById(int id)
		{
			var u = await _escenaVideoService.GetAllByIdServicioEdicion(id);
			if (u == null) return NotFound(" - No hay escenas - ");
			else return Ok(u);
		}

		[HttpPut]
		public async Task<IActionResult> Update(EscenasVideoUpdateDTO uad)
		{
			var u = await _escenaVideoService.update(uad);
			return Ok(u);
		}


		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _escenaVideoService.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}




	}
}
