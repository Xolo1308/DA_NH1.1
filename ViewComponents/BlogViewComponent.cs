using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {

        private readonly DemoContext _demoContext;

        public BlogViewComponent(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _demoContext.Blogs.Include(m => m.Category)
           .Where(m => m.IsActive == true);

            return View(await items.OrderBy(m => m.BlogId).ToListAsync());

        }

    }
}
