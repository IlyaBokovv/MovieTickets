using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Price).IsRequired();
            builder.Property(ci => ci.Amount).IsRequired();


            builder.HasOne(ci => ci.Movie)
                .WithMany()
                .HasForeignKey(ci => ci.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
