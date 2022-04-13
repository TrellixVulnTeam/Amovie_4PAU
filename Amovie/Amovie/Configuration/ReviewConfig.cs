﻿using Amovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amovie.Configuration
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(x => new { x.ReviewId });

            builder.Property(x => x.User)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
