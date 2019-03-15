using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent {

    public class ContatoRegistradoEvent : BaseContatoEvent{

        public ContatoRegistradoEvent(Guid id, string nome, string email, string telefone) {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.AggregateId = id;
        }

    }
}
