namespace Application.Middlewares
{
    public interface IDispatcherCommandMiddleware<TRequest>
    {
        Task Handle(TRequest request, Func<Task> next);
    }
}