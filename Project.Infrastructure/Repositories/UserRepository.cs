using Microsoft.EntityFrameworkCore;
using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;

namespace Project.Infrastructure.Repositories;

/// <inheritdoc cref="IUserRepository"/>
public class UserRepository : IUserRepository
{
    private readonly DbContext _dataStorageDbContext;
    private readonly DbSet<User> _usersDbSet;

    /// <summary>
    /// <see cref="UserRepository"/> initializer.
    /// </summary>
    /// <param name="dataStorageDbContext">A database context instance.</param>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="dataStorageDbContext"/> is null.</exception>
    public UserRepository(DbContext dataStorageDbContext)
    {
        _dataStorageDbContext = dataStorageDbContext ?? throw new ArgumentNullException(nameof(dataStorageDbContext));
        _usersDbSet = _dataStorageDbContext.Set<User>();
    }

    /// <inheritdoc cref="IUserRepository.GetAllAsync"/>
    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _usersDbSet
            .Include(p => p.Address)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc cref="IUserRepository.GetByIdAsync"/>
    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _usersDbSet
            .Include(p => p.Address)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
    
    /// <inheritdoc cref="IUserRepository.AddRangeAsync"/>
    public async Task AddRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken = default)
    {
        await _usersDbSet.AddRangeAsync(users, cancellationToken);
        await _dataStorageDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc cref="IUserRepository.UpdateAsync"/>
    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _usersDbSet.Update(user);
        await _dataStorageDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc cref="IUserRepository.DeleteRangeAsync"/>
    public async Task DeleteRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken = default)
    {
        _usersDbSet.RemoveRange(users);
        await _dataStorageDbContext.SaveChangesAsync(cancellationToken);
    }
}