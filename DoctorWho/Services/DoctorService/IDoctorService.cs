using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.DoctorService;

public interface IDoctorService
{
    Task<DoctorRequestModel> AddDoctorAsync(DoctorRequestModel request);
    Task<bool> DeleteDoctorAsync(int doctorId);
    Task<DoctorRequestModel> UpdateDoctorAsync(DoctorRequestModel request, int doctorId);
    Task<List<DoctorRequestModel>> GetAllDoctors();
}