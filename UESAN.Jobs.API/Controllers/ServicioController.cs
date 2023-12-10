using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicioController : ControllerBase
	{
		private readonly IServicioService _servicioService;

		public ServicioController(IServicioService servicioService)
		{
			_servicioService = servicioService;
		}

		[HttpPost("CreateServicio")]
		public async Task<IActionResult> InsertEvento(ServicioInsertDTO ucd)
		{
			var result = await _servicioService.InsertServicio(ucd);
			if (result == 0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAllServicios()
		{
			var u = await _servicioService.GetAll();
			if (u == null)
			{
				return NotFound(" - NO HAY servicios - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetAllByIdEvento{id}")]
		public async Task<ActionResult> GetallByIdEvento(int id)
		{
			var u = await _servicioService.GetAllByIdEvento(id);
			if (u == null)
			{
				return NotFound(" - NO HAY servicios - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _servicioService.GetById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}


	}
}
