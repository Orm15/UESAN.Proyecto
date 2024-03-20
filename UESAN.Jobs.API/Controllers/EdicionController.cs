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
	public class EdicionController : ControllerBase
	{
		private readonly IEdicionService _edicionService;

		public EdicionController(IEdicionService edicionService)
		{
			_edicionService = edicionService;
		}

		[HttpPost("CreateEdicion")]
		[Authorize]
		public async Task<IActionResult> InsertEvento(EdicionInsertDTO ucd)
		{
			var result = await _edicionService.InsertEdicion(ucd);
			if (!result) { return BadRequest(result); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		[Authorize]
		public async Task<ActionResult> GetAllEdicion()
		{
			var u = await _edicionService.GetAll();
			if (u == null)
			{
				return NotFound(" - NO HAY ediciones - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("EdicionId{id}")]
		[Authorize]
		public async Task<ActionResult> GetAllById(int id)
		{
			var u = await _edicionService.GetByIdEdicion(id);
			if (u == null)
			{
				return NotFound(" - NO HAY edicion con ese id - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("Edicion{id}/ByVideo")]
		[Authorize]
		public async Task<ActionResult> GetAllByIdVideo(int id)
		{
			var u = await _edicionService.GetByIdVideo(id);
			if (u == null)
			{
				return NotFound(" - NO HAY edicion con ese idVideo - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> Update(EdicionUpdateDTO uad)
		{
			var u = await _edicionService.update(uad);
			return Ok(u);
		}

		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _edicionService.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}



	}
}
