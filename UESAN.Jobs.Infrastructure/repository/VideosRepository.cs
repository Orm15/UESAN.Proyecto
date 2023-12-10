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
	public class VideosRepository : IVideosRepository
    {
        private readonly OrdenesEventosContext _context;

        public VideosRepository(OrdenesEventosContext context)
        {
            _context = context;
        }

        //getAll
        public async Task<IEnumerable<Videos>> getAll()
        {
            var e = await _context.Videos.ToListAsync();
            if (e.Any()) return e;
            else return null;
        }

        //get by id
        public async Task<Videos> getById(int id)
        {
            var sv = await _context.Videos.Where(x => x.IdVideo == id).FirstOrDefaultAsync();
            if (sv == null) return null;
            else return sv;
        }

        //get by ServiciosId
        public async Task<IEnumerable<Videos>> getBySId(int id)
        {
            var e = await _context.Videos.Where(x => x.IdServicio == id).ToListAsync();
            if (e == null) return null;
            else return e;
        }

        //insert
        public async Task<Videos> Insert(Videos sv)
        {
            await _context.Videos.AddAsync(sv);
            int rows = await _context.SaveChangesAsync();
            if (rows > 0) return sv;
            else return null;
        }

        //update
        public async Task<bool> update(Videos sv)
        {
            _context.Videos.Update(sv);
            int rows = _context.SaveChanges();
            return rows > 0;
        }

        //get link
        public async Task<string> getLink(int id)
        {
            var sv = await _context.Videos.Where(x => x.IdVideo == id).FirstOrDefaultAsync();
            if (sv == null) return null;
            else return sv.Link;
        }

        //delete: no hay delete :V

    }
}
