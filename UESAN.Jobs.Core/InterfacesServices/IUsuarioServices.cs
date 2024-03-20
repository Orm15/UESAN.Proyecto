using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IUsuarioServices
    {
        Task<UsuarioAuthResponseDTO> CreateAdmin(UsuarioCreateDTO usuarioCreateDTO);
        Task<UsuarioAuthResponseDTO> CreateUsuarioNormal(UsuarioCreateDTO usuarioCreateDTO);
        Task<UsuarioAuthResponseDTO> CreateUsuarioNormalSalt(UsuarioCreateDTO usuarioCreateDTO);
        Task<bool> delete(int id);
        Task<IEnumerable<UsuarioDTO>> getAll(string estado);
        Task<UsuarioAuthResponseDTO> sigIn(string correo, string password);
        Task<UsuarioAuthResponseDTO> sigInSal(string correo, string password);
        Task<bool> updateUsuario(UsuarioUpdateDTO usuarioUpdateDTO);
        Task<bool> updateUsuarioSalt(UsuarioUpdateDTO usuarioUpdateDTO);
        Task<UsuarioDTO> getById(int id);

	}
}