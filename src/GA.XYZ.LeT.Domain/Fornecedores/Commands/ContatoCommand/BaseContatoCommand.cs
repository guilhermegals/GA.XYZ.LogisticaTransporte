using System;
using GA.XYZ.LeT.Domain.Core.Commands;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand {

    public abstract class BaseContatoCommand : Command{

        public Guid Id { get; protected set; }

        public string Nome { get; protected set; } //Obrigatório

        public string Email { get; protected set; } //Obrigatório

        public string Telefone { get; protected set; } //Obrigatório

        public Guid IdFornecedor { get; protected set; } //FK

    }
}
