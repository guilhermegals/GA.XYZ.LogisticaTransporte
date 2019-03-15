using AutoMapper;
using GA.XYZ.LeT.Application.ViewModels;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand;

namespace GA.XYZ.LeT.Application.AutoMapper {

    public class ViewModelToDomainMappingProfile : Profile{

        public ViewModelToDomainMappingProfile() {

            //Fornecedores
            CreateMap<FornecedorViewModel, RegistrarFornecedorCommand>()
                .ConstructUsing(f => new RegistrarFornecedorCommand(f.Nome, f.Estado, f.Cidade, f.Ativo, f.PeriodoVigenciaInicio, f.PeriodoVigenciaFim, f.ValorMaxDemanda));

            CreateMap<FornecedorViewModel, AtualizarFornecedorCommand>()
                .ConstructUsing(f => new AtualizarFornecedorCommand(f.Id, f.Nome, f.Estado, f.Cidade, f.Ativo, f.PeriodoVigenciaInicio, f.PeriodoVigenciaFim, f.ValorMaxDemanda));

            CreateMap<FornecedorViewModel, RemoverFornecedorCommand>()
                .ConstructUsing(f => new RemoverFornecedorCommand(f.Id));


            //Contatos
            CreateMap<ContatoViewModel, RegistrarContatoCommand>()
                .ConstructUsing(c => new RegistrarContatoCommand(c.Nome, c.Email, c.Telefone, c.IdFornecedor));

            CreateMap<ContatoViewModel, AtualizarContatoCommand>()
                .ConstructUsing(c => new AtualizarContatoCommand(c.Id, c.Nome, c.Email, c.Telefone, c.IdFornecedor));

            CreateMap<ContatoViewModel, RemoverContatoCommand>()
                .ConstructUsing(c => new RemoverContatoCommand(c.Id));
        }

    }
}
