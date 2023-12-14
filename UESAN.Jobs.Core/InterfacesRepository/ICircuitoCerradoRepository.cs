using UESAN.Proyecto.Core.entities;

namespace UESAN.Proyecto.Core.InterfacesRepository
{
	public interface ICircuitoCerradoRepository
	{
		Task<bool> delete(int id);
		Task<IEnumerable<CircuitoCerrado>> getAll();
		Task<CircuitoCerrado> getById(int id);
		Task<CircuitoCerrado> getByIdEvento(int id);
		Task<CircuitoCerrado> Insert(CircuitoCerrado sv);
		Task<bool> update(CircuitoCerrado circuito);

		Task<CircuitoCerrado> getByIdServicio(int id);
	}
}