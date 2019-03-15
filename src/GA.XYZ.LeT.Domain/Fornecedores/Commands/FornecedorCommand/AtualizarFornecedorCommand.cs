using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand {

    public class AtualizarFornecedorCommand : BaseFornecedorCommand{

        public AtualizarFornecedorCommand(Guid id, string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim, decimal? valorMaxDemanda) {
            Id = id;
            this.Nome = nome;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Ativo = ativo;
            this.PeriodoVigenciaInicio = periodoVigenciaInicio;
            this.PeriodoVigenciaFim = periodoVigenciaFim;
            this.ValorMaxDemanda = valorMaxDemanda;
        }

    }
}
