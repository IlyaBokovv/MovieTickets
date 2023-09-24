using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;

namespace MovieLibrary.DataAccess.Configurations
{
    public class ActorsMoviesConfigurations : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(am => new { am.ActorId, am.MovieId });

            builder.HasOne(am => am.Movie)
                .WithMany(m => m.ActorsMovies)
                .HasForeignKey(am => am.MovieId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne(am => am.Actor)
                .WithMany(a => a.ActorsMovies)
                .HasForeignKey(am => am.ActorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
