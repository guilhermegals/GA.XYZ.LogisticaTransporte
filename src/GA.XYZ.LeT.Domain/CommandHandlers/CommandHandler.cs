using FluentValidation.Results;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Core.Notifications;
using GA.XYZ.LeT.Domain.Interfaces;

namespace GA.XYZ.LeT.Domain.CommandHandlers {

    public abstract class CommandHandler{

        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacaoErro(ValidationResult validationResult) {
            foreach (var error in validationResult.Errors) {

                //Mensagem de erro aqui

                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit() {
            if (_notifications.HasNotification())
                return false;

            var commandResponse = _uow.Commit();

            if (commandResponse.Sucess)
                return true;

            //mensagem de erro aqui
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu erro ao salvar mensagem no banco."));
            return false;
        }

    }
}
