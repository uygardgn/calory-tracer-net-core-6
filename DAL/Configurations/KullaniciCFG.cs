using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class KullaniciCFG : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(k => k.ID);

            builder.Property(k => k.ID)
                   .HasColumnName("KullaniciID");

            builder.Property(k => k.Ad)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(k => k.Soyad)
                   .HasColumnType("varchar")
                   .HasMaxLength(20);

            builder.Property(k => k.KullaniciAdi)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.HasIndex(k => k.KullaniciAdi)
                   .IsUnique();

            builder.Property(k => k.Sifre)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(64);

            builder.Property(k => k.Boy)
                   .HasColumnType("float");

            builder.Property(k => k.Kilo)
                   .HasColumnType("float");

            builder.Property(k => k.KaloriIhtiyacı)
                   .HasColumnType("float");


        }
    }
}
