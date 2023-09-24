using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImagePath)
                 .IsRequired();

            builder.Ignore(i => i.ImageFile);


            builder.HasOne<Actor>()
                .WithOne(a => a.Image)
                .HasForeignKey<Actor>(a => a.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<Cinema>()
                .WithOne(c => c.Image)
                .HasForeignKey<Cinema>(c => c.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<Director>()
               .WithOne(p => p.Image)
               .HasForeignKey<Director>(p => p.ImageId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<Movie>()
               .WithOne(m => m.Image)
               .HasForeignKey<Movie>(m => m.ImageId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
