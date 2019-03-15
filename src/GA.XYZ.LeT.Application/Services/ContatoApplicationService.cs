using System;
using System.Collections.Generic;
using AutoMapper;
using GA.XYZ.LeT.Application.IServices;
using GA.XYZ.LeT.Application.ViewModels;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;

namespace GA.XYZ.LeT.Application.Services {

    public class ContatoApplicationService : IContatoApplicationService {

        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IContatoRepository _repository;

        public ContatoApplicationService(IBus bus, IMapper mapper, IContatoRepository repository) {
            _bus = bus;
            _mapper = mapper;
            _repository = repository;
        }

        public void Atualizar(ContatoViewModel contatoViewModel) {
            var atualizarCommand = _mapper.Map<AtualizarContatoCommand>(contatoViewModel);
            _bus.SendCommand(atualizarCommand);
        }

        public void Excluir(Guid id) {
            _bus.SendCommand(new RemoverContatoCommand(id));
        }

        public void Registrar(ContatoViewModel contatoViewModel) {
            var registrarCommand = _mapper.Map<RegistrarContatoCommand>(contatoViewModel);
            _bus.SendCommand(registrarCommand);
        }

        public IEnumerable<ContatoViewModel> ObterContatoPorFornecedor(Guid fornecedorId) {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_repository.GetByFornecedor(fornecedorId));
        }

        public ContatoViewModel ObterPorId(Guid id) {
            return _mapper.Map<ContatoViewModel>(_repository.GetById(id));
        }

        public IEnumerable<ContatoViewModel> ObterTodos() {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_repository.GetAll());
        }

        public void Dispose() {
            _repository.Dispose();
        }
    }
}
