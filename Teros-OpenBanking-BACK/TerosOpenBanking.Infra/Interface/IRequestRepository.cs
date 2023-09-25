using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerosOpenBanking.Domain.Entity;

namespace TerosOpenBanking.Infra.Interface
{
    public interface IRequestRepository 
    {
      Task<List<RequestDataModel>> GetData();
        Task<RequestDataModel> SaveData(RequestDataModel requestDataModel);
    }
}
