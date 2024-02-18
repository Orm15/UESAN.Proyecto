using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IStreamService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<StreamDTO>> GetAll();
        Task<StreamDTO> getById(int id);
        Task<StreamDTO> getbYIdEvento(int id);
        Task<int> InsertStream(StreamInsertDTO streamInsert);
        Task<bool> update(StreamUpdateDTO c);
    }
}