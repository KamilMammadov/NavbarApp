namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class SubAddViewModel   //programda problem oldugu ucun viewmodelin qabagina sub yazmag mecburiyyetinde qaldim
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url{ get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }
        public List<NavbarListItemViewModel>? Navbar { get; set; }
    }
}
