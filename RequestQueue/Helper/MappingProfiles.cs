using AutoMapper;
using SigmaBotAPI.Data.Entities;
using SigmaBotAPI.Models;

namespace SigmaBotAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SongEntity,SongModel>();
            CreateMap<StatusEntity, StatusModel>();
        }
    }
}
