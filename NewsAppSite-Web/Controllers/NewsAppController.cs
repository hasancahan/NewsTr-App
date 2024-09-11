using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAppSite_Web.Context;
using NewsAppSite_Web.Managers;
using NewsAppSite_Web.Services;

namespace NewsAppSite_Web.Controllers
{
    public class NewsAppController : Controller
    {

        private readonly INewsAppManager _newsAppManager;
        private readonly DbContextNewsApp _db;
        public NewsAppController(INewsAppManager newsAppManager, DbContextNewsApp db) 
        {
            _newsAppManager = newsAppManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var news = await _newsAppManager.GetNews();
            _db.News.AddRange(news);
            await _db.SaveChangesAsync();
            return View(news);
        }

        public IActionResult NewsDetails(int id) 
        {
            var haber = _db.News.SingleOrDefault(h => h.Id == id);

            if (haber == null)
            {
                return NotFound();
            }

            return View(haber);
        }

    }
}
