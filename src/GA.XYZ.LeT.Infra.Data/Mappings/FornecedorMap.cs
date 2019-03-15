using GA.XYZ.LeT.Domain.Fornecedores;
using GA.XYZ.LeT.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.XYZ.LeT.Infra.Data.Mappings {

    public class FornecedorMap : EntityTypeConfiguration<Fornecedor> {

        public override void Map(EntityTypeBuilder<Fornecedor> builder) {

            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.Cidade).HasMaxLength(50);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Id).IsUnicode().IsRequired().HasMaxLength(16);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PeriodoVigenciaFim).HasMaxLength(8);
            builder.Property(x => x.PeriodoVigenciaInicio).IsRequired().HasMaxLength(8);
            builder.Property(x => x.ValorMaxDemanda).HasMaxLength(10);
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);

            builder.HasKey(x => x.Id);
            builder.ToTable("Fornecedores");

        }

    }
}
