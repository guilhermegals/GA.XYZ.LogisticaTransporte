using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand {

    public class RegistrarFornecedorCommand : BaseFornecedorCommand{

        public RegistrarFornecedorCommand(string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim, decimal? valorMaxDemanda) {
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
