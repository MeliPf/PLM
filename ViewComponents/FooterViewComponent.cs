using Microsoft.AspNetCore.Mvc;

namespace PLM.ViewComponents.Footer;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}