using AutoMapper;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;
using DoctorWho.Db.Repositories.AuthorRepository;
using DoctorWho.Exceptions;

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

    public async Task<AuthorRequestModel> AddAuthorAsync(AuthorRequestModel request)
    {
        if (string.IsNullOrEmpty(request.Name))
            throw new DoctorWhoException();
        var author = _mapper.Map<Author>(request);
        var result = _mapper.Map<AuthorRequestModel>(await _authorRepository.AddAuthorAsync(author));

        return result is null ? throw new NullReferenceException() : result;
    }

    public async Task<bool> DeleteAuthorAsync(int authorId)
    {
        if (authorId == 0)
            return false;
        var result = await _authorRepository.DeleteAuthorAsync(authorId);
        if (!result)
            return false;
        return true;
    }

    public async Task<AuthorRequestModel> UpdateAuthorAsync(AuthorRequestModel request, int authorId)
    {
        if (authorId == 0)
            throw new DoctorWhoException();
        
        var author = await _authorRepository.FindAuthorById(authorId);
        if (!string.IsNullOrEmpty(request.Name))
            author.Name = request.Name;
        var result = _mapper.Map<AuthorRequestModel>( await _authorRepository.UpdateAuthorAsync(author));

        return result is null ? throw new NullReferenceException() : result;
    }
}