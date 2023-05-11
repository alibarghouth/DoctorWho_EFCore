using AutoMapper;
using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.AuthorRepository;

public class AuthorRepository : IAuthorRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public AuthorRepository(DoctorWhoCoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Author?> AddAuthorAsync(AuthorRequestModel request)
    {
        var author = _mapper.Map<Author>(request);
        await _dbContext.Authors.AddAsync(author);

        return author;
    }

    public async Task<bool> DeleteAuthorAsync(int authorId)
    {
        var author = await FindAuthorById(authorId);
        if (author is null)
            return false;
        _dbContext.Authors.Remove(author);
        return true;
    }

    public async Task<bool> UpdateAuthorAsync(AuthorRequestModel request, int authorId)
    {
        var author = await FindAuthorById(authorId);
        if (author is null)
            return false;
        if (!string.IsNullOrEmpty(request.Name))
            author.Name = request.Name;
        
        _dbContext.Authors.Update(author);

        return true;
    }

    private async Task<Author?> FindAuthorById(int authorId)
    {
        return await _dbContext.Authors.FindAsync(authorId);
    }
}