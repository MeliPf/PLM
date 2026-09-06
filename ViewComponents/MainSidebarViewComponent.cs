using Microsoft.AspNetCore.Mvc;

namespace PLM.ViewComponents.MainSidebar;

public class MainSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}