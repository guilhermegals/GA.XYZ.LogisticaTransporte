using System;
using GA.XYZ.LeT.Domain.Core.Model;

namespace GA.XYZ.LeT.Domain.Fornecedores {

    public class Endereco : Entity<Endereco> {

        public string Estado { get; private set; } //Obrigatório

        public string Cidade { get; private set; } //Opcional

        public Guid? IdFornecedor { get; private set; } //FK


        #region Navigation Properties

        public virtual Fornecedor Fornecedor {get; set;}

        #endregion

        public Endereco(Guid id, string estado, string cidade, Guid? idFornecedor) {
            this.Id = id;
            this.Estado = estado;
            this.Cidade = cidade;
            IdFornecedor = idFornecedor;
        }

        protected Endereco() { }

        public override bool IsValid() {
            return true;
        }
    }
}
