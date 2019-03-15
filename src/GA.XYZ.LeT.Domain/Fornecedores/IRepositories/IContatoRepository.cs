using System;
using System.Collections.Generic;
using GA.XYZ.LeT.Domain.Interfaces;

namespace GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories {

    public interface IContatoRepository : IRepository<Contato>{

        IEnumerable<Contato> GetByFornecedor(Guid idFornecedor);

    }
}
