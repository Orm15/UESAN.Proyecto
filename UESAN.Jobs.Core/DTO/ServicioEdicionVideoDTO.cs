﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.DTO
{
	public class ServicioEdicionVideoDTO
	{
		public int IdServicioEdicionVideo { get; set; }

		public int? IdEvento { get; set; }

		public int? IdUsuario { get; set; }

		public string? NombreProyecto { get; set; }

		public string? Objetivo { get; set; }

		public string? Musica { get; set; }

		public string? Logos { get; set; }

		public string? FormatoVideo { get; set; }

		public string? Destino { get; set; }

		public string? DuracionVideo { get; set; }

		public string? NombreEntrevistado { get; set; }

		public string? CarreraCargoEmpresa { get; set; }
	}

	public class ServicioEdicionVideoInsertDTO
	{
		public int? IdEvento { get; set; }

		public int? IdUsuario { get; set; }

		public string? NombreProyecto { get; set; }

		public string? Objetivo { get; set; }

		public string? Musica { get; set; }

		public string? Logos { get; set; }

		public string? FormatoVideo { get; set; }

		public string? Destino { get; set; }

		public string? DuracionVideo { get; set; }

		public string? NombreEntrevistado { get; set; }

		public string? CarreraCargoEmpresa { get; set; }
	}

	public class ServicioEdicionVideoUpdateDTO
	{
		public int IdServicioEdicionVideo { get; set; }

		public int? IdEvento { get; set; }

		public int? IdUsuario { get; set; }

		public string? NombreProyecto { get; set; }

		public string? Objetivo { get; set; }

		public string? Musica { get; set; }

		public string? Logos { get; set; }

		public string? FormatoVideo { get; set; }

		public string? Destino { get; set; }

		public string? DuracionVideo { get; set; }

		public string? NombreEntrevistado { get; set; }

		public string? CarreraCargoEmpresa { get; set; }
	}
}
