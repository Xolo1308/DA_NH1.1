using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly DemoContext _demoContext;

        public ProductViewComponent(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _demoContext.MenuItems.Include(m => m.Category)
                   .Where(m => (bool)m.IsAvailable == true ) 
                   .Where(m => m.IsNew == true);
            return await Task.FromResult<IViewComponentResult>(View(items));
        }

       
        
    }
}
