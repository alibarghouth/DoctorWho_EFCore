using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.AuthorRepository;

public interface IAuthorRepository
{
    Task<Author?> AddAuthorAsync(AuthorRequestModel request);
    Task<bool> DeleteAuthorAsync(int authorId);
    Task<bool> UpdateAuthorAsync(AuthorRequestModel request, int authorId);
}