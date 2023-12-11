using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioFotosController : ControllerBase
    {
        private readonly IServicioFotosService _servicioFotosService;
        public ServicioFotosController(IServicioFotosService servFotService)
        {
            _servicioFotosService = servFotService;
        }

        [HttpPost("CreateServicioFotos")]
        public async Task<IActionResult> InsertServicioFotos(ServicioFotosInsertDTO sfDTO)
        {
            var result = await _servicioFotosService.Create(sfDTO);
            if (result == -1) return BadRequest(result);
            else return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllServicioFotos()
        {
            var u = await _servicioFotosService.getAll();
            if (u == null)return NotFound(" - NO HAY servicios de fotos - ");
            else return Ok(u);
        }

        [HttpGet("GetAllByIdServicio{id}")]
        public async Task<ActionResult> GetallByIdServicio(int id)
        {
            var u = await _servicioFotosService.getBySId(id);
            if (u == null)return NotFound(" - NO HAY servicios de fotos - ");
            else return Ok(u);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _servicioFotosService.getById(id);
            if (result == null)return NotFound();
            return Ok(result);
        }

		[HttpPut]
		public async Task<IActionResult> Update(ServicioFotosUpdateDTO uad)
		{
			var u = await _servicioFotosService.Update(uad);
			return Ok(u);
		}
	}
}
