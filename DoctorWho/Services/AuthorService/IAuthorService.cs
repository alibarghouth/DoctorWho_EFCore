using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.AuthorService;

public interface IAuthorService
{
    Task<string> AddDoctorAsync(AuthorRequestModel request);
    Task<string> DeleteDoctorAsync(int authorId);
    Task<string> UpdateDoctorAsync(AuthorRequestModel request, int authorId);
}