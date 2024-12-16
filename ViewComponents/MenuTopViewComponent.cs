using DA_NH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DA_NH.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly DemoContext _demoContext;

        public MenuTopViewComponent(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(bool IsActive)
        {
            var items = _demoContext.TblMenus. // truy vấn bg Menus từ csdl thông qua Entity
                Where(m => m.IsActive.HasValue && m.IsActive.Value).// chỉ chọn menu có IsActive là true, chọ các mục menu đg hd
                OrderBy(m => m.Position).//sx menu theo cột 
                ToList();//chuyên kq truy vấn thành 1 ds bất đồng độ 
            return await Task.FromResult<IViewComponentResult>(View(items));// trả về ds các menu hd
        }
    }
}
