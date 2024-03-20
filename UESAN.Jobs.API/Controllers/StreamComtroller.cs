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
    public class StreamComtroller : ControllerBase
    {
        private readonly IStreamService _streamService;

        public StreamComtroller(IStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpPost("CreateStream")]
		[Authorize]
		public async Task<IActionResult> InsertEvento(StreamInsertDTO ucd)
        {
            var result = await _streamService.InsertStream(ucd);
            if (result == 0) { return BadRequest(); }
            else { return Ok(result); }
        }

        [HttpGet("GetAll")]
		[Authorize]
		public async Task<ActionResult> GetAllStream()
        {
            var u = await _streamService.GetAll();
            if (u == null) return NotFound(" - NO HAY STREAM - ");
            else return Ok(u);

        }

        [HttpGet("GetByIdEvento{id}/evento")]
		[Authorize]
		public async Task<ActionResult> getByIdEvento(int id)
        {
            var u = await _streamService.getbYIdEvento(id);
            if (u == null)
                return NotFound(" - No hay Stream con ese id - ");
            else return Ok(u);
        }

        [HttpGet("GetById{id}")]
		[Authorize]
		public async Task<ActionResult> getById(int id)
        {
            var u = await _streamService.getById(id);
            if (u == null) return NotFound(" - No hay Stream con ese id - ");
            else return Ok(u);
        }

        [HttpPut]
		[Authorize]
		public async Task<IActionResult> Update(StreamUpdateDTO uad)
        {
            var u = await _streamService.update(uad);
            return Ok(u);
        }


        [HttpDelete]
		[Authorize]
		public async Task<IActionResult> Delete(int id)
        {
            var result = await _streamService.delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
