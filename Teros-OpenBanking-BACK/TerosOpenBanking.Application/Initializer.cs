using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using TerosOpenBanking.Application.Mediator.Commands;
using TerosOpenBanking.Application.Mediator.Handler;
using TerosOpenBanking.Application.Mediator.Query;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.BaseApi.Interface;
using TerosOpenBanking.Infra.Context;
using TerosOpenBanking.Infra.Interface;
using TerosOpenBanking.Infra.Repository;

namespace TerosOpenBanking.Application
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<RequestDataContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediator, MediatR.Mediator>();
            services.AddScoped<IRequestHandler<BaseObjectCommand, RequestDataModel>, BaseObjectCommandHandler>();
            services.AddScoped<IRequestHandler<GetDataQuery, List<RequestDataModel>>, GetDataQueryHandler>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<HttpClient>();
            services.AddScoped<IClientApi, ClientApi>();

        }
    }
}
