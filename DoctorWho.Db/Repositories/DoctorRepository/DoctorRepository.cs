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

    public async Task<bool> UpdateDoctorAsync(Doctor request)
    {
        _dbContext.Doctors.Update(request);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    public async Task<Doctor> FindDoctorById(int doctorId)
    {
        return await _dbContext.Doctors.FindAsync(doctorId);
    }
}