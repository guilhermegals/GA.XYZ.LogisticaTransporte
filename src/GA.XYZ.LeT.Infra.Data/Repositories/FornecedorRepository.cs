using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GA.XYZ.LeT.Domain.Fornecedores;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;
using GA.XYZ.LeT.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GA.XYZ.LeT.Infra.Data.Repositories {

    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository {

        public FornecedorRepository(LeTContext context) : base(context) {

        }

        public override IEnumerable<Fornecedor> GetAll() {

            var sql = "SELECT * FROM Fornecedores Forn " + "WHERE Forn.Ativo = 1 OR Forn.Ativo = 0" + "ORDER BY Forn.Nome ASC";

            return Context.Database.GetDbConnection().Query<Fornecedor>(sql);

        }

        public IEnumerable<Fornecedor> GetAll(string search) {
            string sql;
            if (!String.IsNullOrEmpty(search)) {
                sql = "SELECT * FROM Fornecedores Forn " + "WHERE Forn.Nome LIKE @usearch OR Forn.Cidade LIKE @usearch OR Forn.Estado LIKE @usearch OR Forn.Ativo LIKE @usearch "  + "ORDER BY Forn.Nome ASC";
                return Context.Database.GetDbConnection().Query<Fornecedor>(sql, new { usearch = "%" + search.ToLower() + "%"});
            } else {
                return GetAll();
            }
        }

        public override Fornecedor GetById(Guid id) {
            var sql = @"SELECT * FROM Fornecedores forn " +
                      "WHERE Forn.Id = @uid";

            var fornecedor = Context.Database.GetDbConnection().Query<Fornecedor>(sql, new { uid = id });

            return fornecedor.SingleOrDefault();
        }

        public  Fornecedor GetsById(Guid id) {
            
            var sql = @"SELECT * FROM Fornecedores forn " +
                       "LEFT JOIN Contatos cont " +
                       "ON forn.Id = cont.IdFornecedor " +
                       "WHERE forn.Id = @sid";

            var fornecedor = new List<Fornecedor>();
            Context.Database.GetDbConnection().Query<Fornecedor, Contato, Fornecedor>(sql,
                (f, c) => {
                    fornecedor.Add(f);
                    if (c != null)
                        fornecedor[0].Contatos.Add(c);

                    return fornecedor.FirstOrDefault();
                }, new { sid = id }, splitOn: "Id, Id");

            return fornecedor.FirstOrDefault();
        }
    }
}
