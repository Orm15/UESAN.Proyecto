using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.proyecto.Infrastructure.Models;
using UESAN.Proyecto.Core.InterfacesRepository;

namespace UESAN.proyecto.Infrastructure.repository
{
    public class ServicioFotosRepository : IServicioFotosRepository
    {
        private readonly OrdenesEventosContext _context;

        public ServicioFotosRepository(OrdenesEventosContext context)
        {
            _context = context;
        }

        //getAll
        public async Task<IEnumerable<ServicioFotos>> getAll()
        {
            var e = await _context.ServicioFotos.ToListAsync();
            if (e.Any()) return e;
            else return null;
        }

        //get by id
        public async Task<ServicioFotos> getById(int id)
        {
            var sf = await _context.ServicioFotos.Where(x => x.IdServicioFotos == id).FirstOrDefaultAsync();
            if (sf == null) return null;
            else return sf;
        }

        //get by ServiciosId
        public async Task<IEnumerable<ServicioFotos>> getBySId(int id)
        {
            var e = await _context.ServicioFotos.Where(x => x.IdServicio == id).ToListAsync();
            if (e == null) return null;
            else return e;
        }

        //insert
        public async Task<ServicioFotos> Insert(ServicioFotos sf)
        {
            await _context.ServicioFotos.AddAsync(sf);
            int rows = await _context.SaveChangesAsync();
            if (rows > 0) return sf;
            else return null;
        }

        //update
        public async Task<bool> update(ServicioFotos sf)
        {
            _context.ServicioFotos.Update(sf);
            int rows = _context.SaveChanges();
            return rows > 0;
        }

        //get link
        public async Task<string> getLink(int id)
        {
            var sf = await _context.ServicioFotos.Where(x => x.IdServicioFotos == id).FirstOrDefaultAsync();
            if (sf == null) return null;
            else return sf.Link;
        }

        //delete: no hay delete :V

    }
}
