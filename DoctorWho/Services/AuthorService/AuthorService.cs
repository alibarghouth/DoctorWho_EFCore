using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.AuthorRepository;

namespace DoctorWho.Services.AuthorService;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<string> AddAuthorAsync(AuthorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name))
            return "all input is required";
        var author = _mapper.Map<Author>(request);
        var result =  await _authorRepository.AddAuthorAsync(author);
        
        if (result is null)
            return "failed";
        
        return "success";
    }

    public async Task<string> DeleteAuthorAsync(int authorId)
    {
        if (authorId == 0)
            return "failed";
        var result = await _authorRepository.DeleteAuthorAsync(authorId);
        if (!result)
            return "failed";
        return "success";
    }

    public async Task<string> UpdateAuthorAsync(AuthorRequestModel request, int authorId)
    {
        if (authorId == 0)
            return "failed";
        
        var author = await _authorRepository.FindAuthorById(authorId);
        if (!string.IsNullOrEmpty(request.Name))
            author.Name = request.Name;

        var result = await _authorRepository.UpdateAuthorAsync(author);
        if (!result)
            return "failed";
        return "success";
    }
}