using System;
using System.Collections.Generic;
using FluentValidation;
using GA.XYZ.LeT.Domain.Core.Model;

namespace GA.XYZ.LeT.Domain.Fornecedores {

    public class Fornecedor : Entity<Fornecedor> {

        public string Nome { get; private set; } // Obrigatório

        public string Estado { get; private set; } // Obrigatório

        public string Cidade { get; private set; } // Opcional

        public bool Ativo { get; private set; } // Por padrão ativo

        public DateTime PeriodoVigenciaInicio { get; private set; } // Dia do cadastro

        public DateTime? PeriodoVigenciaFim { get; private set; } //Até o dia atual

        public decimal? ValorMaxDemanda { get; private set; } // Obrigatório e 2 casas decimais


        #region Navigation Properties

        public ICollection<Contato> Contatos { get; private set; }

        #endregion


        public Fornecedor(string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim, decimal? valorMaxDemanda) {
            Id = Guid.NewGuid();
            this.Nome = nome;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Ativo = ativo;
            this.PeriodoVigenciaInicio = periodoVigenciaInicio;
            this.PeriodoVigenciaFim = periodoVigenciaFim;
            this.ValorMaxDemanda = valorMaxDemanda.Value;
            Contatos = new List<Contato>();
        }

        public override bool IsValid() {
            Validar();
            return ValidationResult.IsValid;
        }

        protected Fornecedor() {
            Contatos = new List<Contato>();
        }

        public void DesativarFornecedor() {
            if (Ativo) { 
                Ativo = false;
                PeriodoVigenciaFim = DateTime.Now;
            }
        }

        public void ReativarFornecedor() {
            if (!Ativo) {
                Ativo = true;
                PeriodoVigenciaFim = null;
            }
        }


        #region [Validações]

        private void Validar() {
            ValidarNome();
            ValidarEstado();
            ValidarPeriodoVigenciaIncio();
            ValidarValorMaxDemanda();
            ValidarData();
            ValidationResult = Validate(this);
        }

        private void ValidarNome() {
            RuleFor(f => f.Nome).
                NotEmpty().WithMessage("Preencha o nome do fornecedor.").
                Length(2, 150).WithMessage("Tamanho invalido.");
        }

        private void ValidarEstado() {
            RuleFor(f => f.Estado).
                NotEmpty().WithMessage("Selecione o estado do fornecedor.");
        }

        private void ValidarPeriodoVigenciaIncio() {
            RuleFor(f => f.PeriodoVigenciaInicio).
                NotEmpty().WithMessage("Preencha a data de união.");

            RuleFor(c => c.PeriodoVigenciaInicio)
                .LessThan(DateTime.Now)
                .WithMessage("A data de início deve ser menor que a data atual");
        }

        private void ValidarValorMaxDemanda() {
            RuleFor(f => f.ValorMaxDemanda).
                GreaterThan(0).WithMessage("O valor de demanda deve ser maior que 0.");
        }

        private void ValidarData() {
            RuleFor(f => f.PeriodoVigenciaFim).
                GreaterThan(f => f.PeriodoVigenciaInicio).WithMessage("A data de dissociação deve ser maior que a de inclusão.");

            if (!Ativo)
                RuleFor(f => f.PeriodoVigenciaFim)
                    .NotEmpty().WithMessage("Insira a data de disasociação.");
        }

        #endregion


        public static class FornecedorFactory {
            
            public static Fornecedor NovoFornecedorCompleto(Guid id, string nome, string estado, string cidade, bool ativo, DateTime periodoVigenciaInicio, DateTime? periodoVigenciaFim, decimal? valorMaxDemanda) {
                var fornecedor = new Fornecedor() {
                    Id = id,
                    Nome = nome,
                    Estado = estado,
                    Cidade = cidade,
                    Ativo = ativo,
                    PeriodoVigenciaInicio = periodoVigenciaInicio,
                    PeriodoVigenciaFim = periodoVigenciaFim,
                    ValorMaxDemanda = valorMaxDemanda
                };
                return fornecedor;
            }

        } 

    }
}
