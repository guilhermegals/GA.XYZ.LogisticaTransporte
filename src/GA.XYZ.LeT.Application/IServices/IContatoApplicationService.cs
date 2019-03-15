using System;
using System.Collections.Generic;
using GA.XYZ.LeT.Application.ViewModels;

namespace GA.XYZ.LeT.Application.IServices {

    public interface IContatoApplicationService : IDisposable{

        void Registrar(ContatoViewModel contatoViewModel);

        IEnumerable<ContatoViewModel> ObterTodos();

        IEnumerable<ContatoViewModel> ObterContatoPorFornecedor(Guid fornecedorId);

        ContatoViewModel ObterPorId(Guid id);

        void Atualizar(ContatoViewModel contatoViewModel);

        void Excluir(Guid id);

    }
}
