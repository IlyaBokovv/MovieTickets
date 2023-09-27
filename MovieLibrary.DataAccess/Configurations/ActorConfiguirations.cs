using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.DataAccess.Configurations
{
    public class ActorConfiguirations : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.FullName).IsRequired();
            builder.Property(a => a.Bio).IsRequired(false);

        }
    }
}
