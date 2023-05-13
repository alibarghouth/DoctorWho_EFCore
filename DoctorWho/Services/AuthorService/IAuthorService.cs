using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.AuthorService;

public interface IAuthorService
{
    Task<string> AddAuthorAsync(AuthorRequestModel request);
    Task<string> DeleteAuthorAsync(int authorId);
    Task<string> UpdateAuthorAsync(AuthorRequestModel request, int authorId);
}