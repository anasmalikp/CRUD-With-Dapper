using AutoMapper;

namespace DapperTest.Models
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<NoteDTO, NoteModels>();
        }
    }
}
