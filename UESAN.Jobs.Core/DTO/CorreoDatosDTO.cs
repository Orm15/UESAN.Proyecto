using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class EmailDTO
	{
		public string Para { get; set; } = string.Empty;

		public string Nombre { get; set; } = string.Empty;

	}

	public class EmailPassword
	{
		public string Para { get; set; } = string.Empty;
		public string Password { get; set; }

		public string Nombre { get; set; } = string.Empty;

		public string tipo { get; set; } = string.Empty;
	}

	public class EmailRequestModel
	{
		public EmailDTO Email { get; set; }
		public byte[] PdfAttachment { get; set; }
		public string PdfFileName { get; set; }
	}
}
