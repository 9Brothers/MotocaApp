using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Infrastructure.Database.Configs;

public static class CommonConfig
{
    public static void CommonFields<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName,
        bool hasPrimaryKey = true) where TEntity : Entity
    {
        var entityName = typeof(TEntity).Name;

        // * Tabela
        builder.ToTable(tableName);

        // * Chave primária
        if (hasPrimaryKey)
            builder.HasKey(p => p.Id);
        else
            builder.HasNoKey();

        // * Propriedades
        builder.Property(p => p.Id).HasColumnName($"{entityName}Id").ValueGeneratedOnAdd();
        builder.Property(p => p.Guid).HasColumnName($"{entityName}Guid");
        builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("(now())");
        builder.Property(p => p.UpdatedAt).IsRequired().HasDefaultValueSql("(now())");
        builder.Property(p => p.Enabled).IsRequired().HasDefaultValue(false);

        // * Índices
        builder.HasIndex(p => p.Guid);
    }
}