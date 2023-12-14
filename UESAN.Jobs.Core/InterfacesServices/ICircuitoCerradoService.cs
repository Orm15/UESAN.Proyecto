using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface ICircuitoCerradoService
    {
        Task<bool> delete(int id);
        Task<IEnumerable<CircuitoCerradoDTO>> GetAll();
        Task<CircuitoCerradoDTO> getbYId(int id);
        Task<CircuitoCerradoDTO> getbYIdEvento(int id);
        Task<int> InsertCC(CircuitoCerradoInsertDTO circuitoCerradoInsert);
        Task<bool> update(CircuitoCerradoUpdateDTO c);
    }
}