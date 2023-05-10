using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CompanionRequestModel, Companion>();
    }
}