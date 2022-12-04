using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoApplication.Database.Configurations
{
    public class NavbarConfigurations
    {
        public void Configure(EntityTypeBuilder<Navbar> builder)
        {
            builder
               .ToTable("Navbars");
        }
    }
}
