using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Price).IsRequired();
            builder.Property(oi => oi.Amount).IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            builder.HasOne(oi => oi.Movie)
                .WithMany()
                .HasForeignKey(oi => oi.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
