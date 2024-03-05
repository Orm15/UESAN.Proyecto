using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CircuitoCerradoController : ControllerBase
	{
		private readonly ICircuitoCerradoService _circuitoCerradoService;

		public CircuitoCerradoController(ICircuitoCerradoService circuitoCerradoService)
		{
			_circuitoCerradoService = circuitoCerradoService;
		}

		[HttpPost("CreateCircuitoCeraddo")]
		[Authorize]
		public async Task<IActionResult> InsertEvento(CircuitoCerradoInsertDTO ucd)
		{
			var result = await _circuitoCerradoService.InsertCC(ucd);
			if (result == 0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		[Authorize]
		public async Task<ActionResult> GetAllCC()
		{
			var u = await _circuitoCerradoService.GetAll();
			if (u == null) return NotFound(" - NO HAY CC - ");
			else return Ok(u);
			
		}

		[HttpGet("GetByIdEvento{id}/evento")]
		[Authorize]
		public async Task<ActionResult> getByIdEvento(int id)
		{
			var u = await _circuitoCerradoService.getbYIdEvento(id);
			if (u == null)
			return NotFound(" - No hay CC con ese id - ");
			else return Ok(u);
		}

		[HttpGet("GetById{id}")]
		[Authorize]
		public async Task<ActionResult> getById(int id)
		{
			var u = await _circuitoCerradoService.getbYId(id);
			if (u == null) return NotFound(" - No hay CC con ese id - ");
			else return Ok(u);
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> Update(CircuitoCerradoUpdateDTO uad)
		{
			var u = await _circuitoCerradoService.update(uad);
			return Ok(u);
		}

		[HttpGet("GetByIdServicio = {id}/Servicio")]
		[Authorize]
		public async Task<ActionResult> getByIdServicio(int id)
		{
			var u = await _circuitoCerradoService.getByIdServicio(id);
			if (u == null) return NotFound(" - No hay CC con ese id - ");
			else return Ok(u);
		}


		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _circuitoCerradoService.delete(id);
			if (!result) return NotFound();
			return Ok(result);
		}


	}
}
