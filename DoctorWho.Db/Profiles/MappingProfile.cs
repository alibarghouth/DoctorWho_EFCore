using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompanionRequestModel, Companion>();
        CreateMap<DoctorRequestModel, Doctor>();
        CreateMap<AuthorRequestModel, Author>();
        CreateMap<EpisodeRequestModel, Episode>();
        CreateMap<EnemyRequestModel, Enemy>();
    }
}