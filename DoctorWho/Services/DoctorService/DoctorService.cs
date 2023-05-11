using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.DoctorRepository;

namespace DoctorWho.Services.DoctorService;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<string> AddDoctorAsync(DoctorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Number))
            return "all input is required";
        var doctor = await _doctorRepository.AddDoctorAsync(request);
        if (doctor is null)
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
        var result = await _doctorRepository.UpdateDoctorAsync(request, doctorId);
        if (!result)
            return "failed";
        return "success";
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await _doctorRepository.GetAllDoctors();
    }
}