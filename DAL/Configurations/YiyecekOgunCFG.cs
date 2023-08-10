﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class YiyecekOgunCFG : IEntityTypeConfiguration<YiyecekOgun>
    {
        public void Configure(EntityTypeBuilder<YiyecekOgun> builder)
        {
            builder.HasKey(yo => yo.ID);

            builder.Property(yo => yo.ID)
                   .HasColumnName("YiyecekOgunID");

        }
    }
}
