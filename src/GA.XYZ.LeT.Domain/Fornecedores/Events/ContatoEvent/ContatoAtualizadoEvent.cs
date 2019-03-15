using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent {

    public class ContatoAtualizadoEvent : BaseContatoEvent{

        public ContatoAtualizadoEvent(Guid id, string nome, string email, string telefone) {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.AggregateId = Id;
        }

    }
}
