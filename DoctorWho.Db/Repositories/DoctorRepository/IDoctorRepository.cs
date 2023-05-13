using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.DoctorRepository;

public interface IDoctorRepository
{
    Task<Doctor> AddDoctorAsync(Doctor request);
    Task<bool> DeleteDoctorAsync(int doctorId);
    Task<bool> UpdateDoctorAsync(Doctor request);
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> FindDoctorById(int doctorId);
}