using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.ViewComponents
{
    public class MenuReviewViewComponent : ViewComponent
    {
        private readonly DemoContext _demoContext;

        public MenuReviewViewComponent(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _demoContext.MenuReviews.Include(m => m.MenuItemNavigation)
                   .Where(m => (bool)m.IsActive == true);

            return await Task.FromResult<IViewComponentResult>(View(items));
        }



    }
}
