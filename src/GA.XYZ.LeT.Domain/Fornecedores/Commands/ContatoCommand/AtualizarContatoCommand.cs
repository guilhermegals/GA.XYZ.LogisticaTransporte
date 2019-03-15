using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand {

    public class AtualizarContatoCommand : BaseContatoCommand{

        public AtualizarContatoCommand(Guid id, string nome, string email, string telefone, Guid idFornecedor) {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.IdFornecedor = idFornecedor;
        }

    }
}
