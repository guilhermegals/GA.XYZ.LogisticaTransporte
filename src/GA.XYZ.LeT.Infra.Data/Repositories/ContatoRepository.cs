using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GA.XYZ.LeT.Domain.Fornecedores;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;
using GA.XYZ.LeT.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GA.XYZ.LeT.Infra.Data.Repositories {

    public class ContatoRepository : Repository<Contato>, IContatoRepository {

        public ContatoRepository(LeTContext context) : base(context) {

        }

        IEnumerable<Contato> IContatoRepository.GetByFornecedor(Guid idFornecedor) {
            var sql = @"SELECT * FROM Contatos Cont "+
                "WHERE Cont.IdFornecedor = @oidFornecedor "+
                "ORDER BY Cont.Nome ASC";

            return Context.Database.GetDbConnection().Query<Contato>(sql, new {oidFornecedor = idFornecedor });
        }
    }
}
