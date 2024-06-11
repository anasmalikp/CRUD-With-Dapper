using DapperTest.Models;

namespace DapperTest.Services
{
    public interface INoteServices
    {
        Task<IEnumerable<NoteModels>> GetAll();
        Task<NoteDTO> GetbyID(int Id);
        Task<bool> AddNew(NoteDTO model);
        Task<bool> EditNote(int id, NoteDTO model);
        Task<bool> DeleteNote(int id);
    }
}
