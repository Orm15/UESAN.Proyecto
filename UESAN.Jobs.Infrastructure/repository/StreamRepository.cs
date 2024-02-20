using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.entities;
using UESAN.Proyecto.Core.InterfacesRepository;
using Stream = UESAN.Proyecto.Core.entities.Stream;

namespace UESAN.proyecto.Infrastructure.repository
{
    public class StreamRepository : IStreamRepository
    {
        private readonly OrdenesEventosContext _eventosContext;

        public StreamRepository(OrdenesEventosContext eventosContext)
        {
            _eventosContext = eventosContext;
        }

        public async Task<IEnumerable<Stream>> getAll()
        {
            var c = await _eventosContext.Stream.Where(x => x.Estado == "activo").ToListAsync();
            if (c.Any()) return c;
            else return null;
        }

        public async Task<Stream> getById(int id)
        {
            var c = await _eventosContext.Stream.Where(x => x.IdStream == id).FirstOrDefaultAsync();
            if (c != null) return c;
            else return null;
        }

        public async Task<Stream> getByIdEvento(int id)
        {
            var c = await _eventosContext.Stream.Where(x => x.IdServiciosNavigation.IdEventoNavigation.IdEvento == id)
                .Include(x => x.IdServiciosNavigation.IdEventoNavigation).FirstOrDefaultAsync();
            if (c != null) return c;
            else return null;
        }

        public async Task<Stream> getByIdServicio(int id)
        {
            var c = await _eventosContext.Stream.Where(x => x.IdServicios == id)
                .Include(x => x.IdServiciosNavigation.IdEventoNavigation).FirstOrDefaultAsync();
            if (c != null) return c;
            else return null;
        }

        public async Task<bool> update(Stream stream)
        {
            _eventosContext.Stream.Update(stream);
            int rows = _eventosContext.SaveChanges();
            return rows > 0;
        }

        public async Task<Stream> Insert(Stream stream)
        {
            await _eventosContext.Stream.AddAsync(stream);
            int rows = await _eventosContext.SaveChangesAsync();
            if (rows > 0) return stream;
            else return null;
        }

        public async Task<bool> delete(int id)
        {
            var emp = await _eventosContext.Stream.Where(x => x.IdStream == id && x.Estado == "activo").FirstOrDefaultAsync();

            if (emp == null)
            {
                return false;
            }
            emp.Estado = "inactivo";
            int rows = await _eventosContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
