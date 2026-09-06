using Microsoft.AspNetCore.Mvc;

namespace PLM.ViewComponents.Navbar;

public class NavbarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}