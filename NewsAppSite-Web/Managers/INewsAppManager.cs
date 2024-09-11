using NewsAppSite_Web.Models;

namespace NewsAppSite_Web.Managers
{
    public interface INewsAppManager
    {
        public Task<List<News>> GetLatestNewsAsync();

        public Task<List<News>> GetNews();
    }
}
