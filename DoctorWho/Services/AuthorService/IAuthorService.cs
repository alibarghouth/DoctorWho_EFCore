using DoctorWho.Db.DTOS;

namespace DoctorWho.Services.AuthorService;

public interface IAuthorService
{
    Task<AuthorRequestModel> AddAuthorAsync(AuthorRequestModel request);
    Task<bool> DeleteAuthorAsync(int authorId);
    Task<AuthorRequestModel> UpdateAuthorAsync(AuthorRequestModel request, int authorId);
}