using global::Autofac;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Qsti.Service.SincronizarDadosEquipamento.Domain.Commands.GlobalSearch.EnviarComandoQuen12;
using System.Reflection;
using Topshelf;
using Topshelf.Unity;
using Unity;

namespace Qsti.Service.SincronizarDadosEquipamento
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = SetupUnityContainer();
            var container = new UnityContainer();

            var serviceProvider = new ServiceCollection()
                .AddScoped<IMediator, Mediator>()
                .AddSingleton<IMediator, Mediator>()
                .AddScoped<ServiceSincronizarDadosEquipamento>()
                .AddSingleton<ServiceSincronizarDadosEquipamento>()
                .AddMediatR(typeof(EnviarComandoQuen12Request).GetTypeInfo().Assembly, typeof(EnviarComandoQuen12Request).GetTypeInfo().Assembly)
                .BuildServiceProvider();




            HostFactory.Run(c =>
            {
                // Pass it to Topshelf
                c.UseUnityContainer(container);

                //var ser = serviceProvider.GetService<ServiceSincronizarDadosEquipamento>();

                var unity = container.RegisterType<IMediator, Mediator>();
                container.RegisterType<ServiceSincronizarDadosEquipamento>();
                container.BuildUp(serviceProvider);

                c.Service<ServiceSincronizarDadosEquipamento>(s =>
                {
                    // Let Topshelf use it
                    s.ConstructUsingUnityContainer();
                    s.ConstructUsing(() => serviceProvider.GetService<ServiceSincronizarDadosEquipamento>());
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
                c.RunAsLocalSystem();
                c.SetServiceName("Qsti.Service.SincronizarDadosEquipamento");
                c.SetDisplayName("Qsti.Service.SincronizarDadosEquipamento");
                c.SetDescription("Solicita ao equipamento os dados do SimCard e atualiza no TrackBusAdmin.");
            });
        }

        //private static UnityContainer SetupUnityContainer()
        //{
        //    // Create your container
        //    var container = new UnityContainer();

        //    //var i = typeof(ServiceSincronizarDadosEquipamento).GetTypeInfo().Assembly;
        //    //var c = typeof(ServiceSincronizarDadosEquipamento).GetTypeInfo().Assembly;

        //    //container.RegisterType<MediatR.Unit> ();

        //    container.RegisterType<IRepositoryGlobalSearch, RepositoryGlobalSearch>();
        //    container.RegisterType<ServiceSincronizarDadosEquipamento>();


        //    return container;
        //}

        
    }
}
