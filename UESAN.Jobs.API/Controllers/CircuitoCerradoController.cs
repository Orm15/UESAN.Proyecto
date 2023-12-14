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
		public async Task<IActionResult> InsertEvento(CircuitoCerradoInsertDTO ucd)
		{
			var result = await _circuitoCerradoService.InsertCC(ucd);
			if (result == 0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAllCC()
		{
			var u = await _circuitoCerradoService.GetAll();
			if (u == null) return NotFound(" - NO HAY CC - ");
			else return Ok(u);
			
		}

		[HttpGet("GetByIdEvento{id}/evento")]
		public async Task<ActionResult> getByIdEvento(int id)
		{
			var u = await _circuitoCerradoService.getbYIdEvento(id);
			if (u == null)
			return NotFound(" - No hay CC con ese id - ");
			else return Ok(u);
		}

		[HttpGet("GetById{id}")]
		public async Task<ActionResult> getById(int id)
		{
			var u = await _circuitoCerradoService.getbYId(id);
			if (u == null) return NotFound(" - No hay CC con ese id - ");
			else return Ok(u);
		}

		[HttpPut]
		public async Task<IActionResult> Update(CircuitoCerradoUpdateDTO uad)
		{
			var u = await _circuitoCerradoService.update(uad);
			return Ok(u);
		}


		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _circuitoCerradoService.delete(id);
			if (!result) return NotFound();
			return Ok(result);
		}


	}
}
