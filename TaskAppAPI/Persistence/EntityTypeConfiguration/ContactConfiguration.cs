using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.MobilePhone).HasMaxLength(18);
            builder.Property(x => x.JobTitle).HasMaxLength(150);
            ////
        }

    }
}
