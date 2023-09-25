using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerosOpenBanking.Domain.Entity;
using TerosOpenBanking.Infra.Context;
using TerosOpenBanking.Infra.Interface;

namespace TerosOpenBanking.Infra.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestDataContext _dbContext;

        public RequestRepository(RequestDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<RequestDataModel>> GetData()
        =>  Task.FromResult(_dbContext.DataModel.ToList());

        public async Task<RequestDataModel> SaveData(RequestDataModel requestDataModel)
        {
            _dbContext.DataModel.Add(requestDataModel);
            await _dbContext.SaveChangesAsync();

            return requestDataModel;
        }
    }
}
