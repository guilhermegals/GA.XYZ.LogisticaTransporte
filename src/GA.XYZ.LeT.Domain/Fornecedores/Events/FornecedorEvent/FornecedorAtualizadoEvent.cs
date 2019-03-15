using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent {

    public class FornecedorAtualizadoEvent : BaseFornecedorEvent{

        public FornecedorAtualizadoEvent(Guid id, string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim ,decimal? valorMaxDemanda) {
            this.Id = id;
            this.Nome = nome;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Ativo = ativo;
            this.PeriodoVigenciaInicio = periodoVigenciaInicio;
            this.ValorMaxDemanda = valorMaxDemanda;
            this.PeriodoVigenciaFim = periodoVigenciaFim;
            this.AggregateId = id;
        }

    }
}
