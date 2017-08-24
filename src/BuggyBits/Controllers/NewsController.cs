using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using BuggyBits.ViewModels;
using Microsoft.AspNetCore.Html;

namespace BuggyBits.Controllers
{
    public class NewsController : Controller
    {
        int[] bits = new int[100000];
        private IMemoryCache cache;

        public NewsController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        private void CacheRemovedCallback(object key, object value, EvictionReason reason, object state)
        {
            //do stuff when the item is removed
        }

        public IActionResult Index()
        {
            string key = Guid.NewGuid().ToString();

            var cachedResult = cache.GetOrCreate(key, cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                cacheEntry.RegisterPostEvictionCallback(CacheRemovedCallback);
                cacheEntry.Priority = CacheItemPriority.NeverRemove;

                return new HtmlString("<I>New site launched 2008-02-02</I>");
            });

            var model = new NewsViewModel
            {
                News = cachedResult
            };

            return View(model);
        }
    }
}