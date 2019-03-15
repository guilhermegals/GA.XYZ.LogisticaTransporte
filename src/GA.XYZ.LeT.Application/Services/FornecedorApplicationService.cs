using System;
using System.Collections.Generic;
using AutoMapper;
using GA.XYZ.LeT.Application.IServices;
using GA.XYZ.LeT.Application.ViewModels;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;

namespace GA.XYZ.LeT.Application.Services {

    public class FornecedorApplicationService : IFornecedorApplicationService {

        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IBus bus, IMapper mapper, IFornecedorRepository repository) {
            _bus = bus;
            _mapper = mapper;
            _repository = repository;
        }

        public void Atualizar(FornecedorViewModel fornecedorViewModel) {
            var atualizarCommand = _mapper.Map<AtualizarFornecedorCommand>(fornecedorViewModel);
            _bus.SendCommand(atualizarCommand);
        }

        public void Excluir(Guid id) {
            _bus.SendCommand(new RemoverFornecedorCommand(id));
        }

        public void Registrar(FornecedorViewModel fornecedorViewModel) {
            var registrarCommand = _mapper.Map<RegistrarFornecedorCommand>(fornecedorViewModel);
            _bus.SendCommand(registrarCommand);
        }

        public FornecedorViewModel ObterPorId(Guid id) {
            return _mapper.Map<FornecedorViewModel>(_repository.GetById(id));
        }

        public IEnumerable<FornecedorViewModel> ObterTodos(string search) {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(_repository.GetAll(search));
        }

        public void Dispose() {
            _repository.Dispose();
        }
    }
}
