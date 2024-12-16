using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.Controllers
{
    public class BlogController : Controller
    {
        private readonly DemoContext _demoContext;
        public BlogController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _demoContext.Blogs == null)
            {
                return NotFound();
            }
            var blog = await _demoContext.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _demoContext.BlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);
        }
    }
}
