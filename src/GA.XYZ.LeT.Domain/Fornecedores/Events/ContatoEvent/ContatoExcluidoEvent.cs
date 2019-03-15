using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent {

    public class ContatoExcluidoEvent : BaseContatoEvent{

        public ContatoExcluidoEvent(Guid id) {
            this.Id = id;
            this.AggregateId = id;
        }

    }
}
