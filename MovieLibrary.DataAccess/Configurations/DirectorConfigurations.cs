using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class DirectorConfigurations : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Bio).IsRequired(false);
        }
    }
}
