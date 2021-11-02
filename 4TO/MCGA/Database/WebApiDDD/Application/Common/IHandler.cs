namespace Application
{
    public interface IHandler<T>
    {
        void Handle(T eventToHandle);
    }
}