using System;

namespace GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent {

    public class FornecedorRegistradoEvent : BaseFornecedorEvent{

        public FornecedorRegistradoEvent(Guid id, string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim, decimal? valorMaxDemanda) {
            Id = id;
            this.Nome = nome;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Ativo = ativo;
            this.PeriodoVigenciaInicio = periodoVigenciaInicio;
            this.ValorMaxDemanda = valorMaxDemanda;
            this.PeriodoVigenciaFim = periodoVigenciaFim;
            AggregateId = id;
        }

    }
}
