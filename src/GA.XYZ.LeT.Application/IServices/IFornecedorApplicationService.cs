using System;
using System.Collections.Generic;
using GA.XYZ.LeT.Application.ViewModels;

namespace GA.XYZ.LeT.Application.IServices {

    public interface IFornecedorApplicationService : IDisposable{

        void Registrar(FornecedorViewModel fornecedorViewModel);

        IEnumerable<FornecedorViewModel> ObterTodos(string search);

        FornecedorViewModel ObterPorId(Guid id);

        void Atualizar(FornecedorViewModel fornecedorViewModel);

        void Excluir(Guid id);

    }
}
