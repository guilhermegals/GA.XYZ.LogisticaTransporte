using System.Collections.Generic;
using GA.XYZ.LeT.Domain.Interfaces;

namespace GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories {

    public interface IFornecedorRepository : IRepository<Fornecedor>{

        //void AddContato(Contato contato);

        //void AttContato(Contato contato);

        IEnumerable<Fornecedor> GetAll(string search);

    }

}
