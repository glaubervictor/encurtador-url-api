using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EncurtadorUrl.Api.Shared.Models;

namespace EncurtadorUrl.Api.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("adresses");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Hits)
                .HasColumnName("hits")
                .IsRequired();

            builder.Property(x => x.Url)
                .HasColumnName("url")
                .IsRequired();

            builder.Property(x => x.ShortUrl)
                .HasColumnName("short_url")
                .IsRequired();
        }
    }
}
