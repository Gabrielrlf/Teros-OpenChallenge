using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerosOpenBanking.Domain.Entity;

namespace TerosOpenBanking.Application.Mediator.Query
{
    public class GetDataQuery : IRequest<List<RequestDataModel>>
    {
        public GetDataQuery(bool isCheck)
        => IsCheck = isCheck;
        

        public bool IsCheck { get; set; }
    }
}
