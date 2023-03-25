namespace MyAngle.Mvc.Infrastructure
{
    public interface IApiRequestService<T>
    {
        public Task<T> Get();
    }
}
