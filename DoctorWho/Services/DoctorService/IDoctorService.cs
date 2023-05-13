using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Services.DoctorService;

public interface IDoctorService
{
    Task<string> AddDoctorAsync(DoctorRequestModel request);
    Task<string> DeleteDoctorAsync(int doctorId);
    Task<string> UpdateDoctorAsync(DoctorRequestModel request, int doctorId);
    Task<List<Doctor>> GetAllDoctors();
}