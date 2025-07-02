public interface IRequestRepository
{
    Task LogRequestAsync(string url);
}