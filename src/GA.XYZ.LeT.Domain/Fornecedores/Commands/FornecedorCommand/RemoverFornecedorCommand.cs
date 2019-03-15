using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand {

    public class RemoverFornecedorCommand : BaseFornecedorCommand{

        public RemoverFornecedorCommand(Guid id) {
            Id = id;
            AggregateId = Id;
        }

    }
}
