using GA.XYZ.LeT.Domain.Core.Events;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent {

    public class ContatoEventHandler : IHandler<ContatoRegistradoEvent>, IHandler<ContatoAtualizadoEvent>, IHandler<ContatoExcluidoEvent> {

        public void Handle(ContatoAtualizadoEvent message) {
            
        }

        public void Handle(ContatoExcluidoEvent message) {
            
        }

        public void Handle(ContatoRegistradoEvent message) {
           
        }
    }
}
