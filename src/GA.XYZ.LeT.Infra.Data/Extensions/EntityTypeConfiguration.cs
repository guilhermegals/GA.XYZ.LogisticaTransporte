using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.XYZ.LeT.Infra.Data.Extensions {

    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class{

        public abstract void Map(EntityTypeBuilder<TEntity> builder);

    }
}
