using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventosController : ControllerBase
	{
		private readonly IEventosService _eventosService;

		public EventosController(IEventosService eventosService)
		{
			_eventosService = eventosService;
		}
		//Crear Eventos //Debe retornar el idEvento
		[HttpPost("CreateEventos")]
		[Authorize]
		public async Task<IActionResult> InsertEvento(EventoInsertDTO ucd)
		{
			var result = await _eventosService.InsertEvento(ucd);
			if (result==0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		[Authorize]
		public async Task<ActionResult> GetAllEventos()
		{
			var u = await _eventosService.getAll();
			if (u == null)
			{
				return NotFound(" - NO HAY EVENTOS - ");
			}
			else
			{
				return Ok(u) ;
			}
		}

		[HttpGet("GetAllByUsuarioCreador")]
		[Authorize]
		public async Task<ActionResult> GetAllEventosByUsuarioCreador(int id)
		{
			var u = await _eventosService.GetEventosByUsuarioCreador(id);
			if (u == null)
			{
				return NotFound(" - NO HAY EVENTOS DE ESTE USUARIO - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetAllByUsuarioVizualizador")]
		[Authorize]
		public async Task<ActionResult> GetAllEventosByUsuarioVizualizador(int id)
		{
			var u = await _eventosService.getEventosByUsuarioVizualizador(id);
			if (u == null)
			{
				return NotFound(" - NO HAY EVENTOS PARA EL AREA DE ESTE USUARIO - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetAllByUsuarioVizualizadorAndcreador")]
		[Authorize]
		public async Task<ActionResult> GetAllEventosByUsuarioVizualizadorAndCreador(int id)
		{
			var u = await _eventosService.getEventosByUsuarioCreadorOrVizualizador(id);
			if (u == null)
			{
				return NotFound(" - NO HAY EVENTOS QUE HAYA CREADO O LE PERTENEZCAN A SU AREA - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetEventosByEstado")]
		[Authorize]
		public async Task<ActionResult> GetEventosByEstado(string estado)
		{
			var u = await _eventosService.EventosByEstado(estado);
			if (u == null)
			{
				return NotFound(" - No se encontraron eventos con ese estado");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpPost("CambiarEstadoEvento")]
		[Authorize]
		public async Task<IActionResult> CambiarEstadoEvento(int id)
		{
			var result = await _eventosService.CambiarEstado(id);
			if (!result) { return BadRequest(); }
			else { return Ok(result); }
		}



		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _eventosService.getById(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> Update(EventoUpdateDTO uad)
		{
			var u = await _eventosService.Update(uad);
			return Ok(u);
		}


		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _eventosService.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}




	}
}
