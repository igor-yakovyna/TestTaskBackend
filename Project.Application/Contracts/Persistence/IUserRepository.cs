using Project.Domain.Entities;

namespace Project.Application.Contracts.Persistence;

/// <summary>
/// Encapsulates the logic to work with <see cref="User"/> entity data.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves all elements of the <see cref="User"/> entity found in the database.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// The <see cref="Task"/> object representing the asynchronous <see cref="GetAllAsync"/> operation.
    /// The task result contains the found <see cref="IEnumerable{User}"/> entities, or null.
    /// </returns>
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an <see cref="User"/> entity found in the database by the given <paramref name="id"/>, or null.
    /// </summary>
    /// <param name="id">The value of the primary key for the entity to be found.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// The <see cref="Task"/> object representing the asynchronous <see cref="GetAllAsync"/> operation.
    /// The task result contains the found <see cref="User"/> entity, or null.
    /// </returns>
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds given <paramref name="users"/> to the database.
    /// </summary>
    /// <param name="users">see cref="User"/> collection to be added.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The <see cref="Task"/> object representing the asynchronous <see cref="AddRangeAsync"/> operation.</returns>
    Task AddRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates given <paramref name="user"/> in the database.
    /// </summary>
    /// <param name="user"><see cref="User"/> entity to be updated.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The <see cref="Task"/> object representing the asynchronous <see cref="UpdateAsync"/> operation.</returns>
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes given <paramref name="users"/> from the database. 
    /// </summary>
    /// <param name="users"><see cref="User"/> entities collection to be deleted.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The <see cref="Task"/> object representing the asynchronous <see cref="DeleteRangeAsync"/> operation.</returns>
    Task DeleteRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken = default);
}