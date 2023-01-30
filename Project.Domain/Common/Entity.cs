namespace Project.Domain.Common;

public class Entity<T>
{
    public T Id { get; protected set; }
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime? UpdateDateTime { get; set; }
}