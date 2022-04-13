﻿using Amovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amovie.Configuration
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors");

            builder.HasKey(x => new { x.ActorId });

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
