using AutoMapper;
using SigmaBotAPI.Application.Models;
using SigmaBotAPI.Domain.Data.Entities;

namespace SigmaBotAPI.Infrastructure.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SongEntity, SongModel>();
            CreateMap<StatusEntity, StatusModel>();
        }
    }
}
