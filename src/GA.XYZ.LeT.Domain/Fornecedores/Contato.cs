using FluentValidation;
using GA.XYZ.LeT.Domain.Core.Model;
using System;

namespace GA.XYZ.LeT.Domain.Fornecedores {

    public class Contato : Entity<Contato> {


        public string Nome { get; private set; } //Obrigatório

        public string Email { get; private set; } //Obrigatório

        public string Telefone { get; private set; } //Obrigatório

        public Guid IdFornecedor { get; private set; } //FK


        #region Navigation Properties

        public virtual Fornecedor Fornecedor { get; set; }

        #endregion


        public Contato(string nome, string email, string telefone) {
            Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        protected Contato() { }

        public override bool IsValid() {
            Validar();
            return ValidationResult.IsValid;
        }


        #region [Validações]

        private void Validar() {
            ValidarNome();
            ValidarEmail();
            ValidationResult = Validate(this);
        }

        private void ValidarNome() {
            RuleFor(c => c.Nome).
                NotEmpty().WithMessage("Preencha o nome do contato.").
                Length(2, 150).WithMessage("Tamanho de nome invalido.");
        }

        private void ValidarEmail() {
            RuleFor(c => c.Email).
                NotEmpty().WithMessage("Preencha um e-mail de contato.").
                Length(2, 100).WithMessage("Tamanho de e-mail invalido.").
                EmailAddress().WithMessage("Preencha um e-mail válido."); ;
        }

        private void ValidarTelefone() {
            RuleFor(c => c.Telefone).
                NotEmpty().WithMessage("Preenhca um telefone de contato.");
        }

        #endregion


        public static class ContatoFactory {

            public static Contato NovoContatoCompleto(Guid id, string nome, string email, string telefone, Guid idFornecedor) {
                var contato = new Contato() {
                    Id = id,
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    IdFornecedor = idFornecedor
                };
                return contato;
            }

        }
    }
}