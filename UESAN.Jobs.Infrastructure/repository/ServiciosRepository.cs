using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.proyecto.Infrastructure.repository
{
	public class ServiciosRepository : IServiciosRepository
	{
		readonly private OrdenesEventosContext _servicios;

		public ServiciosRepository(OrdenesEventosContext servicios)
		{
			_servicios = servicios;
		}
		//GET ALL - TRAE TODOS LOS SERVICIOS
		public async Task<IEnumerable<Servicios>> getAll()
		{
			var servicios = await _servicios.Servicios
				.Include(y => y.IdEventoNavigation.IdUsuarioNavigation).ToListAsync();
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
			var s = await _servicios.Servicios.Where(x => x.IdServicios == id)
				.Include(y=>y.IdEventoNavigation.IdUsuarioNavigation).FirstOrDefaultAsync();	
			if (s == null)
			{
				return null;
			}
			return s;
		}

		//Trae todos los servicio dado el idEvento
		public async Task<IEnumerable<Servicios>> getAllByIdEvento(int id)
		{
			var ser = await _servicios.Servicios.Where(x => x.IdEventoNavigation.IdEvento == id)
				.Include(y => y.IdEventoNavigation.IdUsuarioNavigation).ToListAsync();
			if (ser.Any())
			{
				return ser;
			}
			else
			{
				return null;
			}
		}

		//delete
		public async Task<bool> delete(int id)
		{
			var eve = await _servicios.Servicios.Where(x => x.IdServicios == id).FirstOrDefaultAsync();
			if (eve == null)
			{
				return false;
			}
			else
			{
				eve.Estado = "Eliminado";
				int rows = await _servicios.SaveChangesAsync();
				return rows > 0;
			}
		}

		//modificar
		public async Task<bool> update(Servicios e)
		{
			_servicios.Update(e);
			int rows = _servicios.SaveChanges();
			return rows > 0;
		}

		public async Task<int> insertServicio(Servicios servicios)
		{
			await _servicios.Servicios.AddAsync(servicios);
			int rows = await _servicios.SaveChangesAsync();
			if (rows > 0)
			{
				return servicios.IdServicios;
			}
			else
			{
				return 0;
			}
		}


	}
}
