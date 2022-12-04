using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoApplication.Database.Configurations
{
    public class SubNavbarConfiguration
    {
        public void Configure(EntityTypeBuilder<SubNavbar> builder)
        {
            builder
               .HasOne(sn => sn.Navbar)
               .WithMany(n => n.Subnavbars)
               .HasForeignKey(sn => sn.NavbarId);
        }
    }
}
