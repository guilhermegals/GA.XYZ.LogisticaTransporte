using System;
using GA.XYZ.LeT.Domain.CommandHandlers;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Core.Events;
using GA.XYZ.LeT.Domain.Core.Notifications;
using GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;
using GA.XYZ.LeT.Domain.Interfaces;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand {

    public class ContatoCommandHandler : CommandHandler, IHandler<RegistrarContatoCommand>, IHandler<AtualizarContatoCommand>, IHandler<RemoverContatoCommand> {

        private readonly IContatoRepository _contatoRepository;
        private readonly IBus _bus;

        public ContatoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IContatoRepository contatoRepository) : base(uow, bus, notifications) {
            _bus = bus;
            _contatoRepository = contatoRepository;
        }

        public void Handle(RegistrarContatoCommand message) {
            var contato = Contato.ContatoFactory.NovoContatoCompleto(message.Id, message.Nome, message.Email, message.Telefone, message.IdFornecedor);

            if (!ContatoValido(contato))
                return;

            //Regra de negocio

            _contatoRepository.Add(contato);

            if (Commit()) {
                //Mensagem de sucesso
                _bus.RaiseEvent(new ContatoRegistradoEvent(contato.Id,contato.Nome, contato.Email, contato.Telefone));
            }

        }

        public void Handle(AtualizarContatoCommand message) {
            if (!ContatoExistente(message.Id, message.MessageType))
                return;

            var contato = Contato.ContatoFactory.NovoContatoCompleto(message.Id, message.Nome, message.Email,message.Telefone, message.IdFornecedor);

            if (!ContatoValido(contato))
                return;

            _contatoRepository.Update(contato);

            if (Commit()) {
                _bus.RaiseEvent(new ContatoAtualizadoEvent(contato.Id, contato.Nome, contato.Email, contato.Telefone));
            }
        }

        public void Handle(RemoverContatoCommand message) {

            if (!ContatoExistente(message.Id, message.MessageType))
                return;

            _contatoRepository.Remove(message.Id);

            if (Commit()) {
                _bus.RaiseEvent(new ContatoExcluidoEvent(message.Id));
            }

        }


        public bool ContatoValido(Contato contato) {

            if (contato.IsValid())
                return true;

            NotificarValidacaoErro(contato.ValidationResult);

            return false;
        }

        public bool ContatoExistente(Guid aId, string aMessageType) {
            var contato = _contatoRepository.GetById(aId);

            if (contato != null)
                return true;

            _bus.RaiseEvent(new DomainNotification(aMessageType, "Contato não encontrado."));

            return false;
        }
    }
}
