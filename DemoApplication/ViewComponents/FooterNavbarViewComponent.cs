using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "FooterNavbar")]
    public class FooterNavbarViewComponent : ViewComponent
    {
        private readonly DataContext _datacontext;
        public FooterNavbarViewComponent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _datacontext.Navbars
                .Include(n => n.Subnavbars.OrderBy(sn => sn.Order))
                .Where(n => n.IsFooter)
                .OrderBy(n => n.Order)

                .ToList();

            //model.ForEach(n => n.Subnavbars= n.Subnavbars.OrderBy(sn => sn.Order).ToList());
            return View("~/Views/Shared/Components/FooterNav/Index.cshtml", model);
        }
    }
}
