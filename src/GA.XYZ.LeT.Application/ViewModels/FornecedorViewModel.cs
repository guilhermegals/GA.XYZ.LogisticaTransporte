using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GA.XYZ.LeT.Application.ViewModels {

    public class FornecedorViewModel{

        public SelectList Estados() {
            return new SelectList(EstadoViewModel.ListarEstados(), "UF", "Nome");
        }

        public FornecedorViewModel() {
            Id = Guid.NewGuid();
            Contatos = new List<ContatoViewModel>();
            PeriodoVigenciaInicio = DateTime.Now;
            Ativo = true;
            Estado = "Minas Gerais";
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nome.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é 2 caracteres.")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é 150 caracteres.")]
        [Display(Name = "Nome do Fornecedor")]
        public string Nome { get; set; } // Obrigatório

        [Required(ErrorMessage ="Selecione o Estado.")]
        //[MinLength(2, ErrorMessage = "O tamanho minimo do Nome é 2 caracteres.")]
        //[MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é 150 caracteres.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; } // Obrigatório

        [Display(Name = "Cidade")]
        public string Cidade { get; set; } // Opcional

        [Display(Name ="Ativo?")]
        public bool Ativo { get; set; } // Por padrão ativo

        [Required(ErrorMessage ="Preencha uma data de inclusão.")]
        [Display(Name = "Data de inclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime PeriodoVigenciaInicio { get; set; } // Dia do cadastro

        [Display(Name = "Data de dissociação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? PeriodoVigenciaFim { get; set; } //Até o dia atual

        [Display(Name = "Valor máximo por demanda")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage ="Moeda invalida.")]
        //[Required(ErrorMessage ="Informe o valor máximo por demanda.")]
        public decimal? ValorMaxDemanda { get; set; } // Obrigatório e 2 casas decimais

        public ContatoViewModel Contato { get; set; }

        public IEnumerable<ContatoViewModel> Contatos { get; set; }

    }
}
