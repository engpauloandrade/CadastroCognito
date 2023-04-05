using Cadastro.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Cadastro.Persistence.MapMigrations
{
    [ExcludeFromCodeCoverage]
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Base
    {
        private readonly string NomeTabela;

        public BaseMap(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(NomeTabela);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}
