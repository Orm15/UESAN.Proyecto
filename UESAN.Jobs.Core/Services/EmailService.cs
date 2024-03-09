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
				//builder.HtmlBody = "Hola " + request.Nombre + ". A continuación se te adjunta el registro de los datos de los servicios que has solicitado.";

				builder.HtmlBody = $@"
					<!DOCTYPE html>
					<html lang='en'>
					<head>
						<meta charset='UTF-8'>
						<meta name='viewport' content='width=device-width, initial-scale=1.0'>
						<title>Confirmación de Solicitud de Servicios</title>
						<style>
							body {{
								font-family: Arial, sans-serif;
								background-color: #f4f4f4;
								margin: 0;
								padding: 0;
							}}
							.container {{
								max-width: 600px;
								margin: 50px auto;
								background-color: #ffffff;
								border-radius: 10px;
								box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
							}}
							.header {{
								background-color: #007bff;
								color: #ffffff;
								border-top-left-radius: 10px;
								border-top-right-radius: 10px;
								padding: 20px;
								text-align: center;
							}}
							.content {{
								padding: 30px;
								text-align: center;
							}}
							.message {{
								font-size: 16px;
								line-height: 1.6;
								color: #333333;
							}}
						</style>
					</head>
					<body>
						<div class='container'>
							<div class='header'>
								<h1>Confirmación de Solicitud de Servicios</h1>
							</div>
							<div class='content'>
								<p class='message'>Hola {request.Nombre},</p>
								<p class='message'>A continuación se adjunta el registro de los datos de los servicios que has solicitado.</p>
							</div>
						</div>
					</body>
					</html>";

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



		public string SendEmailPassword(EmailPassword request)
		{
			try
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
				}
				else if (request.tipo.Equals("login"))
				{
					mensaje = " este es tu correo de ingreso : " + request.Para + " y contraseña : ";
					sub = "Envío de correo y contraseña de ingreso";
				}
				var email = new MimeMessage();
				email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
				email.To.Add(MailboxAddress.Parse(request.Para));
				email.Subject = sub;


				var bodyBuilder = new BodyBuilder();
				bodyBuilder.HtmlBody = $@"
					<!DOCTYPE html>
					<html lang='en'>
					<head>
						<meta charset='UTF-8'>
						<meta name='viewport' content='width=device-width, initial-scale=1.0'>
						<title>Confirmación de Solicitud de Servicios</title>
						<style>
							body {{
								font-family: Arial, sans-serif;
								background-color: #f4f4f4;
								margin: 0;
								padding: 0;
							}}
							.container {{
								max-width: 600px;
								margin: 50px auto;
								background-color: #ffffff;
								border-radius: 10px;
								box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
							}}
							.header {{
								background-color: #007bff;
								color: #ffffff;
								border-top-left-radius: 10px;
								border-top-right-radius: 10px;
								padding: 20px;
								text-align: center;
							}}
							.content {{
								padding: 30px;
								text-align: center;
							}}
							.password {{
								color: #ff0000;
							}}
							.message {{
								font-size: 16px;
								line-height: 1.6;
								color: #333333;
							}}
						</style>
					</head>
					<body>
						<div class='container'>
							<div class='header'>
								<h1>{sub}</h1>
							</div>
							<div class='content'>
								<p class='message'>Hola {request.Nombre},</p>
								<p class='message'> {mensaje} <span class='password'>{request.Password}</span></p>
							</div>
						</div>
					</body>
					</html>";

				email.Body = bodyBuilder.ToMessageBody();

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

		
	}
}
