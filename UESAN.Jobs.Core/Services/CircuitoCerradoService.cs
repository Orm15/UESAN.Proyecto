using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Services
{
    public class CircuitoCerradoService : ICircuitoCerradoService
	{
		private readonly ICircuitoCerradoRepository _circuitoCerradoRepository;
		private readonly IServiciosRepository _servicioRepository;

		public CircuitoCerradoService(ICircuitoCerradoRepository circuitoCerradoRepository, IServiciosRepository servicioFotosRepository)
		{
			_circuitoCerradoRepository = circuitoCerradoRepository;
			_servicioRepository = servicioFotosRepository;
		}

		//INSERT CIRCUITO CERRADO
		public async Task<int> InsertCC(CircuitoCerradoInsertDTO circuitoCerradoInsert)
		{
			var c = new CircuitoCerrado
			{
				IdServicio = circuitoCerradoInsert.IdServicio,
				Estado = "activo",
				Angulos = circuitoCerradoInsert.Angulos,
				Guardar = circuitoCerradoInsert.Guardar,
				Link = circuitoCerradoInsert.Link,
				NumeroAngulos = circuitoCerradoInsert.NumeroAngulos,
				NumeroCamaras = circuitoCerradoInsert.NumeroCamaras
			};
			var e = await _circuitoCerradoRepository.Insert(c);
			if (e != null) { return e.IdCircuitoCerrado; }
			else return 0;
		}
		//GETALL
		public async Task<IEnumerable<CircuitoCerradoDTO>> GetAll()
		{
			var c = await _circuitoCerradoRepository.getAll();
			if (c != null)
			{
				var vidto = c.Select(x => new CircuitoCerradoDTO
				{
					IdServicio = x.IdServicio,
					IdCircuitoCerrado = x.IdCircuitoCerrado,
					NumeroCamaras = x.NumeroCamaras,
					NumeroAngulos = x.NumeroAngulos,
					Link = x.Link,
					Guardar = x.Guardar,
					Angulos = x.Angulos,


				});
				return vidto;
			}
			else { return null; }
		}

		//getByid ciruito
		public async Task<CircuitoCerradoDTO> getbYId(int id)
		{
			var x = await _circuitoCerradoRepository.getById(id);
			if (x != null)
			{
				var vdto = new CircuitoCerradoDTO
				{
					IdServicio = x.IdServicio,
					IdCircuitoCerrado = x.IdCircuitoCerrado,
					NumeroCamaras = x.NumeroCamaras,
					NumeroAngulos = x.NumeroAngulos,
					Link = x.Link,
					Guardar = x.Guardar,
					Angulos = x.Angulos,

				};
				return vdto;
			}
			else return null;
		}

		//getByIdEvento

		public async Task<CircuitoCerradoDTO> getbYIdEvento(int id)
		{
			var x = await _circuitoCerradoRepository.getByIdEvento(id);
			if (x != null)
			{
				var vdto = new CircuitoCerradoDTO
				{
					IdServicio = x.IdServicio,
					IdCircuitoCerrado = x.IdCircuitoCerrado,
					NumeroCamaras = x.NumeroCamaras,
					NumeroAngulos = x.NumeroAngulos,
					Link = x.Link,
					Guardar = x.Guardar,
					Angulos = x.Angulos,

				};
				return vdto;
			}
			else return null;
		}

		//update
		public async Task<bool> update(CircuitoCerradoUpdateDTO c)
		{
			DateTime fec = (DateTime)(await _servicioRepository.getById((int)c.IdServicio)).IdEventoNavigation.FechaEvento;
			DateTime fechaActual = DateTime.Now;
			int diferencia = (fec - fechaActual).Days;
			if (diferencia >= 3)
			{
				var v = new CircuitoCerrado
				{
					IdCircuitoCerrado = c.IdCircuitoCerrado,
					IdServicio = c.IdServicio,
					Estado = "activo",
					Angulos = c.Angulos,
					Guardar = c.Guardar,
					Link = c.Link,
					NumeroAngulos = c.NumeroAngulos,
					NumeroCamaras = c.NumeroCamaras
				};
				var e = await _circuitoCerradoRepository.update(v);
				return e;
			}
			else return false;

		}

		public async Task<CircuitoCerradoDTO> getByIdServicio(int id)
		{
			var x = await _circuitoCerradoRepository.getByIdServicio(id);
			if(x!= null)
			{
				var vdto = new CircuitoCerradoDTO
				{
					IdServicio = x.IdServicio,
					IdCircuitoCerrado = x.IdCircuitoCerrado,
					NumeroCamaras = x.NumeroCamaras,
					NumeroAngulos = x.NumeroAngulos,
					Link = x.Link,
					Guardar = x.Guardar,
					Angulos = x.Angulos,

				};
				return vdto;
			}
			else
			{
				return null;
			}
		}

		public async Task<bool> delete(int id)
		{
			return await _circuitoCerradoRepository.delete(id);
		}
	}
}
