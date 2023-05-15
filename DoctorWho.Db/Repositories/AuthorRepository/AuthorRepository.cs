using DoctorWho.Db.Context;
using DoctorWho.Db.DTOS;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Repositories.AuthorRepository;

public class AuthorRepository : IAuthorRepository
{
    private readonly DoctorWhoCoreDbContext _dbContext;
    public AuthorRepository(DoctorWhoCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Author> AddAuthorAsync(Author request)
    {
        await _dbContext.Authors.AddAsync(request);
        await _dbContext.SaveChangesAsync();
        
        return request;
    }

    public async Task<bool> DeleteAuthorAsync(int authorId)
    {
        var author = await FindAuthorById(authorId) ?? throw new NullReferenceException();
        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Author> UpdateAuthorAsync(Author request)
    {
        _dbContext.Authors.Update(request);
        await _dbContext.SaveChangesAsync();

        return request;
    }

    public async Task<Author> FindAuthorById(int authorId)
    {
        return await _dbContext.Authors.FindAsync(authorId);
    }
}