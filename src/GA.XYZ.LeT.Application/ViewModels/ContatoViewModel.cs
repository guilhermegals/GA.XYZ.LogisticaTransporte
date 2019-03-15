using System;
using System.ComponentModel.DataAnnotations;

namespace GA.XYZ.LeT.Application.ViewModels {

    public class ContatoViewModel{

        public ContatoViewModel() {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Preencha o Nome do contato.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é 2 caracteres.")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é 150 caracteres.")]
        [Display(Name = "Nome do Contato")]
        public string Nome { get; set; } //Obrigatório

        [Required(ErrorMessage ="Prencha o E-mail do contato.")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é 100 caracteres.")]
        [EmailAddress(ErrorMessage = "E-mail invalido.")]
        [Display(Name = "E-mail do Contato")]
        public string Email { get; set; } //Obrigatório

        [Required(ErrorMessage = "Prencha o Telefone do contato.")]
        //[DataType(DataType.PhoneNumber)]
        //[Phone(ErrorMessage = "Telefone invalido.")]
        [Display(Name = "Telefone do Contato")]
        public string Telefone { get; set; } //Obrigatório

        public Guid IdFornecedor { get; set; }

    }
}
