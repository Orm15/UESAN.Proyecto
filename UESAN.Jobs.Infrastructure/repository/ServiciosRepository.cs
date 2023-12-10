using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class ServiciosRepository
	{
		readonly private OrdenesEventosContext _servicios;

		public ServiciosRepository(OrdenesEventosContext servicios)
		{
			_servicios = servicios;
		}
		//GET ALL - TRAE TODOS LOS SERVICIOS
		public async Task<IEnumerable<Servicios>> getAll()
		{
			var servicios = await _servicios.Servicios.ToListAsync();
			if (servicios.Any())
			{
				return servicios;
			}
			else
			{
				return null;
			}

		}
		//Get By Id .
		public async Task<Servicios> getById(int id)
		{
			var s = await _servicios.Servicios.Where(x => x.IdServicios == id).FirstOrDefaultAsync();
			if(s == null)
			{
				return null;
			}
			return s;
		}

		//Trae todos los servicio dado el idEvento
		public async Task<IEnumerable<Servicios>> getAllByIdEvento(int id)
		{
			var ser = await _servicios.Servicios.Where(x=> x.IdEventoNavigation.IdEvento == id).Include(y=> y.IdEventoNavigation).ToListAsync();
			if (ser.Any())
			{
				return ser;
			}
			else
			{
				return null;
			}
		}

		


	}
}
