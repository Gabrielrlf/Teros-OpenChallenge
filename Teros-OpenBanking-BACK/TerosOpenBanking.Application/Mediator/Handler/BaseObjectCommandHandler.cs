using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Commands;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;
using TerosOpenBanking.Infra.Interface;

namespace TerosOpenBanking.Application.Mediator.Handler
{
    public class BaseObjectCommandHandler : IRequestHandler<BaseObjectCommand, RequestDataModel>
    {
        private readonly IRequestRepository _repository;
        public BaseObjectCommandHandler(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestDataModel> Handle(BaseObjectCommand request, CancellationToken cancellationToken)
        {
            var allValues = await _repository.GetData();
            var isExist = allValues.Where(x => x.OrganisationId == request.OrganizationId).Any();


            if (isExist)
                return new RequestDataModel();

            var requestDataModel = request.GetToMapping();

           return await _repository.SaveData(requestDataModel);
        }
            
    }
}
