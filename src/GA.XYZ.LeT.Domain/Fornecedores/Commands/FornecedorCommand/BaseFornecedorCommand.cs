using System;
using GA.XYZ.LeT.Domain.Core.Commands;

namespace GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand {

    public abstract class BaseFornecedorCommand : Command{

        public Guid Id { get; protected set; }

        public string Nome { get; protected set; } // Obrigatório

        public string Estado { get; protected set; } // Obrigatório

        public string Cidade { get; protected set; } // Opcional

        public bool Ativo { get; protected set; } // Por padrão ativo

        public DateTime PeriodoVigenciaInicio { get; protected set; } // Dia do cadastro

        public DateTime? PeriodoVigenciaFim { get; protected set; } //Até o dia atual

        public decimal? ValorMaxDemanda { get; protected set; } // Obrigatório e 2 casas decimais

    }
}
