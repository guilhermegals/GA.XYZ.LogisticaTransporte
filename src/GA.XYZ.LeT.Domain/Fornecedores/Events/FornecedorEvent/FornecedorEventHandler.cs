using GA.XYZ.LeT.Domain.Core.Events;
using GA.XYZ.LeT.Domain.Fornecedores.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent {

    public class FornecedorEventHandler : IHandler<FornecedorRegistradoEvent>, IHandler<FornecedorAtualizadoEvent>, IHandler<FornecedorExcluidoEvent> {


        public void Handle(FornecedorRegistradoEvent message) {
           
        }

        public void Handle(FornecedorAtualizadoEvent message) {
            
        }

        public void Handle(FornecedorExcluidoEvent message) {
           
        }
    }
}
