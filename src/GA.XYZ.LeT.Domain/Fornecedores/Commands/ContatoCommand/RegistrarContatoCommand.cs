using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand {

    public class RegistrarContatoCommand : BaseContatoCommand{

        public RegistrarContatoCommand(string nome, string email, string telefone, Guid idFornecedor) {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.IdFornecedor = idFornecedor;
        }

    }
}
