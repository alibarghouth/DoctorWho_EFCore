using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories.DoctorRepository;

public class DoctorRepository : IDoctorRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public DoctorRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Doctor?> AddDoctorAsync(DoctorRequestModel request)
    {
        var doctor = _mapper.Map<Doctor>(request);
        await _dbContext.Doctors.AddAsync(doctor);

        return doctor;
    }

    public async Task<bool> DeleteDoctorAsync(int doctorId)
    {
        var doctor = await FindDoctorById(doctorId);
        if (doctor is null)
            return false;
        _dbContext.Doctors.Remove(doctor);

        return true;
    }

    public async Task<bool> UpdateDoctorAsync(DoctorRequestModel request, int doctorId)
    {
        var doctor = await FindDoctorById(doctorId);
        if (doctor is null)
            return false;
        if (!string.IsNullOrEmpty(request.Name))
            doctor.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Number))
            doctor.Number = request.Number;
        _dbContext.Doctors.Update(doctor);

        return true;
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    private async Task<Doctor?> FindDoctorById(int doctorId)
    {
        return await _dbContext.Doctors.FindAsync(doctorId);
    }
}