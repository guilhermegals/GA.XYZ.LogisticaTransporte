using GA.XYZ.LeT.Domain.Fornecedores;
using GA.XYZ.LeT.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.XYZ.LeT.Infra.Data.Mappings {

    public class ContatoMap : EntityTypeConfiguration<Contato> {

        public override void Map(EntityTypeBuilder<Contato> builder) {

            builder.Property(x => x.Id).IsRequired().HasMaxLength(16).IsUnicode();
            builder.Property(x => x.IdFornecedor).IsRequired().HasMaxLength(16);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(11).IsRequired();
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Fornecedor).WithMany(x => x.Contatos).HasForeignKey(x => x.IdFornecedor);
            builder.ToTable("Contatos");

        }

    }
}
