using DoctorWho.Db.DTOS;
using DoctorWho.Db.Repositories.AuthorRepository;

namespace DoctorWho.Services.AuthorService;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<string> AddDoctorAsync(AuthorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name))
            return "all input is required";
        var author = await _authorRepository.AddAuthorAsync(request);
        if (author is null)
            return "failed";
        return "success";
    }

    public async Task<string> DeleteDoctorAsync(int authorId)
    {
        if (authorId == 0)
            return "failed";
        var result = await _authorRepository.DeleteAuthorAsync(authorId);
        if (!result)
            return "failed";
        return "success";
    }

    public async Task<string> UpdateDoctorAsync(AuthorRequestModel request, int authorId)
    {
        if (authorId == 0)
            return "failed";
        var result = await _authorRepository.UpdateAuthorAsync(request, authorId);
        if (!result)
            return "failed";
        return "success";
    }
}