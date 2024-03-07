using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.DTO;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Services
{
    public class EmailService : IEmailService
	{
		private readonly IConfiguration _config;
		public EmailService(IConfiguration config)
		{
			_config = config;
		}


		/*public void SendEmail(EmailDTO request)
		{
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
			email.To.Add(MailboxAddress.Parse(request.Para));
			email.Subject = request.Asunto;
			email.Body = new TextPart(TextFormat.Html)
			{
				Text = request.Contenido
			};

			using var smtp = new SmtpClient();
			smtp.Connect(
				_config.GetSection("Email:Host").Value,
			   Convert.ToInt32(_config.GetSection("Email:Port").Value),
			   SecureSocketOptions.StartTls
				);


			smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

			smtp.Send(email);
			smtp.Disconnect(true);


		}*/

		public string  SendEmailPDF(EmailDTO request, Stream pdfStream, string pdfFileName)
		{
			try
			{
				var email = new MimeMessage();
				email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
				email.To.Add(MailboxAddress.Parse(request.Para));
				email.Subject = "Confirmación de Solicitud de servicios";

				var builder = new BodyBuilder();
				builder.HtmlBody = "Hola " + request.Nombre + ". A continuación se te adjunta el registro de los datos de los servicios que has solicitado.";

				// Adjuntar el archivo PDF
				builder.Attachments.Add(pdfFileName, pdfStream, ContentType.Parse("application/pdf"));

				email.Body = builder.ToMessageBody();

				using var smtp = new SmtpClient();
				smtp.Connect(
					_config.GetSection("Email:Host").Value,
					Convert.ToInt32(_config.GetSection("Email:Port").Value),
					SecureSocketOptions.StartTls
				);

				smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

				smtp.Send(email);
				smtp.Disconnect(true);

				return "Envío exitoso";
			}
			catch (Exception ex)
			{
				return ("Error al enviar el correo electrónico: " + ex.Message);
			}
		}



		public void SendEmailPassword(EmailPassword request)
		{
			string mensaje = "", sub = "";
			if (request.tipo.Equals("verificacion"))
			{
				mensaje = " este es tu código de verificación : ";
				sub = "Código de verificación";
			}
			else if (request.tipo.Equals("password"))
			{
				mensaje = " el administrador te asignado la contraseña :  ";
				sub = "Cambio de contraseña";
			}else if (request.tipo.Equals("login"))
			{
				mensaje = " este es tu correo de ingreso : " + request.Para + " y contraseña : ";
				sub = "Envío de correo y contraseña de ingreso";
			}
			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
			email.To.Add(MailboxAddress.Parse(request.Para));
			email.Subject = sub;
			
			
			email.Body = new TextPart(TextFormat.Html)
			{
				Text = "Hola " + request.Nombre + mensaje +request.Password
			};

			using var smtp = new SmtpClient();
			smtp.Connect(
				_config.GetSection("Email:Host").Value,
			   Convert.ToInt32(_config.GetSection("Email:Port").Value),
			   SecureSocketOptions.StartTls
				);


			smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

			smtp.Send(email);
			smtp.Disconnect(true);


		}

		
	}
}
