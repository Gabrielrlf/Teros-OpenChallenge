using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Query;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;

namespace TerosOpenBanking.Application.Mediator.Handler
{
    public class GetDataQueryHandler : IRequestHandler<GetDataQuery, List<RequestDataModel>>
    {
        private readonly RequestDataContext _dbContext;
        public GetDataQueryHandler(RequestDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<RequestDataModel>> Handle(GetDataQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_dbContext.DataModel.ToList());
    }
}
