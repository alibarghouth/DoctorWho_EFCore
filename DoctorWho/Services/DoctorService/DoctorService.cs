using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.DoctorRepository;

namespace DoctorWho.Services.DoctorService;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<string> AddDoctorAsync(DoctorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Number))
            return "all input is required";
        var doctor = _mapper.Map<Doctor>(request);
        var result = await _doctorRepository.AddDoctorAsync(doctor);
        if (result is null)
            return "failed";
        return "success";
    }

    public async Task<string> DeleteDoctorAsync(int doctorId)
    {
        if (doctorId == 0)
            return "failed";
        var result = await _doctorRepository.DeleteDoctorAsync(doctorId);
        if (!result)
            return "failed";
        return "success";
    }

    public async Task<string> UpdateDoctorAsync(DoctorRequestModel request, int doctorId)
    {
        if (doctorId == 0)
            return "failed";
        var doctor = await _doctorRepository.FindDoctorById(doctorId);
        if (!string.IsNullOrEmpty(request.Name))
            doctor.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Number))
            doctor.Number = request.Number;
        
        var result = await _doctorRepository.UpdateDoctorAsync(doctor);
        if (!result)
            return "failed";
        return "success";
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _doctorRepository.GetAllDoctors();
    }
}