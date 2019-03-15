using System;
using System.Linq;
using GA.XYZ.LeT.Domain.CommandHandlers;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Core.Events;
using GA.XYZ.LeT.Domain.Core.Notifications;
using GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;
using GA.XYZ.LeT.Domain.Interfaces;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand {

    public class FornecedorCommandHandler : CommandHandler, IHandler<RegistrarFornecedorCommand>, IHandler<AtualizarFornecedorCommand>, IHandler<RemoverFornecedorCommand> {

        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IBus _bus;

        public FornecedorCommandHandler(IFornecedorRepository fornecedorRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications){
            _fornecedorRepository = fornecedorRepository;
            _bus = bus;
        }

        public void Handle(RegistrarFornecedorCommand message) {
            var fornecedor = Fornecedor.FornecedorFactory.NovoFornecedorCompleto(message.Id, message.Nome, message.Estado, message.Cidade, message.Ativo, message.PeriodoVigenciaInicio,message.PeriodoVigenciaFim, message.ValorMaxDemanda);

            if (!FornecedorValido(fornecedor))
                return;

            if(FornecedorDuplicado(fornecedor))
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Nome de fornecedor já cadastrado"));

            //Persistencia
            _fornecedorRepository.Add(fornecedor);

            if (Commit()) {
                //Mensagem de sucesso
                _bus.RaiseEvent(new FornecedorRegistradoEvent(fornecedor.Id, fornecedor.Nome, fornecedor.Estado, fornecedor.Cidade, fornecedor.Ativo, fornecedor.PeriodoVigenciaInicio, fornecedor.PeriodoVigenciaFim, fornecedor.ValorMaxDemanda));
            }
        }

        public void Handle(AtualizarFornecedorCommand message) {

            if (!FornecedorExistente(message.Id, message.MessageType))
                return;

            var fornecedor = Fornecedor.FornecedorFactory.NovoFornecedorCompleto(message.Id, message.Nome, message.Estado, message.Cidade, message.Ativo, message.PeriodoVigenciaInicio,message.PeriodoVigenciaFim, message.ValorMaxDemanda);

            if (!FornecedorValido(fornecedor))
                return;

            if (FornecedorDuplicado(fornecedor) && fornecedor.Nome != message.Nome) {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Nome de fornecedor já cadastrado"));
                return;
            }

            _fornecedorRepository.Update(fornecedor);

            if (Commit()) {
                _bus.RaiseEvent(new FornecedorAtualizadoEvent(fornecedor.Id, fornecedor.Nome, fornecedor.Estado, fornecedor.Cidade, fornecedor.Ativo, fornecedor.PeriodoVigenciaInicio,fornecedor.PeriodoVigenciaFim, fornecedor.ValorMaxDemanda));
            }

        }

        public void Handle(RemoverFornecedorCommand message) {

            if (!FornecedorExistente(message.Id, message.MessageType))
                return;

            _fornecedorRepository.Remove(message.Id);

            if (Commit()) {
                _bus.RaiseEvent(new FornecedorExcluidoEvent(message.Id));
            }

        }


        public bool FornecedorValido(Fornecedor fornecedor) {

            if (fornecedor.IsValid())
                return true;

            NotificarValidacaoErro(fornecedor.ValidationResult);

            return false;
        }


        public bool FornecedorExistente(Guid aId, string aMessageType) {
            var fornecedor = _fornecedorRepository.GetById(aId);

            if (fornecedor != null)
                return true;

            _bus.RaiseEvent(new DomainNotification(aMessageType, "Fornecedor não encontrado."));

            return false;
        }

        private bool FornecedorDuplicado(Fornecedor fornecedor) {

            var fornecedorExistente = _fornecedorRepository.Find(f => f.Nome == fornecedor.Nome);

            if (fornecedorExistente.Any()) {
                return true;
            }

            return false;
        }
    
    }
}
