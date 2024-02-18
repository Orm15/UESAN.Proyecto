using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.DTO;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using UESAN.Proyecto.Core.InterfacesServices;
using Stream = UESAN.Proyecto.Core.entities.Stream;

namespace UESAN.Proyecto.Core.Services
{
    public class StreamService : IStreamService
    {
        private readonly IStreamRepository _streamRepository;
        private readonly IServiciosRepository _servicioRepository;

        public StreamService(IStreamRepository streamRepository, IServiciosRepository servicioFotosRepository)
        {
            _streamRepository = streamRepository;
            _servicioRepository = servicioFotosRepository;
        }

        //INSERT STREAM
        public async Task<int> InsertStream(StreamInsertDTO streamInsert)
        {
            var c = new Stream
            {
                IdServicios = streamInsert.IdServicios,
                Estado = "activo",
                Angulo = streamInsert.Angulo,
                Plataforma = streamInsert.Plataforma,
                Cuenta = streamInsert.Cuenta,
                ContactoCuenta = streamInsert.ContactoCuenta,
                NumCam = streamInsert.NumCam
            };
            var e = await _streamRepository.Insert(c);
            if (e != null) { return e.IdStream; }
            else return 0;
        }

        //GETALL
        public async Task<IEnumerable<StreamDTO>> GetAll()
        {
            var c = await _streamRepository.getAll();
            if (c != null)
            {
                var vidto = c.Select(x => new StreamDTO
                {
                    IdServicios = x.IdServicios,
                    IdStream = x.IdStream,
                    NumCam = x.NumCam,
                    Angulo = x.Angulo,
                    ContactoCuenta = x.ContactoCuenta,
                    Cuenta = x.Cuenta,
                    Plataforma = x.Plataforma,
                });
                return vidto;
            }
            else { return null; }
        }

        //getByid stream
        public async Task<StreamDTO> getById(int id)
        {
            var x = await _streamRepository.getById(id);
            if (x != null)
            {
                var vdto = new StreamDTO
                {
                    IdServicios = x.IdServicios,
                    IdStream = x.IdStream,
                    NumCam = x.NumCam,
                    Angulo = x.Angulo,
                    ContactoCuenta = x.ContactoCuenta,
                    Cuenta = x.Cuenta,
                    Plataforma = x.Plataforma,

                };
                return vdto;
            }
            else return null;
        }

        //getByIdEvento

        public async Task<StreamDTO> getbYIdEvento(int id)
        {
            var x = await _streamRepository.getByIdEvento(id);
            if (x != null)
            {
                var vdto = new StreamDTO
                {
                    IdServicios = x.IdServicios,
                    IdStream = x.IdStream,
                    NumCam = x.NumCam,
                    Angulo = x.Angulo,
                    ContactoCuenta = x.ContactoCuenta,
                    Cuenta = x.Cuenta,
                    Plataforma = x.Plataforma,

                };
                return vdto;
            }
            else return null;
        }

        //update
        public async Task<bool> update(StreamUpdateDTO c)
        {
            DateTime fec = (DateTime)(await _servicioRepository.getById((int)c.IdServicios)).IdEventoNavigation.FechaEvento;
            DateTime fechaActual = DateTime.Now;
            int diferencia = (fec - fechaActual).Days;
            if (diferencia >= 3)
            {
                var v = new Stream
                {
                    IdServicios = c.IdServicios,
                    IdStream = c.IdStream,
                    Estado = "activo",
                    Angulo = c.Angulo,
                    Plataforma = c.Plataforma,
                    Cuenta = c.Cuenta,
                    ContactoCuenta = c.ContactoCuenta,
                    NumCam = c.NumCam
                };
                var e = await _streamRepository.update(v);
                return e;
            }
            else return false;

        }

        public async Task<bool> delete(int id)
        {
            return await _streamRepository.delete(id);
        }
    }
}
