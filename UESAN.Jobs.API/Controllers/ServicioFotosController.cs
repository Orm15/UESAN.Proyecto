using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesServices;

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
        public async Task<IActionResult> InsertServicioFotos(ServicioFotosDTO sfDTO)
        {
            var result = await _servicioFotosService.Create(sfDTO);
            if (result == -1) return BadRequest(result);
            else return Ok(result);
        }

        
    }
}
