using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;

namespace UESAN.Proyecto.Core.Services
{
    public class ServicioFotosService : IServicioFotosService
    {
        private readonly IServicioFotosRepository _servicioFotosRepository;
        private readonly IServiciosRepository _serviciosRepository;

        public ServicioFotosService(IServicioFotosRepository servicioFotosRepository,IServiciosRepository servicio)
        {
            _servicioFotosRepository = servicioFotosRepository;
            _serviciosRepository = servicio;
        }
        //Traer todos los Servicios de fotos
        public async Task<IEnumerable<ServicioFotosDTO>> getAll()
        {
            var sf = await _servicioFotosRepository.getAll();
            if (sf.Any())
            {
                var sfd = sf.Select(x => new ServicioFotosDTO
                {
                    IdServicioFotos = x.IdServicioFotos,
                    IdServicio = x.IdServicio,
                    CantidadFotos = x.CantidadFotos,
                    TipoFoto = x.Tipo,
                    PesonaObjetivo = x.PesonaObjetivo,
                    Canales = x.Canales,
                    Link = x.Link
                });
                return sfd;
            }
            else return new List<ServicioFotosDTO>();
        }

        //get por id de servicio
        public async Task<IEnumerable<ServicioFotosDTO>> getBySId(int id)
        {
            var sf = await _servicioFotosRepository.getBySId(id);
            if (sf.Any())
            {
                var sfd = sf.Select(x => new ServicioFotosDTO
                {
                    IdServicioFotos = x.IdServicioFotos,
                    IdServicio = x.IdServicio,
                    CantidadFotos = x.CantidadFotos,
                    TipoFoto = x.Tipo,
                    PesonaObjetivo = x.PesonaObjetivo,
                    Canales = x.Canales,
                    Link = x.Link
                });
                return sfd;
            }
            else return null;
        }

        //get por id
        public async Task<ServicioFotosDTO> getById(int id)
        {
            var sf = await _servicioFotosRepository.getById(id);
            if (sf != null)
            {
                var sfd = new ServicioFotosDTO
                {
                    IdServicioFotos = sf.IdServicioFotos,
                    IdServicio = sf.IdServicio,
                    CantidadFotos = sf.CantidadFotos,
                    TipoFoto = sf.Tipo,
                    PesonaObjetivo = sf.PesonaObjetivo,
                    Canales = sf.Canales,
                    Link = sf.Link
                };
                return sfd;
            }
            else return null;
        }

        //Create ServicioFotos
        public async Task<int> Create(ServicioFotosInsertDTO servFotDTO)
        {
            var sf = new ServicioFotos
            {
                IdServicio = servFotDTO.IdServicio,
                CantidadFotos = servFotDTO.CantidadFotos,
                Tipo = servFotDTO.TipoFoto,
                PesonaObjetivo = servFotDTO.PesonaObjetivo,
                Canales = servFotDTO.Canales,
                Link = servFotDTO.Link,
                Estado = "Activo"
            };
            var sfd = await _servicioFotosRepository.Insert(sf);
            if (sfd != null) return sfd.IdServicioFotos;
            else return -1;
        }

        //Update ServicioFotos
        public async Task<bool> Update(ServicioFotosUpdateDTO servFotDTO)
        {
            DateTime fechaO = DateTime.Now;
            string est = "Activo";
            var objeto = await _serviciosRepository.getById((int)servFotDTO.IdServicio);
            DateTime fechaEvento = (DateTime)objeto.IdEventoNavigation.FechaEvento;
            int rem = (fechaEvento - fechaO).Days;
            if (rem <= 2) est = "Inactivo";
            var sf = new ServicioFotos
            {
                IdServicioFotos = servFotDTO.IdServicioFotos,
                IdServicio = servFotDTO.IdServicio,
                CantidadFotos = servFotDTO.CantidadFotos,
                Tipo = servFotDTO.TipoFoto,
                PesonaObjetivo = servFotDTO.PesonaObjetivo,
                Canales = servFotDTO.Canales,
                Link = servFotDTO.Link,
                Estado = est
            };
            var sfd = await _servicioFotosRepository.update(sf);
            return sfd;
        }



		/*
         *  DateTime fechaO = DateTime.Now;
            int num;
            string est = "Activo";
            if (servFotDTO.IdServicio == null) num = -1;
            else num = (int)servFotDTO.IdServicio;
            var s = await _serviciosRepository.getById(num);
            if (s == null) return false;
            if (s.IdEvento == null) num = -1;
            else num = (int)s.IdEvento;
            Eventos es = await _eventoRepository.getEventosById(num);
            int rem = (es.FechaEvento - fechaO).Value.Days;
            if (rem >= 2) est = "Inactivo";
            var sf = new ServicioFotos
            {
                IdServicioFotos = servFotDTO.IdServicioFotos,
                IdServicio = servFotDTO.IdServicio,
                CantidadFotos = servFotDTO.CantidadFotos,
                Tipo = servFotDTO.TipoFoto,
                PesonaObjetivo = servFotDTO.PesonaObjetivo,
                Canales = servFotDTO.Canales,
                Link = servFotDTO.Link,
                Estado = est
            };
            var sfd = await _servicioFotosRepository.update(sf);
            return sfd;*/
    }
}
