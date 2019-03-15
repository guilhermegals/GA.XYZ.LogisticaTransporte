using AutoMapper;
using GA.XYZ.LeT.Application.ViewModels;
using GA.XYZ.LeT.Domain.Fornecedores;

namespace GA.XYZ.LeT.Application.AutoMapper {

    public class DomainToViewModelMappingProfile : Profile{

        public DomainToViewModelMappingProfile() {
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Contato, ContatoViewModel>();

        }

    }
}
