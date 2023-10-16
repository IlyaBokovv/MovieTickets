using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.MovieCategory).IsRequired();
            builder.Property(m => m.EndDate).IsRequired();
            builder.Property(m => m.StratDate).IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            builder.HasOne(m => m.Director)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.DirectorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Cinema)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
