using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Query;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;
using TerosOpenBanking.Infra.Interface;

namespace TerosOpenBanking.Application.Mediator.Handler
{
    public class GetDataQueryHandler : IRequestHandler<GetDataQuery, List<RequestDataModel>>
    {
        private readonly IRequestRepository _repository;
        public GetDataQueryHandler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RequestDataModel>> Handle(GetDataQuery request, CancellationToken cancellationToken)
        => await _repository.GetData();
    }
}
