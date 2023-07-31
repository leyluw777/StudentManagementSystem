using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSDomain.Common;

namespace Infrastructure.Persistence.Configurations.Common
{
    public static class ConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
      where TEntity : BaseEntity
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            return builder;
        }

        /// <summary>
        /// Configures the auditable base entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The entity type builder used to configure the entity type.</param>
        /// <returns>The configured entity type builder.</returns>
        public static EntityTypeBuilder<TEntity> ConfigureAuditableBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseAuditableEntity
        {
            builder.ConfigureBaseEntity();
       
            builder.Property(e => e.CreatedBy).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("Getutcdate()");
            builder.Property(e => e.ModifiedBy).HasMaxLength(200);
            return builder;
        }   
    }
}
