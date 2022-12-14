using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Navbar : BaseEntity
    {
   
        public string Title { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool IsBold { get; set; }
        public bool IsHeader { get; set; }
        public bool IsFooter { get; set; }
        public List<SubNavbar> Subnavbars { get; set; }

    }
}
