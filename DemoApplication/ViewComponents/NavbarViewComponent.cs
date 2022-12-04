using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "Navbar")]
    public class NavbarViewComponent : ViewComponent
    {
        private readonly DataContext _datacontext;
        public NavbarViewComponent(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model= _datacontext.Navbars
                .Include(n=>n.Subnavbars.OrderBy(sn=>sn.Order))
                .Where(n=> n.IsHeader)
                .OrderBy(n => n.Order)
               
                .ToList();

           //model.ForEach(n => n.Subnavbars= n.Subnavbars.OrderBy(sn => sn.Order).ToList());
            return View("~/Views/Shared/Components/Navbar/Index.cshtml", model);
        }
    }
}
