namespace ViberAdapter.Services
{
    public interface IWebhookService
    {
        Task<bool> Create();

        Task<bool> Delete();
    }
}
