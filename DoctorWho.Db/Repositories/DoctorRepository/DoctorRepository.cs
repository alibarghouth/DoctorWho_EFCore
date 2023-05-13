using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories.DoctorRepository;

public class DoctorRepository : IDoctorRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;

    public DoctorRepository(DoctorWhoCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Doctor> AddDoctorAsync(Doctor request)
    {
        await _dbContext.Doctors.AddAsync(request);
        await _dbContext.SaveChangesAsync();

        return request;
    }

    public async Task<bool> DeleteDoctorAsync(int doctorId)
    {
        var doctor = await FindDoctorById(doctorId);

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateDoctorAsync(DoctorRequestModel request, int doctorId)
    {
        var doctor = await FindDoctorById(doctorId);

        if (!string.IsNullOrEmpty(request.Name))
            doctor.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Number))
            doctor.Number = request.Number;
        _dbContext.Doctors.Update(doctor);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    private async Task<Doctor> FindDoctorById(int doctorId)
    {
        return await _dbContext.Doctors.FindAsync(doctorId);
    }
}