using Domain.Entities.Models;
using Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository.Mapping
{
    internal class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("custumer", "dbo");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .IsRequired();

            // Map Value Object
            builder.OwnsOne(s => s.Email, cb =>
            {
                cb.Property(c => c.Description)
                    .HasColumnName(nameof(Email))
                    .HasColumnType("varchar(30)")
                    .IsRequired();
            });

            builder.OwnsOne(s => s.Cpf, cb =>
            {
                cb.Property(c => c.Value)
                    .HasColumnName(nameof(Cpf))
                    .IsRequired();
            });
        }
    }
}