using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IVideosServices
    {
        Task<bool> delete(int id);
        Task<IEnumerable<VideosDTO>> GetAll();
        Task<IEnumerable<VideosDTO>> GetBYIdEvento(int id);
        Task<IEnumerable<VideosDTO>> GetBYIdServicio(int id);
        Task<VideosDTO> getbYIdVideo(int id);
        Task<int> InsertVideo(VideosInsertDTO videosInsertDTO);
        Task<bool> update(VideosUpdateDTO videosUpdateDTO);

        Task<bool> CmabiarEstadoEdicion(int id);

	}
}