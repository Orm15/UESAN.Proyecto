﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.proyecto.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;
		public EmailController(IEmailService emailService)
		{
			_emailService = emailService;
		}

		/*
		[HttpPost("sendEmail")]
		[Authorize]
		public  IActionResult SendEmail(EmailDTO request)
		{
			_emailService.SendEmail(request);
			return Ok();
		}
		*/

		[HttpPost("sendEmailPDF")]
		[Authorize]
		public IActionResult SendEmailPDF([FromForm] EmailDTO request, IFormFile pdfFile)
		{
			using (var memoryStream = new MemoryStream())
			{
				pdfFile.CopyTo(memoryStream);
				memoryStream.Seek(0, SeekOrigin.Begin);
				var respuesta = _emailService.SendEmailPDF(request, memoryStream, pdfFile.FileName);
				return Ok(respuesta);
			}
			
		}

		[HttpPost("sendEmailPassword")]
		[Authorize]
		public IActionResult SendEmailPassword(EmailPassword request)
		{
			var respuesta = _emailService.SendEmailPassword(request);
			return Ok(respuesta);

		}
	}
}

