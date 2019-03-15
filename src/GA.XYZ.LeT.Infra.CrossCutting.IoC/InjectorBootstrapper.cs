using AutoMapper;
using GA.XYZ.LeT.Application.AutoMapper;
using GA.XYZ.LeT.Application.IServices;
using GA.XYZ.LeT.Application.Services;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Core.Events;
using GA.XYZ.LeT.Domain.Core.Notifications;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.ContatoCommand;
using GA.XYZ.LeT.Domain.Fornecedores.Commands.FornecedorCommand;
using GA.XYZ.LeT.Domain.Fornecedores.Events.ContatoEvent;
using GA.XYZ.LeT.Domain.Fornecedores.Events.FornecedorEvent;
using GA.XYZ.LeT.Domain.Fornecedores.Interfaces.IRepositories;
using GA.XYZ.LeT.Domain.Interfaces;
using GA.XYZ.LeT.Infra.CrossCutting.Bus;
using GA.XYZ.LeT.Infra.Data.Context;
using GA.XYZ.LeT.Infra.Data.Repositories;
using GA.XYZ.LeT.Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace GA.XYZ.LeT.Infra.CrossCutting.IoC {

    public class InjectorBootstrapper{

        public static void RegisterServices(IServiceCollection services) {

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton(Mapper.Configuration);
            //services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddScoped<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetServices));
            services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>();
            services.AddScoped<IContatoApplicationService, ContatoApplicationService>();

            services.AddScoped<IHandler<RegistrarFornecedorCommand>, FornecedorCommandHandler>();
            services.AddScoped<IHandler<AtualizarFornecedorCommand>, FornecedorCommandHandler>();
            services.AddScoped<IHandler<RemoverFornecedorCommand>, FornecedorCommandHandler>();
            services.AddScoped<IHandler<RegistrarContatoCommand>, ContatoCommandHandler>();
            services.AddScoped<IHandler<AtualizarContatoCommand>, ContatoCommandHandler>();
            services.AddScoped<IHandler<RemoverContatoCommand>, ContatoCommandHandler>();

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<FornecedorRegistradoEvent>, FornecedorEventHandler>();
            services.AddScoped<IHandler<FornecedorExcluidoEvent>, FornecedorEventHandler>();
            services.AddScoped<IHandler<FornecedorAtualizadoEvent>, FornecedorEventHandler>();
            services.AddScoped<IHandler<ContatoRegistradoEvent>, ContatoEventHandler>();
            services.AddScoped<IHandler<ContatoAtualizadoEvent>, ContatoEventHandler>();
            services.AddScoped<IHandler<ContatoExcluidoEvent>, ContatoEventHandler>();


            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LeTContext>();
            services.AddScoped<IBus, InMemoryBus>();

        }

    }
}
