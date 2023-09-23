using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerosOpenBanking.Application.Mediator.Commands;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;

namespace TerosOpenBanking.Application.Mediator.Handler
{
    public class BaseObjectCommandHandler : IRequestHandler<BaseObjectCommand, int>
    {
        private readonly RequestDataContext _dbContext;
        public BaseObjectCommandHandler(RequestDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(BaseObjectCommand request, CancellationToken cancellationToken)
        {
            var requestDataModel = request.GetToMapping();

            _dbContext.DataModel.Add(requestDataModel);
            await _dbContext.SaveChangesAsync();

            return requestDataModel.Id;
        }
            
    }
}
