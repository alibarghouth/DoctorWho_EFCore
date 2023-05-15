using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.DoctorRepository;
using DoctorWho.Exceptions;

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

    public async Task<DoctorRequestModel> AddDoctorAsync(DoctorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Number))
            throw new DoctorWhoException();

        var doctor = _mapper.Map<Doctor>(request);
        var result = _mapper.Map<DoctorRequestModel>(await _doctorRepository.AddDoctorAsync(doctor));

        return result is null ? throw new DoctorWhoException() : result;
    }

    public async Task<bool> DeleteDoctorAsync(int doctorId)
    {
        if (doctorId == 0)
            return false;
        var result = await _doctorRepository.DeleteDoctorAsync(doctorId);
        if (!result)
            return false;
        return false;
    }

    public async Task<DoctorRequestModel> UpdateDoctorAsync(DoctorRequestModel request, int doctorId)
    {
        if (doctorId == 0)
            throw new DoctorWhoException();

        var doctor = await _doctorRepository.FindDoctorById(doctorId);
        if (!string.IsNullOrEmpty(request.Name))
            doctor.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Number))
            doctor.Number = request.Number;
        var result = _mapper.Map<DoctorRequestModel>(await _doctorRepository.UpdateDoctorAsync(doctor));

        return result is null ? throw new DoctorWhoException() : result;
    }

    public async Task<List<DoctorRequestModel>> GetAllDoctors()
    {
        return _mapper.Map<List<DoctorRequestModel>>(await _doctorRepository.GetAllDoctors());
    }
}