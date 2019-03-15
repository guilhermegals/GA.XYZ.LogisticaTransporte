using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent {

    public class FornecedorExcluidoEvent : BaseFornecedorEvent {

        public FornecedorExcluidoEvent(Guid id) {
            Id = id;
            AggregateId = id;
        }

    }
}
