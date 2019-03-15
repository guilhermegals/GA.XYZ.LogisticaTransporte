using System.IO;
using GA.XYZ.LeT.Domain.Fornecedores;
using GA.XYZ.LeT.Infra.Data.Extensions;
using GA.XYZ.LeT.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GA.XYZ.LeT.Infra.Data.Context {

    public class LeTContext : DbContext{

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Contato> Contatos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.AddConfiguration(new FornecedorMap());
            modelBuilder.AddConfiguration(new ContatoMap());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        }
    }
}
