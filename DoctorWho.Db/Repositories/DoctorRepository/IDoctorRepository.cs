using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.DoctorRepository;

public interface IDoctorRepository
{
    Task<Doctor?> AddDoctorAsync(DoctorRequestModel request);
    Task<bool> DeleteDoctorAsync(int doctorId);
    Task<bool> UpdateDoctorAsync(DoctorRequestModel request, int doctorId);
}