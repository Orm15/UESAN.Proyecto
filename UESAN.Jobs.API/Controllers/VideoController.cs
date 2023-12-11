using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Services;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoController : ControllerBase
	{
		private readonly IVideosServices _videos;

		public VideoController(IVideosServices videos) { 
			_videos = videos;
		}

		[HttpPost("CreateVideo")]
		public async Task<IActionResult> InsertEvento(VideosInsertDTO ucd)
		{
			var result = await _videos.InsertVideo(ucd);
			if (result == 0) { return BadRequest(); }
			else { return Ok(result); }
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAllVideos()
		{
			var u = await _videos.GetAll();
			if (u == null)
			{
				return NotFound(" - NO HAY Videos - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetById{id}")]
		public async Task<ActionResult> getByIdVideo(int id)
		{
			var u = await _videos.getbYIdVideo(id);
			if (u == null)
			{
				return NotFound(" - No hay video con ese id - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetByIdEvento{id}/evento")]
		public async Task<ActionResult> getByIdEvento(int id)
		{
			var u = await _videos.GetBYIdEvento(id);
			if (u == null)
			{
				return NotFound(" - No hay video con ese id - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpGet("GetByIdServicio{id}/servicio")]
		public async Task<ActionResult> getByIdServicio(int id)
		{
			var u = await _videos.GetBYIdServicio(id);
			if (u == null)
			{
				return NotFound(" - No hay video con ese id - ");
			}
			else
			{
				return Ok(u);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Update(VideosUpdateDTO uad)
		{
			var u = await _videos.update(uad);
			return Ok(u);
		}


		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _videos.delete(id);
			if (!result)
				return NotFound();
			return Ok(result);
		}

		[HttpPost("CambiarEstadoEdicion")]
		public async Task<IActionResult> CambiarEstadoEvento(int id)
		{
			var result = await _videos.CmabiarEstadoEdicion(id);
			if (!result) { return BadRequest(); }
			else { return Ok(result); }
		}
	}
}
