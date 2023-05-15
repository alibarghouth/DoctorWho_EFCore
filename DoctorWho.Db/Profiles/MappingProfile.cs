using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompanionRequestModel, Companion>().ReverseMap();
        CreateMap<DoctorRequestModel, Doctor>().ReverseMap();
        CreateMap<AuthorRequestModel, Author>().ReverseMap();
        CreateMap<EpisodeRequestModel, Episode>().ReverseMap();
        CreateMap<EnemyRequestModel, Enemy>().ReverseMap();
    }
}