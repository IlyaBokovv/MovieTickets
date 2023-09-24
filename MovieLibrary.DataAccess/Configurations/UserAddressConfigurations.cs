using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class UserAddressConfigurations : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Country).IsRequired();
            builder.Property(a => a.State).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.ZipCode).IsRequired();


            builder.HasOne<AppUser>()
                .WithOne(a => a.UserAddress)
                .HasForeignKey<AppUser>(a => a.UserAddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
