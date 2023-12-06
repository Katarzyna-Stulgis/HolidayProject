using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.ViewComponents
{
    [ViewComponent(Name = "SearchProperties")]
    public class SearchPropertiesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}