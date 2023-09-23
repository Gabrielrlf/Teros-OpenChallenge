using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Commands;
using TerosOpenBanking.Application.Mediator.Handler;
using TerosOpenBanking.Application.Mediator.Query;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;

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
            services.AddScoped<IRequestHandler<BaseObjectCommand, int>, BaseObjectCommandHandler>();
            services.AddScoped<IRequestHandler<GetDataQuery, List<RequestDataModel>>, GetDataQueryHandler>();

        }
    }
}
