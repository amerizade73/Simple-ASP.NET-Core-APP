using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp.Data.Domain;

namespace SimpleApp.Data.DomainConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(400);
            builder.Property(p => p.Gender).IsRequired();
        }
    }
}
