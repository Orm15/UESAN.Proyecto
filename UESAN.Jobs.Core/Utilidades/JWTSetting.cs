using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Utilidades
{
    public class JWTSettings
	{
		public string SecretKey { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public double DurationInMinutes { get; set; }
	}
}
