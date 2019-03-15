using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand {

    public class RemoverContatoCommand : BaseContatoCommand{

        public RemoverContatoCommand(Guid id) {
            this.Id = id;
            this.AggregateId = id;
        }

    }
}
