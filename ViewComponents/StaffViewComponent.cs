using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_NH.ViewComponents
{
    public class StaffViewComponent : ViewComponent
    {
        private readonly DemoContext _demoContext;

        public StaffViewComponent(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _demoContext.Staff.Include(m => m.Restaurant)
                   .Where(m => (bool)m.IsActive == true);
                   
            return await Task.FromResult<IViewComponentResult>(View(items));
        }



    }
}
