namespace Domain
{
    public interface IDomainEvent<T>
    {
        T Args { get; }
    }
}